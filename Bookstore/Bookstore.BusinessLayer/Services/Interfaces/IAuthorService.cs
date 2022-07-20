using Bookstore.Shared.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.BusinessLayer.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<AuthorBook> GetAuthorAsyncById(Guid authorId);
        Task<IEnumerable<Author>> GetAuthorsAsync();

    }
}
