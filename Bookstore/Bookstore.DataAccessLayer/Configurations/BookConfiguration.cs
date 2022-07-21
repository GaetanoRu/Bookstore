using Bookstore.DataAccessLayer.Configurations.Common;
using Bookstore.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.DataAccessLayer.Configurations
{
    internal class BookConfiguration : BaseEntityConfiguration<Book>
    {
        public override void Configure(EntityTypeBuilder<Book> builder)
        {
            base.Configure(builder);

            builder.ToTable("Books");

            builder.Property(b => b.Title)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(b => b.Year)
                .IsRequired();

            builder.Property(b => b.Summary)
                .IsRequired();

            builder.Property(b => b.Page)
                .IsRequired();

            builder.Property(b => b.ImageUrl)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(b => b.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(b => b.Genre)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(a => a.Author)
                .WithMany(b => b.Books)
                .HasForeignKey(a => a.AuthorId);

        }
    }
}
