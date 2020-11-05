using ExploreCalifornia.Website.Models;

namespace ExploreCalifornia.Website.ExternalServices.Bookings
{
    public interface IBookingsProxy
    {
        void Save(Models.Booking booking);
    }
}
