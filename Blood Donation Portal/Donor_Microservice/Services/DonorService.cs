using Donor_Microservice.Models;
using Donor_Microservice.Constants;
using Donor_Microservice.Persistence.IRepositories;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Donor_Microservice.Services
{
    public class DonorService : IDonorService
    {
        readonly IDonorRepository _donorRepository;
        public DonorService(IDonorRepository donorRepository)
        {
            this._donorRepository = donorRepository;
        }

        public async Task<Donation> AddDonationToDonorHistoryAsync(string email, Donation donation)
        {
            await _donorRepository.AddDonationToDonorHistoryAsync(email, donation);
            return donation;
        }

        public async Task<IEnumerable<Donation>> GetDonorHistory(Guid id)
        {
            var history = await _donorRepository.GetDonorHistory(id);
            return history.ToList();
        }

        /*
         *  Max 3 times/year for women
         *  Max 4-5times/year for men
         *  At least 8 weeks(56 days) between donations
         */
        public async Task<bool> CheckIfElligible(Guid id)
        {
            //Get Donations made in the last year
            IEnumerable<Donation> history = (await GetDonorHistory(id)).
                Where(d => (DateTime.Now - d.DonationDate).Days < 365);
            if (history.Count() == 0) return true;

            if ((DateTime.Now - history.Last().DonationDate).Days <= 56) return false;

            if (history.Count() >= 5) return false;// We avoid a DB query whether it's male or female.
            else //if male he's elligible. If female we check again
            {
                Donor donor = await _donorRepository.GetDonorAsync(id);
                if (donor.Gender.ToLower() == "f" && history.Count() >= 3) return false;
            }
            return true;
        }

        public async Task<ActionResult<Donor>> DonorRegister(RegisterInformation info)
        {
            //Password Hashing
            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: info.Password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            Donor donor = new Donor()
            {
                FirstName = info.FirstName,
                LastName = info.LastName,
                BloodType = info.BloodType,
                City = info.City,
                Gender = info.Gender,
                DateOfBirth = info.DateOfBirth,
            };
            LoginDetails loginDetails = new LoginDetails()
            {
                Email = info.Email,
                Password = hashed

            };
            await _donorRepository.DonorRegister(donor);
            return donor;
        }


        public bool Authorize(ClaimsIdentity identity, string? type)
        {
            try
            {
                var claim = identity.FindFirst(type).Value;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CallToAction(string bloodTypeNeeded, string hospital, string county)
        {
            //Get matching donors' emails
            var emails = _donorRepository.GetDonorEmails(county);

            InternetAddressList recipientsList = new InternetAddressList();
            foreach(var email in emails)
                recipientsList.Add(new MailboxAddress(email));

            //Create email
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(CustomConstants.AppName, CustomConstants.EmailFrom));
            message.To.AddRange(recipientsList);
            message.Subject = CustomConstants.Subject;
            message.Body = new TextPart("plain")
            {
                Text = $"Hello!\n At the {hospital} hospital in {county} county there is a need of " +
                $"{bloodTypeNeeded} blood type."
            };
            //Send
            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect(CustomConstants.Host, CustomConstants.Port, false);

                client.Authenticate(CustomConstants.EmailFrom, CustomConstants.Password);

                client.Send(message);
                client.Disconnect(true);
            }
            return true;
        }
    }

}
