using System;
using System.Collections.Generic;
using AutoMapper;
using RestSharp;

namespace ExploreCalifornia.Website.ExternalServices.Tours
{
    public class ToursProxy : IToursProxy
    {
        private readonly IMapper _mapper;

        public ToursProxy(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<Models.Tour> GetTours()
        {
            var client = new RestClient("http://toursservice");
            var request = new RestRequest("tours", DataFormat.Json);

            var response = client.Get<Tours>(request);
            var result = _mapper.Map<IList<Models.Tour>>(
                response.Data.Data);
            return result;
        }

        public Models.Tour GetTour(int id)
        {
            var client = new RestClient("http://toursservice");
            var request = new RestRequest($"tours/{id}", DataFormat.Json);

            var response = client.Get<Tour>(request);
            var result = _mapper.Map<Models.Tour>(response.Data);
            return result;
        }
    }
}
