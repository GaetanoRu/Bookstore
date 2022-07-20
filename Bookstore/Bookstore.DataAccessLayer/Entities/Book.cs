using Bookstore.DataAccessLayer.Entities.Common;


namespace Bookstore.DataAccessLayer.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Summary { get; set; }
        public int Page { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Genre { get; set; }
        public Guid AuthorId { get; set; }

        public virtual Author Author { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
