using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Blog.Models
{
	public class Article
	{
		[Key]
		public int ArticleId { get; set; }

		[Required(ErrorMessage = "Title is required.")]
		[StringLength(255, MinimumLength = 5, ErrorMessage = "Title must be between 5 and 255 characters.")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Content is required.")]
		[MaxLength(5000, ErrorMessage = "Content cannot exceed 5000 characters.")]
		public string Content { get; set; }

		[DataType(DataType.DateTime)]
		[DefaultValue(typeof(DateTime), "")]
		public DateTime CreatedAt { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime UpdatedAt { get; set; }

		[ForeignKey("Blogger")]
		public string BloggerId { get; set; }
		public ApplicationUser Blogger { get; set; }

		// Navigation property for comments related to this article
		public ICollection<Comment> Comments { get; set; }
	}
}
