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
        static HttpClient client = new HttpClient();

        public DonorService(IDonorRepository donorRepository)
        {
            this._donorRepository = donorRepository;
            SetClient();
        }

        public void SetClient()
        {
            //PORT for Hospital Microservice.
            //(?) take it from launchsettings
            var PORT = 44329; 
            client.BaseAddress = new Uri($"https://localhost:{PORT}/api");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Hospital>> GetNearbyHospitalsAsync(string city)
        {/*
            InvalidOperationException: An invalid request URI was provided. The request URI must either be an absolute URI or BaseAddress must be set.
            */
            IEnumerable<Hospital> hospitals = new List<Hospital>();
            //https://localhost:44329/api/hospitals/iasi
            
            HttpResponseMessage response = await client.GetAsync($"{client.BaseAddress.AbsoluteUri}/hospitals/{city}");
            if (response.IsSuccessStatusCode)
            {
                hospitals = await response.Content.ReadAsAsync<IEnumerable<Hospital>>();
            }
            return hospitals;
        }
    }
}
