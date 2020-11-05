using System;
using System.Collections.Generic;
using System.Text;

namespace ExploreCalifornia.MVVM.ViewModels.Messages
{
    public class ShowBookingMessage
    {
        public BookingViewModel ViewModel { get; }

        public ShowBookingMessage(BookingViewModel viewModel)
        {
            ViewModel = viewModel;
        }
    }
}
