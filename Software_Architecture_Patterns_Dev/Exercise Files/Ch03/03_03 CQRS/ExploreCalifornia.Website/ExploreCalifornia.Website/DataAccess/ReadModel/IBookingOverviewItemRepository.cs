using System.Collections.Generic;
using ExploreCalifornia.Website.Domain.ReadModel;

namespace ExploreCalifornia.Website.DataAccess.ReadModel
{
    public interface IBookingOverviewItemRepository
    {
        IList<BookingOverviewItem> GetBookingOverviewItems();
        void Save(BookingOverviewItem bookingOverviewItem);
    }
}