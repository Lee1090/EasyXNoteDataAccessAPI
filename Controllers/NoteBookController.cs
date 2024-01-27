using EasyXNoteDataAccessAPI.Models;
using EasyXNoteDataAccessAPI.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace EasyXNoteDataAccessAPI.Controllers
{
    public class NoteBookController : ApiController
    {
        private readonly NoteBookService noteBookService;   // Dependency injection


        public NoteBookController()
        {
            noteBookService = new NoteBookService();
        }

        [HttpGet]
        public object Get()
        {
            return noteBookService.GetAllNoteBooks();
        }
    }

}



