using System.Collections.Generic;
using AutoMapper;

namespace ExploreCalifornia.Business.Tours
{
    public class ToursService : IToursService
    {
        private readonly IToursRepository _toursRepository;
        private readonly IMapper _mapper;

        public ToursService(IToursRepository toursRepository, IMapper mapper)
        {
            _toursRepository = toursRepository;
            _mapper = mapper;
        }

        public IEnumerable<Tour> GetTours()
        {
            var databaseTours = _toursRepository.GetTours();
            var tours = _mapper.Map<IEnumerable<Tour>>(databaseTours);
            return tours;
        }

        public Tour GetTour(int id)
        {
            var databaseTour = _toursRepository.GetTour(id);
            var tour = _mapper.Map<Tour>(databaseTour);
            return tour;
        }
    }
}