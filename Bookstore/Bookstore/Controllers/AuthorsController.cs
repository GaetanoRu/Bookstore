using Bookstore.BusinessLayer.Services.Interfaces;
using Bookstore.Shared.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Controllers
{
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService authorService;
        public AuthorsController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        /// <summary>
        /// Get the authors
        /// </summary>
        /// <response code="200">The authors found</response>
        [HttpGet]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Author>>> GetAllAuthor()
        {

            var author = await authorService.GetAuthorsAsync();
            return Ok(author);

        }

        /// <summary>
        /// Get a specific author
        /// </summary>
        /// <param name="id">Id of the author to retrive</param>
        /// <response code="200">The desired author and the books published</response>
        /// <response code="404">The author not found</response>
        [HttpGet("{id:guid}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(typeof(AuthorBook), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AuthorBook>> GetAuthor(Guid id)
        {
            var author = await authorService.GetAuthorAsyncById(id);

            if (author != null)
            {
                return author;
            }
            return NotFound();
        }
    }
}
