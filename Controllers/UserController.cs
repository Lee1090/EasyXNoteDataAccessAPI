using EasyXNoteDataAccessAPI.Models;
using EasyXNoteDataAccessAPI.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace EasyXNoteDataAccessAPI.Controllers
{
    public class UserController : ApiController
    {
        private readonly UserService userService;   // Dependency injection


        public UserController()
        {
            userService = new UserService();
        }

        [HttpGet]
        public object Get()
        {
            return userService.GetAllUsers();
        }
        /*
        public IEnumerable<User> Get()
        {
            return userService.GetAllUsers();
        }
        */
    }

}



