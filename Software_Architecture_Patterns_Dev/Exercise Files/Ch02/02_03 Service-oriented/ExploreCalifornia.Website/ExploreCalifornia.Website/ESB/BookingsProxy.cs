using ExploreCalifornia.Website.Contracts;
using ExploreCalifornia.Website.Models;
using RestSharp;

namespace ExploreCalifornia.Website.ESB
{
    public class BookingsProxy : IBookingsProxy
    {
        public void Save(Booking booking)
        {
            var client = new RestClient("https://localhost:4001");
            var request = new RestRequest("esb/explorecalifornia/booking", DataFormat.Json)
                .AddJsonBody(new Message<CreateBookingRequest>(new CreateBookingRequest
                {
                    TourId = booking.TourId,
                    Email = booking.Email,
                    Name = booking.Name,
                    Transport = booking.Transport
                }));

            client.Post(request);
        }
    }
}
