using EasyXNoteDataAccessAPI.Models;
using EasyXNoteDataAccessAPI.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace EasyXNoteDataAccessAPI.Controllers
{
    public class UserController : ApiController
    {
        private readonly UserService _userService;   // Dependency injection


        public UserController()
        {
            _userService = new UserService();
        }

        [HttpGet]
        public object Get()
        {
            return _userService.GetAllUsers();
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid user data");
            }

            _userService.InsertUser(user);
            return Ok("User inserted successfully");
        }

        /*
        public IEnumerable<User> Get()
        {
            return userService.GetAllUsers();
        }
        */
    }

}



