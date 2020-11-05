using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using ExploreCalifornia.MVP.Model;
using ExploreCalifornia.MVP.Views;
using Microsoft.Data.Sqlite;

namespace ExploreCalifornia.MVP.Presenters
{
    public class BookingPresenter
    {
        private readonly IBookingView _view;
        private readonly int _bookingId;

        public BookingPresenter(IBookingView view, int bookingId)
        {
            _view = view;
            _bookingId = bookingId;
            _view.ViewLoaded += OnViewLoaded;
        }

        private void OnViewLoaded(object sender, EventArgs e)
        {
            var connectionString = "Data Source=../../../../../Database/mvp-database.db;";
            Booking booking;
            using (var connection = new SqliteConnection(connectionString))
            {
                booking = connection
                    .Query<Booking>("SELECT Id, Name, Email, Transport FROM Booking WHERE Id = @id", new {id = _bookingId})
                    .FirstOrDefault();
            }
            _view.SetName(booking.Name);
            _view.SetEmail(booking.Email);
            _view.SetTransport(booking.Transport ? "yes" : "no");
        }
    }
}