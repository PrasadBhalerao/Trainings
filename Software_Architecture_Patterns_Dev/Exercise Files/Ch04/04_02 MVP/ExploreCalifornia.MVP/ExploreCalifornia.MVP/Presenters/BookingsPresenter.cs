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
    public class BookingsPresenter
    {
        private readonly IBookingsView _view;

        public BookingsPresenter(IBookingsView view)
        {
            _view = view;
            _view.ViewLoaded += OnViewLoaded;
        }

        private void OnViewLoaded(object sender, EventArgs e)
        {
            var connectionString = "Data Source=../../../../../Database/mvp-database.db;";
            IEnumerable<Booking> bookings;
            using (var connection = new SqliteConnection(connectionString))
            {
                bookings = connection
                    .Query<Booking>("SELECT Id, Name, Email, Transport FROM Booking")
                    .ToList();
            }
            _view.LoadBookings(bookings);
        }
    }
}