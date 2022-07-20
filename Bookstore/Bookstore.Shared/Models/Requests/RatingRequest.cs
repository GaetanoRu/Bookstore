using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Shared.Models.Requests
{
    public class RatingRequest
    {
        public int Score { get; set; }

        public string? Comment { get; set; }

        public DateTime DateComment { get; set; } = DateTime.Now;
    }
}
