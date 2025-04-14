using Blog.Entity.DTOs.Articles;

namespace Blog.Service.Services.Abstractions
{
    public interface IArticleService
    {
        Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync();

        Task CreateArticleAsync(ArticleAddDto articleAddDto);

    }
}
