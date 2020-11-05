using System;
using ExploreCalifornia.TravelAgentService.ESB;
using Microsoft.AspNetCore.Mvc;

namespace ExploreCalifornia.TravelAgentService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TravelAgentController : ControllerBase
    {
        [HttpPost]
        [Route("mail")]
        public void Post(SendTravelAgentBookingMail request)
        {
            System.IO.File.AppendAllText("AppData\\travelAgentAPI.txt", $"{DateTime.Now.ToString("O")} Sent booking by {request.Email} ({request.Name}) to travel agent for tour {request.TourId}." + Environment.NewLine);
        }
    }
}
