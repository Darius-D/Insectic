using Microsoft.AspNetCore.Mvc;
using InsecticDatabaseApi.InsecticData;
using InsecticDatabaseApi.Models;


namespace InsecticDatabaseApi.Controllers
{
    
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentData _commentData;
        public CommentController(ICommentData comment)
        {
            _commentData = comment;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAllComments()
        {
            return Ok(_commentData.GetAllComments());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetComment(int id)
        {
            var comment = _commentData.GetComment(id);
            if (comment != null)
            {
                return Ok(comment);
            }

            return NotFound($"Comments associated with Guid of {id} does not exist");
        }

        [HttpGet]
        [Route("api/[controller]/ForTicket/{ticketId}")]
        public IActionResult GetTicketComments(int ticketId)
        {
            var commentList = _commentData.GetAllCommentsForTicket(ticketId);
            if (commentList != null)
            {
                return Ok(commentList);
            }

            return NotFound($"Comments associated with Guid of Ticket Guid of {ticketId} do not exist");
        }

        
        [HttpGet]
        [Route("api/[controller]/ForUser/{userId}")]
        public IActionResult GetTicketCommentsForUser(string userId)
        {
            var commentList = _commentData.GetUserComments(userId);
            if (commentList != null)
            {
                return Ok(commentList);
            }

            return NotFound($"Comments associated with user Id of {userId} do not exist");
        }


        [HttpPost]
        [Route("api/[controller]/{ticketId}")]
        public IActionResult AddComment(Comment newComment, int ticketId)
        {
            _commentData.AddComment(ticketId, newComment);
            return Ok($"Comment has been added to ticket with Id of {ticketId}");
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteComment(int id)
        {
            if (_commentData.GetComment(id) != null)
            {
                _commentData.DeleteComment(id);
                return Ok("comment Deleted");
            }

            return NotFound($"Comment with Id of {id} does not exist");
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditTicket(int id, Comment comment)
        {
            Comment existingComment = _commentData.GetComment(id);

            if (existingComment != null)
            {
                comment.CommentId = existingComment.CommentId;
                comment.TicketId = existingComment.TicketId;
                comment.UserId = existingComment.UserId;
                
                _commentData.EditComment(comment);
                return Ok();
            }

            return NotFound($"Comment with Guid of {comment.CommentId} does not exist");
        }

    }
}
