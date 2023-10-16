using ApiForSmallProject.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ApiForSmallProject.Services
{
    public class AdminServices
    {
        private readonly UserContext _context;

        private readonly IAdminTokenService _AdtokenService;

        //public UserService(ITokenService tokenService)
        //{
        //    _tokenService = tokenService;
        //}
        public AdminServices(UserContext context, IAdminTokenService admintokenService)
        {
            _context = context;
            _AdtokenService = admintokenService;
        }

        public AdminDTO Register(AdminDTO adminDto)
        {
            try
            {
                using var hmac = new HMACSHA512();
                var admin = new Admin()
                {


                    id = adminDto.id,
                    name = adminDto.name,
                    email = adminDto.email,
                    password = adminDto.password,
                    department = adminDto.department,
                    role = adminDto.role,
                    status = adminDto.status,






                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(adminDto.password)),
                    PasswordSalt = hmac.Key


                };
                _context.admins.Add(admin);
                _context.SaveChanges();
                adminDto.jwtToken = _AdtokenService.CreateAdminToken(adminDto);
                adminDto.password = "";
                return adminDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public AdminDTO Login(AdminDTO adminDto)
        {
            try
            {
                //Single() expects one and only one element in the collection.
                //   Single() throws an exception when it gets no element or more than one elements in the collection.
                //
                var myAdmin = _context.admins.SingleOrDefault(u => u.email== adminDto.email);
                if (myAdmin != null)
                {
                    using var hmac = new HMACSHA512(myAdmin.PasswordSalt);
                    var adminPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(adminDto.password));

                    for (int i = 0; i < adminPassword.Length; i++)
                    {
                        if (adminPassword[i] != myAdmin.PasswordHash[i])
                            return null;
                    }
                    adminDto.jwtToken = _AdtokenService.CreateAdminToken(adminDto);
                    adminDto.password = "";
                    return adminDto;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

     
    }
}