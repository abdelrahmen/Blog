using System.ComponentModel.DataAnnotations;

namespace Blog.DTO
{
    public class LoginDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email {  get; set; }
		[Required]
		public string Password { get; set; }
    }
}