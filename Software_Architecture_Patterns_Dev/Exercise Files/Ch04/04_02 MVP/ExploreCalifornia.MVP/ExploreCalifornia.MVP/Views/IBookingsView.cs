using System;
using System.Collections.Generic;
using ExploreCalifornia.MVP.Model;

namespace ExploreCalifornia.MVP.Views
{
    public interface IBookingsView
    {
        event EventHandler<EventArgs> ViewLoaded;
        void LoadBookings(IEnumerable<Booking> bookings);
    }
}