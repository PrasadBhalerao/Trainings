using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using ExploreCalifornia.MVP.Model;
using ExploreCalifornia.MVP.Presenters;

namespace ExploreCalifornia.MVP.Views
{
    /// <summary>
    /// Interaction logic for BookingsView.xaml
    /// </summary>
    public partial class BookingsView : UserControl, IBookingsView
    {
        private BookingsPresenter _presenter;

        public BookingsView()
        {
            InitializeComponent();
            _presenter = new BookingsPresenter(this);
            Loaded += (sender, args) => ViewLoaded(this, new EventArgs());
        }

        public event EventHandler<EventArgs> ViewLoaded;
        public void LoadBookings(IEnumerable<Booking> bookings)
        {
            BookingsDataGrid.ItemsSource = bookings;
        }

        private void BookingLink_Click(object sender, RoutedEventArgs e)
        {
            var booking = ((Hyperlink)e.OriginalSource).DataContext as Booking;
            BookingRequested(this, new IdEventArgs(booking.Id));
        }

        public event EventHandler<IdEventArgs> BookingRequested;
    }
}
