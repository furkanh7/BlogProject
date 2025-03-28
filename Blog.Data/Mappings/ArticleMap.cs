using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasData(new Article
            {
                Id = Guid.NewGuid(),
                Title = "Asp.Net Core Deneme Makalesi",
                Content = "Asp.Net Core Deneme Makalesi İçeriği",
                ViewCount = 15,

                CategoryId = Guid.Parse("7174F01E-FEE2-48CD-9F7E-7008C33E2631"),
                ImageId = Guid.Parse("445CC7DC-C06D-4027-9FAF-B0741AB40F35"),
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false



            },

            new Article
            {
                Id = Guid.NewGuid(),
                Title = "Visual Studio Deneme Makalesi",
                Content = "Visual Studio Deneme Makalesi İçeriği",
                ViewCount = 15,
                CategoryId = Guid.Parse("BD44FA31-719A-4FAC-A99F-1B18C093E44E"),
                ImageId = Guid.Parse("0098218F-EF1F-4571-A582-7205F1380C05"),
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false



            }














            );
        }
    }
}
