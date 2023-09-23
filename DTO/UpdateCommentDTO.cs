using System.ComponentModel.DataAnnotations;

namespace Blog.DTO
{
	public class UpdateCommentDTO
	{
		[Required]
		public int CommentId { get; set; }

		[Required(ErrorMessage = "Content is required.")]
		[MaxLength(1000, ErrorMessage = "Content cannot exceed 1000 characters.")]
		public string Content { get; set; }
	}
}