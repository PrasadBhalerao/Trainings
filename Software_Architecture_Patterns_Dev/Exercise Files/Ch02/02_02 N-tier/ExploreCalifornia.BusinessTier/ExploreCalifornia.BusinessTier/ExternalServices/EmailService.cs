using System;
using System.IO;
using ExploreCalifornia.BusinessTier.Domain;

namespace ExploreCalifornia.BusinessTier.ExternalServices
{
    public class EmailService : IEmailService
    {
        public void SendBookingConfirmationMail(Booking booking, Tour tour)
        {
            File.AppendAllText("AppData\\mails.txt", $"{DateTime.Now.ToString("O")} Sent mail to {booking.Email} ({booking.Name}) for the '{tour.Name}' tour." + Environment.NewLine);
        }
    }
}
