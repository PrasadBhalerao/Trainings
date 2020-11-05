using ExploreCalifornia.Monolith.Domain;

namespace ExploreCalifornia.Monolith.DataAccess
{
    public interface IBookingsRepository
    {
        void Save(Booking booking);
    }
}