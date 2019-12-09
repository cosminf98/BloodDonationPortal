using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital_Microservice.Models;
using Hospital_Microservice.Repositories;

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
    }
}
