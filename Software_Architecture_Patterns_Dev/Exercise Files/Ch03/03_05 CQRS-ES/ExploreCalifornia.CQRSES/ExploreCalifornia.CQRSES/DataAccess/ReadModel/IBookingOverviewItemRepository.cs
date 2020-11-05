using ExploreCalifornia.CQRSES.Domain.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.CQRSES.DataAccess.ReadModel
{
    public interface IBookingOverviewItemRepository
    {
        IList<BookingOverviewItem> GetBookingOverviewItems();
        void Save(BookingOverviewItem bookingOverviewItem);
    }
}
