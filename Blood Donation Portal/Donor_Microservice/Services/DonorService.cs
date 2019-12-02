using Donor_Microservice.Persistence.IRepositories;
using Hospital_Microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

    }
}
