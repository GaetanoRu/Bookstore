using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bookstore.BusinessLayer.Services.Interfaces;
using Bookstore.DataAccessLayer;
using Bookstore.Shared.Models.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.BusinessLayer.Services
{
    public class BookService : IBookService
    {

        private readonly DataContext context;
        private readonly IMapper mapper;

        public BookService(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        public async Task<ListResultPagination<BookListResult>> GetAsync(string search, int pageIndex, int itemsPerPage)
        {
            var db = context.Books.Where(b => search == null || b.Title.Contains(search) || b.Author.FullName.Contains(search));

            var totalCount = await db.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / itemsPerPage);
            var current = (pageIndex <= 0) ? 1 : pageIndex;

            var book = await db
                .Include(r => r.Ratings)
                .OrderBy(t => t.Title)
                .Skip(pageIndex * itemsPerPage).Take(itemsPerPage + 1)
                .ProjectTo<BookListResult>(mapper.ConfigurationProvider)
                .ToListAsync();


            var result = new ListResultPagination<BookListResult>(book.Take(itemsPerPage), totalCount, totalPages, current, book.Count > itemsPerPage);
            return result;
        }

        public async Task<Book> GetBookAsync(Guid id)
        {
            var dbBook = await context.Books
                .Include(a => a.Author)
                .FirstOrDefaultAsync(book => book.Id == id);

            if (dbBook == null)
            {
                return null;
            }

            var book = mapper.Map<Book>(dbBook);
            return book;
        }
    }
}
