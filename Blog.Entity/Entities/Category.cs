using Blog.Core.Entities;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Blog.Entity.Entities
{
    public class Category : EntityBase
    {


        public Category()
        {
            
        }


        public Category(string name)
        {
           Name = name;

        }

        public string Name { get; set; }

        public ICollection<Article> Articles { get; set; }

    }
}
