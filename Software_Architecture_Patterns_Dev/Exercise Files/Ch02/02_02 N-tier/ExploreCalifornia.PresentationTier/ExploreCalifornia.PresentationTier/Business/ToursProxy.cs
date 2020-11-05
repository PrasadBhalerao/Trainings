using System.Collections.Generic;
using ExploreCalifornia.PresentationTier.Models;
using RestSharp;

namespace ExploreCalifornia.PresentationTier.Business
{
    public class ToursProxy : IToursProxy
    {
        public IList<Tour> GetTours()
        {
            var client = new RestClient("https://localhost:44396/");
            var request = new RestRequest("tours", DataFormat.Json);
            var response = client.Get<Tours>(request);
            return response.Data.Data;
        }

        public Tour GetTour(int id)
        {
            var client = new RestClient("https://localhost:44396/");
            var request = new RestRequest($"tours/{id}", DataFormat.Json);
            var response = client.Get<Tour>(request);
            return response.Data;
        }
    }
}
