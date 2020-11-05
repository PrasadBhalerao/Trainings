using System;
using System.IO;
using ExploreCalifornia.Website.Domain;
using ExploreCalifornia.Website.Domain.WriteModel;

namespace ExploreCalifornia.Website.Services
{
    public class TravelAgentService : ITravelAgentService
    {
        public void NotifyTravelAgentOfBooking(Booking booking)
        {
            File.AppendAllText("AppData\\travelAgentAPI.txt", $"{DateTime.Now.ToString("O")} Sent booking by {booking.Email} ({booking.Name}) to travel agent for tour {booking.Tour.Id}." + Environment.NewLine);
        }
    }
}
