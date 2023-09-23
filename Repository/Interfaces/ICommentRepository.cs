using Blog.Models;

namespace Blog.Repository.Interfaces
{
	public interface ICommentRepository
	{
		Task<IEnumerable<Comment>> GetAllCommentsAsync();
		Task<Comment> GetCommentByIdAsync(int commentId);
		Task<IEnumerable<Comment>> GetCommentsByArticleIdAsync(int articleId);
		Task CreateCommentAsync(Comment comment);
		Task UpdateCommentAsync(Comment comment);
		Task DeleteCommentAsync(int commentId);
	}
}
