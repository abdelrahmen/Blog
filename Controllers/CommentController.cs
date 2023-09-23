using Blog.DTO;
using Blog.Models;
using Blog.Repository;
using Blog.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class CommentController : ControllerBase
	{
		private readonly ICommentRepository commentRepository;

		public CommentController(ICommentRepository commentRepository)
		{
			this.commentRepository = commentRepository;
		}

		// GET: api/comment
		[HttpGet]
		[Authorize(Roles ="Blogger")]
		public async Task<IActionResult> GetAllComments()
		{
			var comments = await commentRepository.GetAllCommentsAsync();
			return Ok(comments);
		}

		// GET: api/comment/1 (replace 1 with the comment ID)
		[HttpGet("{id}")]
		public async Task<IActionResult> GetComment(int id)
		{
			var comment = await commentRepository.GetCommentByIdAsync(id);
			if (comment == null)
			{
				return NotFound(); 
			}
			return Ok(comment);
		}

		[HttpPost]
		public async Task<IActionResult> CreateComment([FromBody] CreateCommentDTO commentDTO)
		{
			if (commentDTO == null)
			{
				return BadRequest(); // Invalid input data
			}
            if (!ModelState.IsValid)
            {
				return BadRequest(ModelState);
            }

			var comment = new Comment
			{
				ArticleId = commentDTO.ArticleId,
				BloggerId = "1",
				UpdatedAt = DateTime.Now,
				CreatedAt = DateTime.Now,
				CommenterName = commentDTO.CommenterName,
				Content = commentDTO.Content,
			};
			try
			{
				await commentRepository.CreateCommentAsync(comment);
			}catch (Exception ex)
			{
				return BadRequest("an error occured, please try again later");
			}
			return CreatedAtAction(nameof(GetComment), new { id = comment.CommentId }, comment);
		}

		// PUT: api/comment/1 (replace 1 with the comment ID)
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateComment(int id, [FromBody] UpdateCommentDTO commentDTO)
		{
			if (commentDTO == null || id != commentDTO.CommentId)
			{
				return BadRequest(); // Invalid input data or mismatched IDs
			}

			var existingComment = await commentRepository.GetCommentByIdAsync(id);
			if (existingComment == null)
			{
				return NotFound(); 
			}

            if (!ModelState.IsValid)
            {
				return BadRequest(ModelState);
			}

			existingComment.Content = commentDTO.Content;

            await commentRepository.UpdateCommentAsync(existingComment);
			return NoContent(); // Successfully updated
		}

		// DELETE: api/comment/1 (replace 1 with the comment ID)
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteComment(int id)
		{
			var existingComment = await commentRepository.GetCommentByIdAsync(id);
			if (existingComment == null)
			{
				return NotFound(); 
			}

			await commentRepository.DeleteCommentAsync(id);
			return NoContent(); // Successfully deleted
		}
	}
}
