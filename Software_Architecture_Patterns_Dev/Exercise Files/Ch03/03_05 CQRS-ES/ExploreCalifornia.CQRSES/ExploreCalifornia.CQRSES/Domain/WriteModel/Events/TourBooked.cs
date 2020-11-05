using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.CQRSES.Domain.Events
{
    public class TourBooked : VersionedEvent
    {
        public int TourId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Transport { get; set; }
    }
}
