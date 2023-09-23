using Blog.DTO;
using Blog.Models;
using Blog.Repository;
using Blog.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Blog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ArticleController : ControllerBase
	{
		private readonly IArticleRepository articleRepository;

		public ArticleController(IArticleRepository articleRepository)
		{
			this.articleRepository = articleRepository;
		}

		// GET: api/article
		[HttpGet]
		public async Task<IActionResult> GetAllArticles()
		{
			var articles = await articleRepository.GetAllArticlesAsync();
			return Ok(articles);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetArticle(int id)
		{
			var article = await articleRepository.GetArticleByIdAsync(id);
			if (article == null)
			{
				return NotFound();
			}
			return Ok(article);
		}

		// POST: api/article
		[HttpPost]
		[Authorize(Roles = "Blogger")]
		public async Task<IActionResult> CreateArticle([FromBody] CreateArticleDTO articleDTO)
		{
			if (articleDTO == null)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var article = new Article
			{
				BloggerId = "1",
				Content = articleDTO.Content,
				CreatedAt = DateTime.Now,
				Title = articleDTO.Title,
				UpdatedAt = DateTime.Now,
			};

			await articleRepository.CreateArticleAsync(article);
			return CreatedAtAction(nameof(GetArticle), new { id = article.ArticleId }, article);
		}

		// PUT: api/article/1 (replace 1 with the article ID)
		[HttpPut("{id}")]
		[Authorize(Roles = "Blogger")]
		public async Task<IActionResult> UpdateArticle(int id, [FromBody] UpdateArticleDTO articleDTO)
		{
			if (articleDTO == null || id != articleDTO.ArticleId)
			{
				return BadRequest(); // Invalid input data or mismatched IDs
			}
			var existingArticle = await articleRepository.GetArticleByIdAsync(id);
			if (existingArticle == null)
			{
				return NotFound();
			}

			existingArticle.Title = articleDTO.Title;
			existingArticle.Content = articleDTO.Content;
			existingArticle.UpdatedAt = DateTime.Now;

			await articleRepository.UpdateArticleAsync(existingArticle);

			return NoContent(); // Successfully updated
		}

		// DELETE: api/article/1 (replace 1 with the article ID)
		[HttpDelete("{id}")]
		[Authorize(Roles = "Blogger")]
		public async Task<IActionResult> DeleteArticle(int id)
		{
			var existingArticle = await articleRepository.GetArticleByIdAsync(id);
			if (existingArticle == null)
			{
				return NotFound();
			}

			await articleRepository.DeleteArticleAsync(id);
			return NoContent(); // Successfully deleted
		}


	}
}
