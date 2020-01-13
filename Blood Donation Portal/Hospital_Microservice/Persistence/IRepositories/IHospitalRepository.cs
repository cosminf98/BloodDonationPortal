using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital_Microservice.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Microservice.Repositories
{
    public interface IHospitalRepository
    {
        Task<IEnumerable<Hospital>> GetHospitalsAsync();
        Task<IEnumerable<Hospital>> GetHospitalsByCityOrCountyAsync(string cityOrCounty);
        Task<ActionResult<Hospital>> HospitalRegister(Hospital hospital);
        Task<Hospital> GetHospitalById(Guid id);
        Task<IEnumerable<Schedule>> PatchSchedules(string email, JsonPatchDocument<Hospital> patchHospitalProgram);



    }
}
