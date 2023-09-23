using Blog.Models;
using Blog.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repository
{
	public class ArticleRepository : IArticleRepository
	{
		private readonly AppDBContext context;

		public ArticleRepository(AppDBContext context)
		{
			this.context = context;
		}

		public async Task CreateArticleAsync(Article article)
		{
			context.Articles.Add(article);
			await context.SaveChangesAsync();
		}


		public async Task DeleteArticleAsync(int articleId)
		{
			var articleToDelete = await context.Articles.FindAsync(articleId);
			if (articleToDelete != null)
			{
				context.Articles.Remove(articleToDelete);
				await context.SaveChangesAsync();
			}
		}


		public async Task<IEnumerable<Article>> GetAllArticlesAsync()
		{
			return await context.Articles.ToListAsync();
		}


		public async Task<Article> GetArticleByIdAsync(int articleId)
		{
			return await context.Articles.FindAsync(articleId);
		}


		public async Task UpdateArticleAsync(Article article)
		{
			context.Articles.Update(article);
			await context.SaveChangesAsync();
		}

	}
}
