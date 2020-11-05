using AutoMapper;
using ExploreCalifornia.Website.Models;
using RestSharp;

namespace ExploreCalifornia.Website.ExternalServices.Bookings
{
    public class BookingsProxy : IBookingsProxy
    {
        private readonly IMapper _mapper;

        public BookingsProxy(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void Save(Models.Booking booking)
        {
            var client = new RestClient("http://bookingsservice");
            var request = new RestRequest("bookings", DataFormat.Json)
                .AddJsonBody(_mapper.Map<Booking>(booking));

            client.Post(request);
        }
    }
}
