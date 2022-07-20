using Bookstore.DataAccessLayer.Configurations.Common;
using Bookstore.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Bookstore.DataAccessLayer.Configurations
{
    internal class RatingConfiguration : BaseEntityConfiguration<Rating>
    {
        public override void Configure(EntityTypeBuilder<Rating> builder)
        {
            base.Configure(builder);

            builder.Property(r => r.Date)
                .HasColumnType("datetime");

            builder.Property(r => r.Score)
                .HasColumnType("float");

            builder.Property(r => r.Comment)
                .IsRequired(false);

            builder.HasOne(a => a.Book)
                .WithMany(b => b.Ratings)
                .HasForeignKey(a => a.BookId);
        }
    }
}
