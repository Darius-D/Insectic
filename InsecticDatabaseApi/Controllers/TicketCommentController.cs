using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsecticDatabaseApi.InsecticData;
using InsecticDatabaseApi.Models;

namespace InsecticDatabaseApi.Controllers
{
    
    [ApiController]
    public class TicketCommentController : ControllerBase
    {
        private ICommentData _commentData;
        public TicketCommentController(ICommentData comment)
        {
            _commentData = comment;
        }



        /// <summary>
        /// Returns all Comments in the Db.
        /// </summary>
        /// <returns>List of type Comment</returns>
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAllComments()
        {
            return Ok(_commentData.GetAllComments());
        }




        /// <summary>
        /// Returns all Comments assigned to a ticket  by ticket Guid.
        /// </summary>
        /// <param name="id">Guid of the user wanting to pull</param>
        /// <returns>a single Ticket object</returns>
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetTicketComments(Guid id)
        {
            var commentList = _commentData.GetAllCommentsForTicket(id);
            if (commentList != null)
            {
                return Ok(commentList);
            }

            return NotFound($"Comments associated with Guid of Ticket Guid of {id} do not exist");
        }

        //Todo change route
        [HttpGet]
        [Route("apidoub/[controller]/{userId}")]
        public IActionResult GetTicketCommentsForUser(string userId)
        {
            var commentList = _commentData.GetUserComments(userId);
            if (commentList != null)
            {
                return Ok(commentList);
            }

            return NotFound($"Comments associated with user Id of {userId} do not exist");
        }


        //These two will block one out TODO://

        /// <summary>
        /// Returns a single comment by comment Guid
        /// </summary>
        /// <param name="id">the Comment Guid</param>
        /// <returns>a single Comment object</returns>
        [HttpGet]
        [Route("apiSingle/[controller]/{id}")]
        public IActionResult GetComment(Guid id)
        {
            var comment = _commentData.GetComment(id);
            if (comment != null)
            {
                return Ok(comment);
            }

            return NotFound($"Comments associated with Guid of {id} does not exist");
        }



        /// <summary>
        /// Adds a comment and associates it with the ticket. 
        /// </summary>
        /// <param name="newComment"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/[controller]/{id}")]
        public IActionResult AddComment(TicketComment newComment, Guid id)
        {
            _commentData.AddComment(id, newComment);
            return Ok($"Comment has been added to ticket with Guid of {id}");

        }



        /// <summary>
        ///  Deletes a comment; Reserved for Admin only
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteComment(Guid id)
        {
            if (_commentData.GetComment(id) != null)
            {
                _commentData.DeleteComment(id);
                return Ok("comment Deleted");
            }

            return NotFound($"Comment with Guid of {id} does not exist");

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditTicket(Guid id, TicketComment comment)
        {
            TicketComment existingComment = _commentData.GetComment(id);

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
