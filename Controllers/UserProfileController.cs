using EasyXNoteDataAccessAPI.Models;
using EasyXNoteDataAccessAPI.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace EasyXNoteDataAccessAPI.Controllers
{
    public class UserProfileController : ApiController
    {
        private readonly UserService userService;   // Dependency injection


        public UserProfileController()
        {
            userService = new UserService();
        }

        [HttpGet]
        public object Get()
        {
            return userService.GetAllUserProfiles();
        }
    }

}



