using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForSmallProject.Models
{
    public class User
    {
        [Key]
      
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        //[Key]: This attribute is applied to the id property.
        //serves as the primary key for the User entity.
        //In a database context,
        //this attribute is often used with an Object-Relational Mapping (ORM) framework like Entity Framework Core to specify the primary key of a table.

        public int id { get; set; }
        public string name { get; set; }
        public string department { get; set; }
        public string email{ get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string status { get; set; }





        //PasswordHash and PasswordSalt, are present in the User class. These properties are likely used for storing the hashed password and a salt value for security purposes.
        //Hashing and salting passwords are standard practices to enhance password security by protecting them from unauthorized access.

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

    }

}

