using EasyXNoteDataAccessAPI.Models;
using System;

namespace EasyXNoteDataAccessAPI.Models
{
    public class Note
    {
        public int NoteID { get; set; }
        public int UserID { get; set; }
        public int NoteBookID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
