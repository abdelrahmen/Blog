using Blog.DTO;
using Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Blog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly IConfiguration config;

		public AccountController(
			UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager,
			IConfiguration configuration
			)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			this.config = configuration;
		}



		[HttpPost("register")]
		public async Task<IActionResult> Register(RegisterDTO model)
		{
			if (ModelState.IsValid)
			{
				var user = new ApplicationUser
				{
					UserName = model.UserName,
					Email = model.Email,
					FullName = model.FullName,
				};

				var result = await _userManager.CreateAsync(user, model.Password);

				if (result.Succeeded)
				{
					await _userManager.AddToRoleAsync(user, "Reader");
					return Ok("Registration successful");
				}

				return BadRequest(result.Errors);
			}

			return BadRequest(ModelState);
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login(LoginDTO model)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByEmailAsync(model.Email);

				if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
				{
					var token = await GenerateJwtTokenAsync(user);

					return Ok(new { token });
				}

				return Unauthorized("Invalid login attempt.");
			}

			return BadRequest(ModelState);
		}

		[HttpPost("logout")]
		[Authorize]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return Ok("Logout successful");
		}

		private async Task<string> GenerateJwtTokenAsync(ApplicationUser user)
		{
			var claims = new List<Claim>
			{
			new Claim(JwtRegisteredClaimNames.Sub, user.Email),
			new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
			new Claim(ClaimTypes.NameIdentifier, user.Id)
			};
			var roles = await _userManager.GetRolesAsync(user);
			foreach (var role in roles)
			{
				claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
			}

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtKey"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var expires = DateTime.Now.AddDays(Convert.ToDouble(config["JwtExpireDays"]));

			var token = new JwtSecurityToken(
				config["JwtIssuer"],
				config["JwtIssuer"],
				claims,
				expires: expires,
				signingCredentials: creds
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
