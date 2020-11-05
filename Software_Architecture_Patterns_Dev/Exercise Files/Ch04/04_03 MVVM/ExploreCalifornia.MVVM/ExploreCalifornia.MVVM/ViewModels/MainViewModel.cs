using System.Windows.Input;
using ExploreCalifornia.MVVM.ViewModels.Messages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace ExploreCalifornia.MVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _mainContent;

        public ICommand LoadCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    MessengerInstance.Register(this, (ShowBookingMessage msg) =>
                    {
                        MainContent = msg.ViewModel;
                    });
                });
            }
        }

        public ICommand ShowBookingsCommand
        {
            get
            { 
                return new RelayCommand(() =>
                {
                    MainContent = new BookingsViewModel();
                });
            }
        }

        public ViewModelBase MainContent
        {
            get => _mainContent;
            set => Set(ref _mainContent, value, nameof(MainContent));
        }
    }
}
