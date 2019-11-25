using Admin_Microservice.Persistence.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin_Microservice.Service
{
    public class AdminService : IAdminService
    {
        readonly IAdminRepository _adminRepository;
        public AdminService(IAdminRepository adminRepository)
        {
            this._adminRepository = adminRepository;
        }
    }
}
