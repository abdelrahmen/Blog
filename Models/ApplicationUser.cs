using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
	public class ApplicationUser: IdentityUser
	{
		[Required]
		[MaxLength(100)]
		[DataType("VARCHAR(100)")]
		public string FullName { get; set; }
		public string Bio { get; internal set; }
	}
}