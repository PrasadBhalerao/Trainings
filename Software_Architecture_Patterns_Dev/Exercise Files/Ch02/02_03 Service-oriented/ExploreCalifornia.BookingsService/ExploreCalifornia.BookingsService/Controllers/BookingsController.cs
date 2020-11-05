using AutoMapper;
using ExploreCalifornia.BookingsService.Contracts;
using ExploreCalifornia.BookingsService.DataAccess;
using ExploreCalifornia.BookingsService.ESB;
using Microsoft.AspNetCore.Mvc;

namespace ExploreCalifornia.BookingsService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingsRepository _bookingsRepository;
        private readonly IMapper _mapper;
        private readonly IESBroxy _esbProxy;

        public BookingsController(IBookingsRepository bookingsRepository, IMapper mapper, IESBroxy esbProxy)
        {
            _bookingsRepository = bookingsRepository;
            _mapper = mapper;
            _esbProxy = esbProxy;
        }

        [HttpPost]
        public void Post(Booking booking)
        {
            var domainBooking = _mapper.Map<Domain.Booking>(booking);
            _bookingsRepository.Save(domainBooking);
            _esbProxy.NotifyBookingMade(domainBooking);
        }
    }
}
