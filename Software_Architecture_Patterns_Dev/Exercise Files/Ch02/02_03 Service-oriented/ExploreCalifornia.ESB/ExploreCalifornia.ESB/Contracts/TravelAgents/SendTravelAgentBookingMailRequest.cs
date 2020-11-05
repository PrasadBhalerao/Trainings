namespace ExploreCalifornia.ESB.Contracts.TravelAgents
{
    public class SendTravelAgentBookingMailRequest
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public int TourId { get; set; }
    }
}