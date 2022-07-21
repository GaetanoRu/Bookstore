using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Shared.Models.Responses
{
    public class DetailAuthorBook
    {
        public Guid IdBook { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int Page { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Genre { get; set; }   
    }
}
