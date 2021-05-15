using Microsoft.AspNetCore.Mvc;
using Insectic.Models;
using InsecticDatabaseApi.InsecticData;

namespace InsecticDatabaseApi.Controllers
{
    [ApiController]
    public class NotesController : Controller
    {
        private readonly INoteData _noteData;
        public NotesController(INoteData note)
        {
            _noteData = note;
        }

        //https://port4332/api/Notes
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAllNotes()
        {
            return Ok(_noteData.GetAllNotes());
        }

        [HttpGet]
        [Route("api/[controller]/{userId}")]
        public IActionResult GetUserNotes(string userId)
        {
            return Ok(_noteData.GetUsersNotes(userId));
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddNote(Note newNote)
        {
            _noteData.AddNote(newNote);
            return Ok();

        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteNote(int id)
        {
            _noteData.DeleteNote(id);
            return Ok();
        }

    }
}
