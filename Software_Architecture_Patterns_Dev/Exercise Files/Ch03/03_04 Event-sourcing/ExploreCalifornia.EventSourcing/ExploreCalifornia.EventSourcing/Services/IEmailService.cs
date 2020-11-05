using ExploreCalifornia.EventSourcing.Domain;
using ExploreCalifornia.EventSourcing.Domain.Entities;

namespace ExploreCalifornia.EventSourcing.Services
{
    public interface IEmailService
    {
        void SendBookingConfirmationMail(string email, string name, Tour tour);
    }
}
