using Bookstore.DataAccessLayer.Entities.Common;

namespace Bookstore.DataAccessLayer.Entities
{
    public class Rating : BaseEntity 
    {
        public Guid BookId { get; set; }
        public double Score { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }

        public virtual Book Book { get; set; }
    }
}
