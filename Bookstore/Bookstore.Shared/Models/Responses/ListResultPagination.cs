using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Shared.Models.Responses
{
    public class ListResultPagination<T>
    {
        public int TotalResults { get; }
        public int TotalPages { get; }
        public bool HasNextPage { get; }
        public int CurrentPage { get; }
        public IEnumerable<T> Content { get; }

        public ListResultPagination(IEnumerable<T> content)
        {
            Content = content;
            TotalResults = content?.Count() ?? 0;
            HasNextPage = false;
        }

        public ListResultPagination(IEnumerable<T> content, int totalResults, int totalPage, int currentPage, bool hasNextPage = false)
        {

            TotalResults = totalResults;
            HasNextPage = hasNextPage;
            TotalPages = totalPage;
            CurrentPage = currentPage;
            Content = content;
        }
    }
}

