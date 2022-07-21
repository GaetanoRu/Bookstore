using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Shared.Models.Responses
{
    public class AuthorBook
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public int TotalResults { get; set; }

        public List<DetailAuthorBook> BooksByTheAuthor { get; set; }
    }
}

