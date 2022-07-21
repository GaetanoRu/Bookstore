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

        /// <summary>
        /// Get the paginated books list
        /// </summary>
        /// <param name="search"></param>
        /// <param name="pageIndex">The index of the page to get</param>
        /// <param name="itemPerpage">The number of elements to get</param>
        /// <response code="200">The books list</response>
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

        /// <summary>
        /// Get a specific book
        /// </summary>
        /// <param name="id">Id of the book to retrive</param>
        /// <response code="200">The desired book</response>
        /// <response code="404">The book not found</response>
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

        /// <summary>
        ///  Get the paginated ratings of the given book
        /// </summary>
        /// <param name="bookId">Id of the book</param>
        /// <param name="pageIndex">The index of the page to get</param>
        /// <param name="itemsPerPage">The number of the elements to get</param>
        /// <returns></returns>
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


        /// <summary>
        /// Send a new rating for a book
        /// </summary>
        /// <param name="bookId">Id of the book to rate</param>
        /// <param name="rating">The rating to submit</param>
        /// <response code="200">Rating submitted successfully</response>
        /// <response code="400">Unable to submit the rating because of an error of input data</response>
        [HttpPost("{id:guid}/rating")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(typeof(NewRating), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<NewRating>> Rate([FromRoute(Name = "id")] Guid bookId, RatingRequest rating)
        {
            var newRating = await ratingService.RateAsync(bookId, rating);
            return newRating;

        }
    }
}

