using AutoMapper;

namespace ExploreCalifornia.BookingsService
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Contracts.Booking, Domain.Booking>();
        }
    }
}