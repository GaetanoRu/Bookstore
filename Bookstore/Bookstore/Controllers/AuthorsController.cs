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

     
        [HttpGet]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Author>>> GetAllAuthor()
        {

            var author = await authorService.GetAuthorsAsync();
            return Ok(author);

        }

      
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
