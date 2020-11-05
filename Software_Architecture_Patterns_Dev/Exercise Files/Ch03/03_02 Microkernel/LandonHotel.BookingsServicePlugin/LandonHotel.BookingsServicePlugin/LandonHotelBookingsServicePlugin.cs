using System;
using System.Collections.Generic;
using ExploreCalifornia.Processor.Contracts;

namespace LandonHotel.BookingsServicePlugin
{
    public class LandonHotelBookingsServicePlugin : IInputPlugin
    {
        public IEnumerable<Booking> GetBookings()
        {
            var tasteOfCalifornia = new Tour
            {
                Id = 8,
                Name = "Taste of California"
            };

            return new List<Booking>
            {
                new Booking
                {
                    Id = 4,
                    Name = "Lars",
                    Email = "lars@example.com",
                    Tour = tasteOfCalifornia
                }
            };
        }
    }
}
