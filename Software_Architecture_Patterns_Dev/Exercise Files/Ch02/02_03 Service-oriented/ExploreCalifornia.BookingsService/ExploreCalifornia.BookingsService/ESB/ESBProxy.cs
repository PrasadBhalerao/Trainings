using ExploreCalifornia.BookingsService.Domain;
using ExploreCalifornia.BookingsService.ESB.Contracts;
using RestSharp;

namespace ExploreCalifornia.BookingsService.ESB
{
    public class ESBProxy : IESBroxy
    {
        public void NotifyBookingMade(Booking booking)
        {
            var client = new RestClient("https://localhost:4001");
            var request = new RestRequest("esb/explorecalifornia/bookingmade", DataFormat.Json)
                .AddJsonBody(new Message<BookingMade>(new BookingMade
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
