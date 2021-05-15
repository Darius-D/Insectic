using System.Collections.Generic;
using Insectic.Models;


namespace InsecticDatabaseApi.InsecticData
{
    public interface INoteData
    {
        List<Note> GetAllNotes();
        List<Note> GetUsersNotes(string userId);

        void AddNote(Note ticket);

        void DeleteNote(int ticketId);

    }
}
