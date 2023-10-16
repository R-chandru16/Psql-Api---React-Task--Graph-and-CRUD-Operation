﻿using ApiForSmallProject.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApiForSmallProject.Services
{

    public class AdminTokenServices : IAdminTokenService
    {
        private readonly SymmetricSecurityKey _key;

        public AdminTokenServices(IConfiguration configuration)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
        }

     
        public string CreateToken(AdminDTO adminDTO)
        {
            //Calim
            var claims = new List<Claim>
          {
              new Claim(JwtRegisteredClaimNames.NameId,adminDTO.email)
          };
            //Credential
            var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            //Token Description
            var tokenDesc = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = cred
            };
            //Generate token
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDesc);
            return tokenHandler.WriteToken(token);
        }
        public string CreateAdminToken(AdminDTO adminDTO)
        {//Calim
            var claims = new List<Claim>
          {
              new Claim(JwtRegisteredClaimNames.NameId,adminDTO.email)
          };
            //Credential
            var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            //Token Description
            var tokenDesc = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = cred
            };
            //Generate token
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDesc);
            return tokenHandler.WriteToken(token);
        }

    }
}

