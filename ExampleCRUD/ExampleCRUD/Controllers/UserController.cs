using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace ExampleCRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserDAO dao;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
            dao = new UserDAO();
        }

        [HttpGet("Login/{email}/{password}")]

        public IActionResult Login(string email, string password){

            var user = new User(){
                Email = email,
                Password = password
            };

            user = dao.Login(user);
            if(user == null)
                   return NotFound(new { Message= $"El usuario {email}, no ha sido encontrado" });
              
            return Ok(user);

        }



        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] User user){

           user = dao.CreateUser(user);

            return Ok(user);
        }

        [HttpPost("UpdateUser")]
        //[HttpPut("UpdateUser")]
        public IActionResult UpdateUser([FromBody] User user){

            bool isUpdated = dao.UpdateUser(user);

            return Ok(new { IsUpdated = isUpdated });
        }

        [HttpPost("DeleteUser/{id}")]
        // [HttpDelete("DeleteUser/{id}")]

        public IActionResult DeleteUser(int id){

            var isDeleted = dao.DeleteUser(id);

            return Ok(new {IsDeleted = isDeleted});
        }

    }
}
