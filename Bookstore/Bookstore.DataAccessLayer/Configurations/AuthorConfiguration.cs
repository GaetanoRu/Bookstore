using Bookstore.DataAccessLayer.Configurations.Common;
using Bookstore.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.DataAccessLayer.Configurations
{
    internal class AuthorConfiguration : BaseEntityConfiguration<Author>
    {
        public override void Configure(EntityTypeBuilder<Author> builder)
        {
            base.Configure(builder);

            builder.ToTable("Authors");

            builder.Property(a => a.FullName)
                .HasMaxLength(250)
                .IsRequired();
                
            
        }
    }
}
