using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Entities
{
    public class AppUser : IdentityUser<Guid>
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Guid ImageId { get; set; } = Guid.Parse("445CC7DC-C06D-4027-9FAF-B0741AB40F35");
        public Image Image { get; set; }

        public ICollection<Article> Articles { get; set; }


    }
}
