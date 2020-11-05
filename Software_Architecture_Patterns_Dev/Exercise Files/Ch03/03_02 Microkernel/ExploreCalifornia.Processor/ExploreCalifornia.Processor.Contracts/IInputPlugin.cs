using System.Collections.Generic;

namespace ExploreCalifornia.Processor.Contracts
{
    public interface IInputPlugin
    {
        IEnumerable<Booking> GetBookings();
    }
}