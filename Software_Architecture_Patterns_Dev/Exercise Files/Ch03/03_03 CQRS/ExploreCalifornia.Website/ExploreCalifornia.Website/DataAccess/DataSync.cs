using ExploreCalifornia.Website.DataAccess.ReadModel;
using ExploreCalifornia.Website.Domain.ReadModel;

namespace ExploreCalifornia.Website.DataAccess
{
    public class DataSync : IDataSync
    {
        readonly IBookingOverviewItemRepository _bookingOverviewItemRepository;

        public DataSync(ReadModel.IBookingOverviewItemRepository bookingOverviewItemRepository)
        {
            _bookingOverviewItemRepository = bookingOverviewItemRepository;
        }

        public void SyncBooking(Domain.WriteModel.Booking booking)
        {
            _bookingOverviewItemRepository.Save(new BookingOverviewItem
            {
                BookingId = booking.Id,
                Email = booking.Email,
                Name = booking.Name,
                TourName = booking.Tour.Name,
                Transport = booking.Transport
            });
        }
    }
}