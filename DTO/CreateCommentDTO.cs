using Blog.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Blog.DTO
{
	public class CreateCommentDTO
	{
		[Required]
		[StringLength(100)]
		public string CommenterName { get; set; }

		[Required(ErrorMessage = "Content is required.")]
		[MaxLength(1000, ErrorMessage = "Content cannot exceed 1000 characters.")]
		public string Content { get; set; }

		[Required]
		public int ArticleId { get; set; }
	}
}
