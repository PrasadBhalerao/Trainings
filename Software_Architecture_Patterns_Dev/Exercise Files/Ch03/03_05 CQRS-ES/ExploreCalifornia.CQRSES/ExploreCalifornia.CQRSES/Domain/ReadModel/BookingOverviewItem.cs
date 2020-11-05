using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.CQRSES.Domain.ReadModel
{
    public class BookingOverviewItem
    {
        public Guid BookingId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Transport { get; set; }
        public string TourName { get; set; }
    }
}
