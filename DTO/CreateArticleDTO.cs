using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Blog.DTO
{
	public class CreateArticleDTO
	{
		[Required(ErrorMessage = "Title is required.")]
		[StringLength(255, MinimumLength = 5, ErrorMessage = "Title must be between 5 and 255 characters.")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Content is required.")]
		[MaxLength(5000, ErrorMessage = "Content cannot exceed 5000 characters.")]
		public string Content { get; set; }

	}
}
