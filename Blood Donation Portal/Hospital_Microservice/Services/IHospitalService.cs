using Hospital_Microservice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hospital_Microservice.Services
{
    public interface IHospitalService
    {
        Task<IEnumerable<Hospital>> GetHospitalsAsync();
        Task<IEnumerable<Hospital>> GetHospitalsByCityOrCountyAsync(string cityOrCounty);
        Task<ActionResult<Hospital>> HospitalRegister(RegisterInformation info);
        bool Authorize2(ClaimsIdentity identity, string type);

    }
}
