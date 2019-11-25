using Hospital_Microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donor_Microservice.Services
{
    public interface IDonorService
    {
        Task<IEnumerable<Hospital>> GetNearbyHospitalsAsync(string city);
    }
}
