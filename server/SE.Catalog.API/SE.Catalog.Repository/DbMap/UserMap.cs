using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SE.Catalog.Models;
using SE.Catalog.Repository.Seeding;

namespace SE.Catalog.Repository.DbMap
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            //builder.Property(x => x.Id).UseSqlServerIdentityColumn(); 
            builder.Property(x => x.Role).IsRequired();           
            builder.Property(x => x.CreatedOn);
            builder.Property(x => x.LastModified);
            //builder.ToTable(nameof(User));
            UserData.Seed(builder);
        }
    }
}
