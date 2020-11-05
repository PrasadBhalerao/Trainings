using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using ExploreCalifornia.MVVM.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Data.Sqlite;
using Dapper;
using ExploreCalifornia.MVVM.ViewModels.Messages;

namespace ExploreCalifornia.MVVM.ViewModels
{
    public class BookingsViewModel : ViewModelBase
    {
        private ObservableCollection<BookingViewModel> _bookings;

        public ICommand LoadCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var connectionString = "Data Source=../../../../../Database/mvvm-database.db;";
                    using (var connection = new SqliteConnection(connectionString))
                    {
                        var bookings = connection
                            .Query<Booking>("SELECT Id, Name, Email, Transport FROM Booking")
                            .Select(b => new BookingViewModel(b))
                            .ToList();
                        
                        Bookings = new ObservableCollection<BookingViewModel>(bookings);
                    }
                });
            }
        }

        public ICommand ShowBookingCommand
        {
            get
            {
                return new RelayCommand<BookingViewModel>(b =>
                {
                    MessengerInstance.Send(new ShowBookingMessage(b));
                });
            }
        }

        public ObservableCollection<BookingViewModel> Bookings
        {
            get => _bookings;
            set => Set(ref _bookings, value, nameof(Bookings));
        }
    }
}
