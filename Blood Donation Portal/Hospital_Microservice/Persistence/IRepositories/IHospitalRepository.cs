using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital_Microservice.Models;

namespace Hospital_Microservice.Repositories
{
    public interface IHospitalRepository
    {
        Task<IEnumerable<Hospital>> GetHospitalsAsync();
        Task<IEnumerable<Hospital>> GetHospitalsByCityAsync(string city);
    }
}
