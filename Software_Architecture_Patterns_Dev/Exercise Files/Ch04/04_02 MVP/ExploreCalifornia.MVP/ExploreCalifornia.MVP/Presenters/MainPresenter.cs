using ExploreCalifornia.MVP.Views;

namespace ExploreCalifornia.MVP.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView _mainView;

        public MainPresenter(IMainView mainView)
        {
            _mainView = mainView;
            _mainView.BookingsRequested += (sender, eventArgs) => { _mainView.ShowBookings(); };
            _mainView.BookingRequested += (sender, idEventArgs) =>
            {
                _mainView.ShowBooking(idEventArgs.Id);
            };
        }
    }
}