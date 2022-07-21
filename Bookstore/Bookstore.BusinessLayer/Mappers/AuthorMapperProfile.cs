using AutoMapper;
using Bookstore.Shared.Models.Responses;
using Entities = Bookstore.DataAccessLayer.Entities;


namespace Bookstore.BusinessLayer.Mappers
{
    public class AuthorMapperProfile : Profile
    {
        public AuthorMapperProfile()
        {
            CreateMap<Entities.Author, Author>();

            CreateMap<Entities.Author, AuthorBook>()
                .ForMember(dest => dest.BooksByTheAuthor, opt => opt.MapFrom(src => src.Books))
                .ForMember(dest => dest.TotalResults, opt => opt.MapFrom(src => src.Books.Count));
        }
    }
}
