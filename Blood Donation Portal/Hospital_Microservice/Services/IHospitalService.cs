using Hospital_Microservice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital_Microservice.Services
{
    public interface IHospitalService
    {
        Task<IEnumerable<Hospital>> GetHospitalsAsync();
        Task<IEnumerable<Hospital>> GetHospitalsByCityAsync(string city);
        Task<ActionResult<Hospital>> HospitalRegister(RegisterInformation info);

    }
}
