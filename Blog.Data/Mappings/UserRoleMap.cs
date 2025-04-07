using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUser Roles table
            builder.ToTable("AspNetUserRoles");

            builder.HasData(
                new AppUserRole
                {
                    UserId = Guid.Parse("8CCA96CD-DB26-45F5-856C-443FFEDBF79A"),
                    RoleId = Guid.Parse("6A2FCCCD-9AAD-476C-9996-8FEEAB844AA9")
                }, 
                new AppUserRole
                {
                    UserId = Guid.Parse("2C1B93B8-66C6-4746-8250-73BE6CD413CC"),
                    RoleId = Guid.Parse("4F5C6666-ED55-4DB8-940B-CC07147DC819"),
                }
            );
        }
    }
}
