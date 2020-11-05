using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.EventSourcing.Domain.Events
{
    public class BookingCanceled : VersionedEvent
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public int TourId { get; set; }
        public string Reason { get; set; }
    }
}
