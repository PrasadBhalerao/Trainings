using ExploreCalifornia.BookingsService.Domain;

namespace ExploreCalifornia.BookingsService.DataAccess
{
    public interface IBookingsRepository
    {
        void Save(Booking booking);
    }
}