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
    public partial class BookingView : UserControl, IBookingView
    {
        private BookingPresenter _presenter;

        public BookingView(int bookingId)
        {
            InitializeComponent();
            _presenter = new BookingPresenter(this, bookingId);
            Loaded += (sender, args) => ViewLoaded(this, new EventArgs());
        }

        public event EventHandler<EventArgs> ViewLoaded;

        public void SetName(string name)
        {
            NameLabel.Content = name;
        }

        public void SetEmail(string email)
        {
            EmailLabel.Content = email;
        }

        public void SetTransport(string value)
        {
            TransportLabel.Content = value;
        }
    }
}
