using System.ComponentModel.DataAnnotations;

namespace Blog.DTO
{
	public class UpdateArticleDTO
	{
		[Required]
		public int ArticleId { get; set; }

		[Required(ErrorMessage = "Title is required.")]
		[StringLength(255, MinimumLength = 5, ErrorMessage = "Title must be between 5 and 255 characters.")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Content is required.")]
		[MaxLength(5000, ErrorMessage = "Content cannot exceed 5000 characters.")]
		public string Content { get; set; }
	}
}
