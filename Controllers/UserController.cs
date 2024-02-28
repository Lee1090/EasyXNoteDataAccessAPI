using EasyXNoteDataAccessAPI.Models;
using EasyXNoteDataAccessAPI.Services;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace EasyXNoteDataAccessAPI.Controllers
{
    public class UserController : ApiController
    {
        private readonly UserService _userService;   // Dependency injection
        private readonly CommonService _commonService;

        public UserController()
        {
            _userService = new UserService();
            _commonService = new CommonService();
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
            else
            {
                object resObj = _userService.InsertUser(user);
                //bool success = (bool)resObj.GetType().GetProperty("success").GetValue(resObj);
                bool success = _commonService.GetSuccessValue(resObj);
                if (success)
                {
                    string message = _commonService.GetMessageValue(resObj);
                    return Ok(message);
                }
                else
                {
                    string message = _commonService.GetErrorMessage(resObj);
                    return BadRequest(message);
                }
            }
        }

        /*
        public IEnumerable<User> Get()
        {
            return userService.GetAllUsers();
        }
        */
    }

}



