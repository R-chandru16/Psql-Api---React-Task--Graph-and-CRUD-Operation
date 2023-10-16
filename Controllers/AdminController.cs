using ApiForSmallProject.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiForSmallProject.Services;


namespace ApiForSmallProject.Controllers
{
    using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
   // [EnableCors("MyPolicy")]: This attribute enables Cross-Origin Resource Sharing(CORS)
   // for this controller.It allows the controller's actions to be accessed from different origins
   // based on the CORS policy named "MyPolicy." CORS is used to handle cross-origin HTTP request
    public class AdminController : ControllerBase
     

//This AdminController class is derived from ControllerBase, which is a base class for controllers in ASP.NET Core Web API.
    {
        private readonly AdminServices _service;

        public AdminController(AdminServices adminSevice)
        {
            _service = adminSevice;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<Admin> Get()
        {
            return null;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public Admin Get(int id)
        {
            return null;
        }

        // POST api/<UserController>
        [Route("Register")]
        [HttpPost]
        public async Task<ActionResult<AdminDTO>> Post([FromBody] AdminDTO admin)
        {
            var adminDTO = _service.Register(admin);
            if (adminDTO != null)
                return adminDTO;
            return BadRequest("Not able to register");
        }

        // PUT api/<UserController>/5
        //[HttpPut("{id}")]

        [Route("Login")]  //(so to avoid confusion/ambiquity here we saying add "login" to the url) here url shows as  api/user/login  this is called attribute based routing.
        [HttpPost]    //here 2nd post 
        public async Task<ActionResult<AdminDTO>> Put([FromBody] AdminDTO admin)
        {

            var adminDTO = _service.Login(admin);
            if (adminDTO != null)
                return Ok(adminDTO);
            return BadRequest("Not able to register");
        }



        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }

    }


}

