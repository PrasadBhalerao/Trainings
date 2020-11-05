using System;
using ExploreCalifornia.MVP.Model;

namespace ExploreCalifornia.MVP.Views
{
    public interface IBookingView
    {
        event EventHandler<EventArgs> ViewLoaded;
        void SetName(string name);
        void SetEmail(string email);
        void SetTransport(string value);
    }
}