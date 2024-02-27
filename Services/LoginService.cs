using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EasyXNoteDataAccessAPI.Data;
using EasyXNoteDataAccessAPI.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace EasyXNoteDataAccessAPI.Services
{
    public class LoginService
    {
        private readonly UserRepository _userRepository;
        public LoginService()
        {
            _userRepository = new UserRepository();
        }
        private string HashPassword(string password, string salt)
        {
            // Combine the password and salt, then hash the result
            string combinedPassword = password + salt;

            // Add password hashing logic here (e.g., using a library like BCrypt)
            // Example using BCrypt: return BCrypt.Net.BCrypt.HashPassword(combinedPassword);
            return combinedPassword; // Placeholder, replace with actual hashing logic
        }
        public bool IsValidUser(string userName, string password)
        {
            // 这里是验证用户名密码的逻辑，从数据库中获取该用户的密码salt和hash，将password通过salt和hash处理后与库中的hash值比对
            //  Validating username and password:
            //  retrieves the user's password salt and hash from the database,
            //  processes the password using the salt and hash,
            //  compares the resulting hash with the one stored in the database.
            Object userObj = _userRepository.GetUserByUserName(userName);
            string json = JsonConvert.SerializeObject(userObj);
            JObject jsonObj = JObject.Parse(json);
            bool success = (bool)jsonObj["success"];
            if (success) 
            {
                JToken dataToken = jsonObj["data"];
                User user = dataToken.ToObject<User>();
                string passwordSalt = user.PasswordSalt;
                string passwordHash = user.PasswordHash;
                string passwordHashPost = HashPassword(password, passwordSalt);
                if(passwordHash == passwordHashPost)
                {
                    return true;
                }
            }
            return false;
        }
    }
}