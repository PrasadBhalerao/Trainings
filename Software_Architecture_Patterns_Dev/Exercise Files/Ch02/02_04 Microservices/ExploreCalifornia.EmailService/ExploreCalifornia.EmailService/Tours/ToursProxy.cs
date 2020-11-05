using RestSharp;

namespace ExploreCalifornia.EmailService.Tours
{
    public class ToursProxy : IToursProxy
    {
        public Tour GetTour(int id)
        {
            var client = new RestClient("http://toursservice");
            var request = new RestRequest($"tours/{id}", DataFormat.Json);

            var response = client.Get<Tour>(request);
            return response.Data;
        }
    }
}