using ExploreCalifornia.Website.Domain.WriteModel;

namespace ExploreCalifornia.Website.DataAccess.WriteModel
{
    public interface IBookingsRepository
    {
        void Save(Booking booking);
    }
}
