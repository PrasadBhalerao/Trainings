using AutoMapper;

namespace ExploreCalifornia.Website.AutoMapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Business.Tours.Tour, Application.Tours.Tour>();
            CreateMap<Application.Bookings.Booking, Business.Bookings.Booking>();
        }
    }
}