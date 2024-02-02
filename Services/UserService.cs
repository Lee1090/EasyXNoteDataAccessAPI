using EasyXNoteDataAccessAPI.Data;
using EasyXNoteDataAccessAPI.Models;
using System;
using System.Collections.Generic;

namespace EasyXNoteDataAccessAPI.Services
{
    public class UserService
    {
        private readonly UserRepository userRepository;
        private readonly UserProfileRepository userProfileRepository;

        public UserService()
        {
            userRepository = new UserRepository();
            userProfileRepository = new UserProfileRepository();
        }

        public object GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }
        public object GetAllUserProfiles()
        {
            return userProfileRepository.GetAllUserProfiles();
        }

        public void InsertUser(User user)
        {
            userRepository.InsertUser(user);
        }
        /*
        public IEnumerable<User> GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }
        */
    }

}

