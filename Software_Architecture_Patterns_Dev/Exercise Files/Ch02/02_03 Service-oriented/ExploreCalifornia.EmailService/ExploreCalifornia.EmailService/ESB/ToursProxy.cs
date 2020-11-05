using RestSharp;

namespace ExploreCalifornia.EmailService.ESB
{
    public class ToursProxy : IToursProxy
    {
        public Tour GetTour(int id)
        {
            var client = new RestClient("https://localhost:4001");
            var request = new RestRequest("esb/explorecalifornia/tour", DataFormat.Json)
                .AddJsonBody(new Message<TourRequest>(new TourRequest
                {
                    TourId = id
                }));

            var response = client.Post<Message<Tour>>(request);
            return response.Data.Data;
        }
    }
}
