using Bookstore.BusinessLayer.Services.Interfaces;
using Bookstore.Shared.Models.Requests;
using Bookstore.Shared.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Controllers
{
    public class BooksController : ControllerBase
    {
        private readonly IBookService bookService;
        private readonly IRatingService ratingService;
        public BooksController(IBookService bookService, IRatingService ratingService)
        {
            this.bookService = bookService;
            this.ratingService = ratingService;
        }

        [HttpGet]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ListResultPagination<BookListResult>>> GetBooksList([FromQuery(Name = "search")] string search = null,
                                                                                           [FromQuery(Name = "page")] int pageIndex = 0,
                                                                                           [FromQuery(Name = "Size")] int itemPerpage = 5)
        {
            var listBooks = await bookService.GetAsync(search, pageIndex, itemPerpage);
            return listBooks;
        }

        [HttpGet("{id}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Book>> GetBook(Guid id)
        {
            var book = await bookService.GetBookAsync(id);

            if (book != null)
            {
                return book;
            }
            return NotFound();
        }


        [HttpGet("{id:guid}/rating")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(typeof(ListResultPagination<Rating>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ListResultPagination<Rating>>> GetRatingList([FromRoute(Name = "id")] Guid bookId,
                                                                                    [FromQuery(Name = "page")] int pageIndex = 0,
                                                                                    [FromQuery(Name = "size")] int itemsPerPage = 5)
        {
            var ratings = await ratingService.GetAsync(bookId, pageIndex, itemsPerPage);
            return ratings;
        }



        [HttpPost("{id:guid}/rating")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(typeof(NewRating), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<NewRating>> Rate([FromRoute(Name = "id")] Guid bookId, RatingRequest rating)
        {
            var newRating = await ratingService.RateAsync(bookId, rating);
            return newRating;
            //return CreatedAtRoute($"/api/v1/rating/{bookId}", newRating); //TODO: Controllare 
            //return CreatedAtRoute($"/api/v1/books/{bookId}/rating",newRating);

        }
    }
}

