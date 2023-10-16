using ApiForSmallProject.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiForSmallProject.Services;
using System.Reflection.Metadata;


namespace ApiForSmallProject.Controllers
{
    using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]

    public class UserController : ControllerBase
      //  The UserController class has a constructor that takes an instance
      //  of UserServices as a parameter.
      //  This parameter is injected into the class through dependency injection,
      //  allowing the controller to use the UserServices to handle user-related operations.
    {
        private readonly UserServices _service;
    public UserController(UserServices userSevice)
    {
        _service = userSevice;
    }

    // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return null;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return null;
        }

        // POST api/<UserController>
        [Route("Register")]
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post([FromBody] UserDTO user)
        {
            var userDTO = _service.Register(user);
            if (userDTO != null)
                return userDTO;
            return BadRequest("Not able to register");
        }

        // PUT api/<UserController>/5
        //[HttpPut("{id}")]

        [Route("Login")]  //(so to avoid confusion/ambiquity here we saying add "login" to the url) here url shows as  api/user/login  this is called attribute based routing.
        [HttpPost]    //here 2nd post 
        public async Task<ActionResult<UserDTO>> Put([FromBody] UserDTO user)
        {

            var userDTO = _service.Login(user);
            if (userDTO != null)
                return Ok(userDTO);
            return BadRequest("Not able to register");
        }



        // DELETE api/<UserController>/5

        // DELETE api/<UserController>
     
        [HttpDelete("{id}")]
        public IActionResult Delete([FromBody] UserDTO userDto)
        {
            try
            {
                bool deleted = _service.DeleteUser(userDto);

                if (deleted)
                {
                    return NoContent(); // Return a 204 No Content response if the user is successfully deleted.
                }

                return NotFound(); // Return a 404 Not Found response if the user with the given ID is not found.
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, $"Internal Server Error: {e.Message}");
            }
        }

    }


}

