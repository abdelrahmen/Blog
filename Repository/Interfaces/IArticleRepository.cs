using Blog.Models;

namespace Blog.Repository.Interfaces
{
	public interface IArticleRepository
	{
		Task<IEnumerable<Article>> GetAllArticlesAsync();
		Task<Article> GetArticleByIdAsync(int articleId);
		Task CreateArticleAsync(Article article);
		Task UpdateArticleAsync(Article article);
		Task DeleteArticleAsync(int articleId);
	}
}
