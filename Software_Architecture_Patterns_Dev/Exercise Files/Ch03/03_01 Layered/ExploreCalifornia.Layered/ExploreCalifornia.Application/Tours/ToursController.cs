using System.Collections.Generic;
using AutoMapper;
using ExploreCalifornia.Business.Tours;

namespace ExploreCalifornia.Application.Tours
{
    public class ToursController
    {
        private readonly IToursService _toursService;
        private readonly IMapper _mapper;

        public ToursController(IToursService toursService, IMapper mapper)
        {
            _toursService = toursService;
            _mapper = mapper;
        }

        public IEnumerable<Tour> GetTours()
        {
            var businessLayerTours = _toursService.GetTours();
            var tours = _mapper.Map<IEnumerable<Tour>>(businessLayerTours);
            return tours;
        }

        public Tour GetTour(int id)
        {
            var businessLayerTour = _toursService.GetTour(id);
            var tour = _mapper.Map<Tour>(businessLayerTour);
            return tour;
        }
    }
}
