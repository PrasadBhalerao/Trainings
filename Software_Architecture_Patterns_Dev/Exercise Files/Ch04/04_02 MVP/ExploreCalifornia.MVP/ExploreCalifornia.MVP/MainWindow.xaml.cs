using System;
using ExploreCalifornia.MVP.Presenters;
using ExploreCalifornia.MVP.Views;
using System.Windows;

namespace ExploreCalifornia.MVP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainView
    {
        private MainPresenter _presenter;

        public event EventHandler<EventArgs> BookingsRequested;
        public event EventHandler<IdEventArgs> BookingRequested;

        public MainWindow()
        {
            InitializeComponent();
            _presenter = new MainPresenter(this);
        }

        public void ShowBooking(int id)
        {
            var bookingView = new BookingView(id);
            ContentHolder.Content = bookingView;
        }
        
        public void ShowBookings()
        {
            var bookingsView = new BookingsView();
            bookingsView.BookingRequested += this.BookingRequested;
            ContentHolder.Content = bookingsView;
        }

        private void BookingsButton_OnClick(object sender, RoutedEventArgs e)
        {
            BookingsRequested(this, new EventArgs());
        }
    }
}
