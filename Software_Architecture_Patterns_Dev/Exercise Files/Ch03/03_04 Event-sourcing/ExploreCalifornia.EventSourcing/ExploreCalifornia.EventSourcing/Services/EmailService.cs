using System;
using System.IO;
using ExploreCalifornia.EventSourcing.Domain;

namespace ExploreCalifornia.EventSourcing.Services
{
    public class EmailService : IEmailService
    {
        public void SendBookingConfirmationMail(string email, string name, Tour tour)
        {
            File.AppendAllText("AppData\\mails.txt", $"{DateTime.Now.ToString("O")} Sent mail to {email} ({name}) for the '{tour.Name}' tour." + Environment.NewLine);
        }
    }
}
