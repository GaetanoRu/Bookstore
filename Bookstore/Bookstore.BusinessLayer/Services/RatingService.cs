using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bookstore.BusinessLayer.Services.Interfaces;
using Bookstore.DataAccessLayer;
using Bookstore.Shared.Models.Requests;
using Bookstore.Shared.Models.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = Bookstore.DataAccessLayer.Entities;

namespace Bookstore.BusinessLayer.Services
{
    public class RatingService : IRatingService
    {

        private readonly DataContext context;
        private readonly IMapper mapper;

        public RatingService(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ListResultPagination<Rating>> GetAsync(Guid bookId, int pageIndex, int itemsPerPage)
        {
            var dbRating = context.Ratings.Where(r => r.BookId == bookId);

            var totalCount = await dbRating.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / itemsPerPage);
            var current = (pageIndex <= 0) ? 1 : pageIndex;

            var ratings = await dbRating
                .OrderByDescending(r => r.Date)
                .Skip(pageIndex * itemsPerPage).Take(itemsPerPage + 1)
                .ProjectTo<Rating>(mapper.ConfigurationProvider)
                .ToListAsync();


            var result = new ListResultPagination<Rating>(ratings.Take(itemsPerPage), totalCount, totalPages, current, ratings.Count > itemsPerPage);
            return result;
        }

        public async Task<NewRating> RateAsync(Guid bookId, RatingRequest request)
        {
            var dbRating = mapper.Map<Entities.Rating>(request);
            dbRating.BookId = bookId;

            context.Add(dbRating);
            await context.SaveChangesAsync();

            var average = await context.Ratings
                .Where(book => book.BookId == bookId).AverageAsync(rating => rating.Score);

            var result = new NewRating(bookId, average);
            return result;
        }
    }
}
