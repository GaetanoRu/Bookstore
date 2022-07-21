using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Shared.Models.Responses
{
    public class NewRating
    {
        public Guid BookId { get; }
        public double AverageScore { get; }

        public NewRating(Guid bookId, double averageScore)
        {
            BookId = bookId;
            AverageScore = averageScore;
        }
    }
}
