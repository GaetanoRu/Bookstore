using AutoMapper;
using Bookstore.Shared.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = Bookstore.DataAccessLayer.Entities;

namespace Bookstore.BusinessLayer.Mappers
{
    public class BookMapperProfile : Profile
    {
        public BookMapperProfile()
        {
            CreateMap<Entities.Book, DetailAuthorBook>()
               .ForMember(source => source.IdBook, dest => dest.MapFrom(a => a.Id));

            CreateMap<Entities.Book, Book>()
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.FullName));

            CreateMap<Entities.Book, BookListResult>()
                .ForMember(source => source.RatingCount, dest => dest.MapFrom(a => a.Ratings != null ? a.Ratings.Count : 0))
                .ForMember(source => source.RatingScore, dest => dest.MapFrom(a => a.Ratings != null && a.Ratings.Any()
                    ? Math.Round(a.Ratings.Select(r => r.Score).Average(), 2) : (double?)null));
        }
    }
}
