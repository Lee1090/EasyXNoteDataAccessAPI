using EasyXNoteDataAccessAPI.Models;
using EasyXNoteDataAccessAPI.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace EasyXNoteDataAccessAPI.Controllers
{
    public class NoteController : ApiController
    {
        private readonly NoteService noteService;   // Dependency injection


        public NoteController()
        {
            noteService = new NoteService();
        }

        [HttpGet]
        public object Get()
        {
            return noteService.GetAllNotes();
        }
    }

}



