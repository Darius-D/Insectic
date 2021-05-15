using System.Collections.Generic;
using System.Linq;
using Insectic.Models;
using InsecticDatabaseApi.Models;

namespace InsecticDatabaseApi.InsecticData
{
    public class NoteData : INoteData
    {
        private readonly InsecticContext _insecticContext;

        public NoteData(InsecticContext insecticContext)
        {
            _insecticContext = insecticContext;
        }

        public List<Note> GetAllNotes()
        {
            return _insecticContext.Notes.ToList();
        }

        public List<Note> GetUsersNotes(string userId)
        {
            var userNotes = _insecticContext.Notes.Where(t => t.UserId == userId).ToList();
            return userNotes;
        }


        public void AddNote(Note note)
        {
            _insecticContext.Notes.Add(note);
            _insecticContext.SaveChanges();
        }


        public void DeleteNote(int noteId)
        {
            var existingTicket = _insecticContext.Tickets.Find(noteId);

            _insecticContext.Tickets.Remove(existingTicket);
            _insecticContext.SaveChanges();
        }


       
    }
}
