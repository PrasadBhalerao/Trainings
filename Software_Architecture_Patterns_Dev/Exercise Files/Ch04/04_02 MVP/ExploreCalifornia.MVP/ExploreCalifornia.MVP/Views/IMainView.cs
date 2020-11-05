using System;

namespace ExploreCalifornia.MVP.Views
{
    public interface IMainView
    {
        event EventHandler<EventArgs> BookingsRequested;
        event EventHandler<IdEventArgs> BookingRequested;

        void ShowBookings();
        void ShowBooking(int id);
    }
}