using ExploreCalifornia.MVVM.Model;
using GalaSoft.MvvmLight;

namespace ExploreCalifornia.MVVM.ViewModels
{
    public class BookingViewModel : ViewModelBase
    {
        private string _name;
        private string _email;
        private bool _transport;

        public BookingViewModel(Booking booking)
        {
            Name = booking.Name;
            Email = booking.Email;
            Transport = booking.Transport;
        }

        public string Name
        {
            get => _name;
            set => Set(ref _name, value, nameof(Name));
        }

        public string Email
        {
            get => _email;
            set => Set(ref _email, value, nameof(Email));
        }

        public bool Transport
        {
            get => _transport;
            set => Set(ref _transport, value, nameof(Transport));
        }
    }
}
