using System;
using System.Collections.Generic;
using ExploreCalifornia.Website.Contracts;
using ExploreCalifornia.Website.Models;
using Newtonsoft.Json;
using RestSharp;

namespace ExploreCalifornia.Website.ESB
{
    public class ToursProxy : IToursProxy
    {
        public IList<Tour> GetTours()
        {
            var client = new RestClient("https://localhost:4001");
            var request = new RestRequest("esb/explorecalifornia/tours", DataFormat.Json)
                .AddJsonBody(new Message());

            var response = client.Post<Message<IList<Tour>>>(request);
            return response.Data.Data;
        }

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
