using Bookstore.DataAccessLayer.Entities.Common;

namespace Bookstore.DataAccessLayer.Entities
{
    public class Author : BaseEntity
    {
        public string FullName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
