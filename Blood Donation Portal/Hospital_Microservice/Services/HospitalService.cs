using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Hospital_Microservice.Models;
using Hospital_Microservice.Repositories;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.JsonPatch;
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

        public async Task<IEnumerable<Hospital>> GetHospitalsByCityOrCountyAsync(string cityOrCounty)
        {
            return await _hospitalRepository.GetHospitalsByCityOrCountyAsync(cityOrCounty);
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
           // hospital.Schedules.Add(schedule);
            await _hospitalRepository.HospitalRegister(hospital);
            return hospital;
        }
        public bool Authorize2(ClaimsIdentity identity, string type)
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

        public Task<Hospital> GetHospitalById(Guid id)
        {
            return _hospitalRepository.GetHospitalById(id);
        }

        public async Task<IEnumerable<Schedule>> PatchSchedules(string email, JsonPatchDocument<Hospital> patchHospitalProgram)
        {
            return await _hospitalRepository.PatchSchedules(email, patchHospitalProgram);
        }
    }
}
