using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Hospital_Microservice.Models;
using Hospital_Microservice.Repositories;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Microservice.Services
{
    public class HospitalService : IHospitalService
    {
        readonly IHospitalRepository _hospitalRepository;
        public HospitalService(IHospitalRepository hospitalRepository)
        {
            this._hospitalRepository = hospitalRepository;
        }

        public async Task<IEnumerable<Hospital>> GetHospitalsAsync()
        {
            return await _hospitalRepository.GetHospitalsAsync();
        }

        public async Task<IEnumerable<Hospital>> GetHospitalsByCityAsync(string city)
        {
            return await _hospitalRepository.GetHospitalsByCityAsync(city);
        }
        public async Task<ActionResult<Hospital>> HospitalRegister(RegisterInformation info)
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

            Hospital hospital = new Hospital()
            {
                Name = info.Name,
                City = info.City,
                County = info.County,
                Address = info.Address,
                PhoneNumber = info.PhoneNumber
            };
            LoginDetails login = new LoginDetails()
            {
                Email = info.Email,
                Password = hashed
            };
           /* Schedule schedule = new Schedule()
            {
                DayOfWeek = info.DayOfWeek,
                IsOpen = info.IsOpen,
                OpenFrom = info.OpenFrom,
                OpenUntil = info.OpenUntil
            };*/
            hospital.LoginDetails = login;
           // hospital.Schedules.Add(schedule);
            await _hospitalRepository.HospitalRegister(hospital);
            return hospital;
        }
    }
}
