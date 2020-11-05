using ExploreCalifornia.PresentationTier.Models;
using RestSharp;

namespace ExploreCalifornia.PresentationTier.Business
{
    public class BookingsProxy : IBookingsProxy
    {
        public void Save(Booking booking)
        {
            var client = new RestClient("https://localhost:44396/");
            var request = new RestRequest("bookings", DataFormat.Json)
                .AddJsonBody(booking);
            
            var response = client.Post(request);
        }
    }
}
