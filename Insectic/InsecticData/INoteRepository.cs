using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Insectic.Models;
using Microsoft.AspNetCore.Mvc;

namespace Insectic.InsecticData
{
    public interface INoteRepository
    {
        public Task<List<Note>>? GetAllNotesAsync();

        public Task<Note?> GetNoteAsyn(int ticketId);

        public Task<string> NewNoteAsync(Note ticket);

        public void DeleteNoteAsync(int ticketId);
    }
}
