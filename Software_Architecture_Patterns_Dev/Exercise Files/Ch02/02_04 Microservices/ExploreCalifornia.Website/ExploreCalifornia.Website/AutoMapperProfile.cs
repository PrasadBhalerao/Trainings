using AutoMapper;

namespace ExploreCalifornia.Website
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ExternalServices.Tours.Tour, Models.Tour>();
            CreateMap<Models.Booking, ExternalServices.Bookings.Booking>();
        }
    }
}