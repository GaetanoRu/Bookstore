using AutoMapper;
using Bookstore.Shared.Models.Requests;
using Bookstore.Shared.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = Bookstore.DataAccessLayer.Entities;

namespace Bookstore.BusinessLayer.Mappers
{
    public class RatingMapperProfile : Profile
    {
        public RatingMapperProfile()
        {
            CreateMap<Entities.Rating, Rating>();

            CreateMap<RatingRequest, Entities.Rating>()// Mapping DB
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.DateComment));
        }
    }
}
