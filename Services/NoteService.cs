using EasyXNoteDataAccessAPI.Data;
using EasyXNoteDataAccessAPI.Models;
using System;
using System.Collections.Generic;

namespace EasyXNoteDataAccessAPI.Services
{
    public class NoteService
    {
        private readonly NoteRepository noteRepository;

        public NoteService()
        {
            noteRepository = new NoteRepository();
        }

        public object GetAllNotes()
        {
            return noteRepository.GetAllNotes();
        }
    }

}

