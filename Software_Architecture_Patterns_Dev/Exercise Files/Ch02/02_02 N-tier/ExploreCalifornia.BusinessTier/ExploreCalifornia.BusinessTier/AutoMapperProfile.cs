using AutoMapper;

namespace ExploreCalifornia.BusinessTier
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Domain.Tour, Contracts.Tour>();
            CreateMap<Contracts.Booking, Domain.Booking>();
        }
    }
}