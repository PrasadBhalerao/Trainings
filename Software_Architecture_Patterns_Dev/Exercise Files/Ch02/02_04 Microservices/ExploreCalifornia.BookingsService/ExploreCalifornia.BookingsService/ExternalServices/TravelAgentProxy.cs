using ExploreCalifornia.BookingsService.Domain;
using RestSharp;

namespace ExploreCalifornia.BookingsService.ExternalServices
{
    public class TravelAgentProxy : ITravelAgentProxy
    {
        public void NotifyTravelAgent(Booking booking)
        {
            var client = new RestClient("http://travelagentservice");
            var request = new RestRequest("travelagent", DataFormat.Json)
                .AddJsonBody(new TravelAgentBookingMail
                {
                    Email = booking.Email,
                    Name = booking.Name,
                    TourId = booking.TourId
                });

            client.Post(request);
        }
    }
}
