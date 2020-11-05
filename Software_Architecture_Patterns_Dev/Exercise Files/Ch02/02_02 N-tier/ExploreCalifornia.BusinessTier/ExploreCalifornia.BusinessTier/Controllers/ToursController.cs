using System.Collections.Generic;
using AutoMapper;
using ExploreCalifornia.BusinessTier.Contracts;
using ExploreCalifornia.BusinessTier.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace ExploreCalifornia.BusinessTier.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToursController : ControllerBase
    {
        private readonly IToursRepository _toursRepository;
        private readonly IMapper _mapper;

        public ToursController(IToursRepository toursRepository, IMapper mapper)
        {
            _toursRepository = toursRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public Tours Get()
        {
            var tours = _toursRepository.GetTours();
            var result = new Tours
            {
                Data = _mapper.Map<IList<Tour>>(tours),
                Count = tours.Count
            };

            return result;
        }

        [HttpGet]
        [Route("{tourId}")]
        public Tour Get(int tourId)
        {
            var tour = _toursRepository.GetTour(tourId);
            var result = _mapper.Map<Tour>(tour);
            return result;
        }
    }
}
