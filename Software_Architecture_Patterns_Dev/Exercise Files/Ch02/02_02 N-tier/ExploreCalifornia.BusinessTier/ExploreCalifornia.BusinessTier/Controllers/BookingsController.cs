using System.Collections.Generic;
using AutoMapper;
using ExploreCalifornia.BusinessTier.Contracts;
using ExploreCalifornia.BusinessTier.DataAccess;
using ExploreCalifornia.BusinessTier.ExternalServices;
using Microsoft.AspNetCore.Mvc;

namespace ExploreCalifornia.BusinessTier.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingsRepository _bookingsRepository;
        private readonly IToursRepository _toursRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ITravelAgentService _travelAgentService;

        public BookingsController(IBookingsRepository bookingsRepository, IToursRepository toursRepository, IMapper mapper, IEmailService emailService, ITravelAgentService travelAgentService)
        {
            _bookingsRepository = bookingsRepository;
            _toursRepository = toursRepository;
            _mapper = mapper;
            _emailService = emailService;
            _travelAgentService = travelAgentService;
        }

        [HttpPost]
        public void Post(Booking booking)
        {
            var tour = _toursRepository.GetTour(booking.TourId);
            var domainBooking = _mapper.Map<Domain.Booking>(booking);
            _bookingsRepository.Save(domainBooking);
            _emailService.SendBookingConfirmationMail(domainBooking, tour);
            _travelAgentService.NotifyTravelAgentOfBooking(domainBooking);
        }
    }
}