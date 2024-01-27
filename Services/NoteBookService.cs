using EasyXNoteDataAccessAPI.Data;
using EasyXNoteDataAccessAPI.Models;
using System;
using System.Collections.Generic;

namespace EasyXNoteDataAccessAPI.Services
{
    public class NoteBookService
    {
        private readonly NoteBookRepository noteBookRepository;

        public NoteBookService()
        {
            noteBookRepository = new NoteBookRepository();
        }

        public object GetAllNoteBooks()
        {
            return noteBookRepository.GetAllNoteBooks();
        }
    }

}

