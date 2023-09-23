using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog.Models
{
	public class AppDBContext : IdentityDbContext<ApplicationUser>
	{
		public AppDBContext() { }

		public AppDBContext(DbContextOptions options) : base(options) { }

		public DbSet<Article> Articles { get; set; }

		public DbSet<Comment> Comments { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			// Define roles
			builder.Entity<IdentityRole>().HasData(
				new IdentityRole
				{
					Id = "1",
					Name = "Blogger",
					NormalizedName = "BLOGGER"
				},
				new IdentityRole
				{
					Id = "2",
					Name = "Reader",
					NormalizedName = "READER"
				}
			);

			// Create a default blogger user and assign to the "Blogger" role
			var hasher = new PasswordHasher<ApplicationUser>();
			builder.Entity<ApplicationUser>().HasData(new ApplicationUser
			{
				Id = "1",
				UserName = "blogger",
				NormalizedUserName = "BLOGGER",
				Email = "blogger@example.com",
				NormalizedEmail = "BLOGGER@EXAMPLE.COM",
				EmailConfirmed = true,
				PasswordHash = hasher.HashPassword(null, "ATemporaryPassword"),
				SecurityStamp = string.Empty,
				FullName = "A Great Blogger",
				Bio = "Bio"
			});

			// Assign the default blogger user to the "Blogger" role
			builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
			{
				RoleId = "1", // RoleId for "Blogger"
				UserId = "1"   // UserId of the default blogger user
			});
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			var Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
			var connectionString = Configuration.GetConnectionString("local");
			optionsBuilder.UseSqlServer(connectionString);
		}
	}
}
