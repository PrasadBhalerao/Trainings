using AutoMapper;
using ExploreCalifornia.BookingsService.Contracts;
using ExploreCalifornia.BookingsService.DataAccess;
using ExploreCalifornia.BookingsService.ExternalServices;
using Microsoft.AspNetCore.Mvc;

namespace ExploreCalifornia.BookingsService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingsRepository _bookingsRepository;
        private readonly IMapper _mapper;
        private readonly IMailProxy _mailProxy;
        private readonly ITravelAgentProxy _travelAgentProxy;

        public BookingsController(IBookingsRepository bookingsRepository, IMapper mapper, IMailProxy mailProxy, ITravelAgentProxy travelAgentProxy)
        {
            _bookingsRepository = bookingsRepository;
            _mapper = mapper;
            _mailProxy = mailProxy;
            _travelAgentProxy = travelAgentProxy;
        }

        [HttpPost]
        public void Post(Booking booking)
        {
            var domainBooking = _mapper.Map<Domain.Booking>(booking);
            _bookingsRepository.Save(domainBooking);
            _mailProxy.SendMail(domainBooking);
            _travelAgentProxy.NotifyTravelAgent(domainBooking);
        }
    }
}
