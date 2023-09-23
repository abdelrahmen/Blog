using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Blog.Models
{
	public class Comment
	{
		[Key]
		public int CommentId { get; set; }

		[Required]
		[StringLength(100)]
		public string CommenterName { get; set;}

		[Required(ErrorMessage = "Content is required.")]
		[MaxLength(1000, ErrorMessage = "Content cannot exceed 1000 characters.")]
		public string Content { get; set; }

		[DataType(DataType.DateTime)]
		[DefaultValue(typeof(DateTime), "")]
		public DateTime CreatedAt { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime UpdatedAt { get; set; }

		[ForeignKey("Article")]
		public int ArticleId { get; set; }
		public Article Article { get; set; }

		[ForeignKey("Blogger")]
		public string BloggerId { get; set; }
		public ApplicationUser Blogger { get; set; }
	}
}
