using Bookstore.Shared.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.BusinessLayer.Services.Interfaces
{
    public interface IBookService
    {
        public Task<ListResultPagination<BookListResult>> GetAsync(string search, int pageIndex, int itemsPerPage);
        public Task<Book> GetBookAsync(Guid id);
    }
}
