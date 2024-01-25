using EasyXNoteDataAccessAPI.Models;
using System;

namespace EasyXNoteDataAccessAPI.Models
{
    public class UserProfile
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}