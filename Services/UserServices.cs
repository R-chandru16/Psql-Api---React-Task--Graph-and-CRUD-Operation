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
    public class UserServices
    {
        private readonly UserContext _context;
        private readonly ITokenService _tokenService;

        //public UserService(ITokenService tokenService)
        //{
        //    _tokenService = tokenService;
        //}


        //The UserServices class has a constructor that takes two parameters: UserContext and ITokenService
        // These parameters are injected into the class through dependency injection, allowing it to access the database context and token service.
        public UserServices(UserContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public UserDTO Register(UserDTO userDto)
        {
            try
            {// hash->HMACSHA512
             // HMACSHA512 for securely hashing the user's password.
             //The user is added to the database through _context.users.Add(user) and saved using _context.SaveChanges().
              //  A JWT token is generated for the registered user using _tokenService.CreateToken(userDto) and stored in userDto.jwtToken.
              //  Finally, the password in userDto is cleared for security reasons before returning the userDto object.
                using var hmac = new HMACSHA512();
                var user = new User()
                {


                    id = userDto.id,
                    name= userDto.name,
                    email=userDto.email,
                    password = userDto.password,
                    department = userDto.department,
                    role = userDto.role,
                    status = userDto.status,
                   
               


                 

                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.password)),
                    PasswordSalt = hmac.Key


                };
                _context.users.Add(user);
                _context.SaveChanges();
                userDto.jwtToken = _tokenService.CreateToken(userDto);
                userDto.password = "";
                return userDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public UserDTO Login(UserDTO userDto)
        {
            try
            {
                //Single() expects one and only one element in the collection.
                //   Single() throws an exception when it gets no element or more than one elements in the collection.
                
                var myUser = _context.users.SingleOrDefault(u => u.email == userDto.email);
                if (myUser != null)
                {
                    using var hmac = new HMACSHA512(myUser.PasswordSalt);
                    var userPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.password));

                    for (int i = 0; i < userPassword.Length; i++)
                    {
                        if (userPassword[i] != myUser.PasswordHash[i])
                            return null;
                    }
                    userDto.jwtToken = _tokenService.CreateToken(userDto);
                    userDto.password = "";
                    return userDto;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
      
        public bool DeleteUser(UserDTO userDto)
        {
            try
            {
                // Find the user by their unique identifier (e.g., Id) in the database
                var userToDelete = _context.users.SingleOrDefault(u => u.id==u.id);

                if (userToDelete != null)
                {
                    // Remove the user from the database
                    _context.users.Remove(userToDelete);
                    _context.SaveChanges();
                    return true; // Return true if the user is successfully deleted.
                }

                return false; // Return false if the user with the given ID is not found.
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false; // Return false in case of an exception or error.
            }
        }

    }
}