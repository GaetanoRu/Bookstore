using Bookstore.Shared.Models.Requests;
using Bookstore.Shared.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.BusinessLayer.Services.Interfaces
{
    public interface IRatingService
    {
        Task<ListResultPagination<Rating>> GetAsync(Guid bookId, int pageIndex, int itemsPerPage);
        Task<NewRating> RateAsync(Guid bookId, RatingRequest request);
    }
}
