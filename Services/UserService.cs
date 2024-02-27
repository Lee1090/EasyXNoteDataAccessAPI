using EasyXNoteDataAccessAPI.Data;
using EasyXNoteDataAccessAPI.Models;
using System;
using System.Collections.Generic;

namespace EasyXNoteDataAccessAPI.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly UserProfileRepository _userProfileRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
            _userProfileRepository = new UserProfileRepository();
        }

        public object GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
        public object GetAllUserProfiles()
        {
            return _userProfileRepository.GetAllUserProfiles();
        }

        public void InsertUser(User user)
        {
            _userRepository.InsertUser(user);
        }
        /*
        public IEnumerable<User> GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }
        */
    }

}

