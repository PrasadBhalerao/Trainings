using System;
using System.Collections.Generic;
using ExploreCalifornia.Processor.Contracts;

namespace ExploreCalifornia.BookingsServicePlugin
{
    public class ExploreCaliforniaBookingsServicePlugin : IInputPlugin
    {
        public IEnumerable<Booking> GetBookings()
        {
            var backpackCal = new Tour
            {
                Id = 1,
                Name = "Backpack Cal"
            };

            var snowboardCali= new Tour
            {
                Id = 2,
                Name = "Snowboard Cali"
            };

            return new List<Booking>
            {
                new Booking
                {
                    Id = 1,
                    Name = "Peter",
                    Email = "peter@example.com",
                    Tour = backpackCal
                },
                new Booking
                {
                    Id = 2,
                    Name = "Elizabeth",
                    Email = "elizabeth@example.com",
                    Tour = backpackCal
                },
                new Booking
                {
                    Id = 3,
                    Name = "Josephine",
                    Email = "josephine@example.com",
                    Tour = snowboardCali
                }
            };
        }
    }
}
