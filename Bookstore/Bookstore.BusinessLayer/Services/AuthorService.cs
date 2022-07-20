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
    public class AuthorService : IAuthorService
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public AuthorService(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            var dbAuthor = await context.Authors.ToListAsync();

            var authorList = mapper.Map<IEnumerable<Author>>(dbAuthor);
            return authorList;
        }

        public async Task<AuthorBook> GetAuthorAsyncById(Guid authorId)
        {
           var author = await context.Authors
                .Include(b => b.Books)
                .ProjectTo<AuthorBook>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(q => q.Id == authorId);

            if (author == null)
            {
                return null;
            }

            return author;
        }
      
    }
}
