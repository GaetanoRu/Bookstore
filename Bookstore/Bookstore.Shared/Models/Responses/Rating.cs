using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Shared.Models.Responses
{
    public class Rating
    {
        public Guid Id { get; set; }
        public double Score { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }
}
