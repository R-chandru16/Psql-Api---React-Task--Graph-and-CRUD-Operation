using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForSmallProject.Models
{
    public class UserDTO {


        // DTOs for passing the data from one layer to another
        public int id { get; set; }
      
        public string name { get; set; }
        public string department { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string status { get; set; }
       

        public string jwtToken { get; set; }

    }
}
