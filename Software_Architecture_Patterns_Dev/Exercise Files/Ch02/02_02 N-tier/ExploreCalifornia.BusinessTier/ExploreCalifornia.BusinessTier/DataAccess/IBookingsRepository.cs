using ExploreCalifornia.BusinessTier.Domain;

namespace ExploreCalifornia.BusinessTier.DataAccess
{
    public interface IBookingsRepository
    {
        void Save(Booking booking);
    }
}