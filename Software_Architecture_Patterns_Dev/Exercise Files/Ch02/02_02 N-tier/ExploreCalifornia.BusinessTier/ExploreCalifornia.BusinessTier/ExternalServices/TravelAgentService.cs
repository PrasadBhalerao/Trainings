using System;
using System.IO;
using ExploreCalifornia.BusinessTier.Domain;

namespace ExploreCalifornia.BusinessTier.ExternalServices
{
    public class TravelAgentService : ITravelAgentService
    {
        public void NotifyTravelAgentOfBooking(Booking booking)
        {
            File.AppendAllText("AppData\\travelAgentAPI.txt", $"{DateTime.Now.ToString("O")} Sent booking by {booking.Email} ({booking.Name}) to travel agent for tour {booking.TourId}." + Environment.NewLine);
        }
    }
}
