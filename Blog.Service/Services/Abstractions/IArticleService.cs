using Blog.Entity.DTOs.Articles;

namespace Blog.Service.Services.Abstractions
{
    public interface IArticleService
    {
        Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync();
        Task<ArticleDto> GetArticlesWithCategoryNonDeletedAsync(Guid articleId);
        Task CreateArticleAsync(ArticleAddDto articleAddDto);

        Task UpdateArticleAsync(ArticleUpdateDto articleUpdateDto);
        Task SafeDeleteArticleAsync(Guid articleId);



    }
}
