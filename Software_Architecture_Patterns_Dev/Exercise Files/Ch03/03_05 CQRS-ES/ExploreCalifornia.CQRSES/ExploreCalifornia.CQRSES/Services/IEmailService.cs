using ExploreCalifornia.CQRSES.Domain;
using ExploreCalifornia.CQRSES.Domain.WriteModel.Entities;

namespace ExploreCalifornia.CQRSES.Services
{
    public interface IEmailService
    {
        void SendBookingConfirmationMail(string email, string name, Tour tour);
    }
}
