using AutoMapper;
using ExploreCalifornia.Business.Bookings;

namespace ExploreCalifornia.Application.Bookings
{
    public class BookingsController
    {
        private readonly IBookingsService _bookingsService;
        private readonly IMapper _mapper;

        public BookingsController(IBookingsService bookingsService, IMapper mapper)
        {
            _bookingsService = bookingsService;
            _mapper = mapper;
        }

        public void Save(Booking booking)
        {
            var businessBooking = 
                _mapper.Map<Business.Bookings.Booking>(booking);

            _bookingsService.Save(businessBooking);
        }
    }
}