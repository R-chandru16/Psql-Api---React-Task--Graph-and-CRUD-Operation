using ApiForSmallProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForSmallProject.Services
{
    public interface IAdminTokenService
    {
        public string CreateAdminToken(AdminDTO adminDTO);
    }
}
