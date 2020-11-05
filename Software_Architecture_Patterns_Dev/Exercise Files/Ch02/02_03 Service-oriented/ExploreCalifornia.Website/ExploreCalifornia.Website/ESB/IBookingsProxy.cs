using ExploreCalifornia.Website.Models;

namespace ExploreCalifornia.Website.ESB
{
    public interface IBookingsProxy
    {
        void Save(Booking booking);
    }
}
