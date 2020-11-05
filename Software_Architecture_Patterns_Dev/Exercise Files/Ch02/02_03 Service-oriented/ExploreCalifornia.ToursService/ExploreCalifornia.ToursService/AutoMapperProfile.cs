using AutoMapper;

namespace ExploreCalifornia.ToursService
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Domain.Tour, Contracts.Tour>();
        }
    }
}