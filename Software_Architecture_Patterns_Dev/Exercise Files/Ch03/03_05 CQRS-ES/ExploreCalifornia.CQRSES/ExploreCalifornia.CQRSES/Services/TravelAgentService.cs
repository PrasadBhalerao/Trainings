using System;
using System.IO;

namespace ExploreCalifornia.CQRSES.Services
{
    public class TravelAgentService : ITravelAgentService
    {
        public void NotifyTravelAgentOfBooking(string email, string name, int tourId)
        {
            File.AppendAllText("AppData\\travelAgentAPI.txt", $"{DateTime.Now.ToString("O")} Sent booking by {email} ({name}) to travel agent for tour {tourId}." + Environment.NewLine);
        }

        public void NotifyTravelAgentOfCancellation(string email, string name, int tourId, string cancellationReason)
        {
            File.AppendAllText("AppData\\travelAgentAPI.txt", $"{DateTime.Now.ToString("O")} Booking canceled by {email} ({name}) for tour {tourId}. Reason: {cancellationReason}" + Environment.NewLine);
        }
    }
}
