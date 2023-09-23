using Blog.Models;
using Blog.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repository
{
	public class CommentRepository: ICommentRepository
	{
		private readonly AppDBContext context;

		public CommentRepository(AppDBContext context)
		{
			this.context = context;
		}

		public async Task<IEnumerable<Comment>> GetAllCommentsAsync()
		{
			return await context.Comments.ToListAsync();
		}

		public async Task<Comment> GetCommentByIdAsync(int commentId)
		{
			return await context.Comments.FindAsync(commentId);
		}

		public async Task<IEnumerable<Comment>> GetCommentsByArticleIdAsync(int articleId)
		{
			return await context.Comments
				.Where(comment => comment.ArticleId == articleId)
				.ToListAsync();
		}

		public async Task CreateCommentAsync(Comment comment)
		{
			context.Comments.Add(comment);
			await context.SaveChangesAsync();
		}

		public async Task UpdateCommentAsync(Comment comment)
		{
			context.Comments.Update(comment);
			await context.SaveChangesAsync();
		}

		public async Task DeleteCommentAsync(int commentId)
		{
			var commentToDelete = await context.Comments.FindAsync(commentId);
			if (commentToDelete != null)
			{
				context.Comments.Remove(commentToDelete);
				await context.SaveChangesAsync();
			}
		}
	}
}
