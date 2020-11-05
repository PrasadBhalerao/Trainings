using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExploreCalifornia.TravelAgentService.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExploreCalifornia.TravelAgentService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TravelAgentController : ControllerBase
    {
        [HttpPost]
        public void Post(TravelAgentBookingMail request)
        {
            System.IO.File.AppendAllText("/data/TravelAgentService/travelAgentAPI.txt", $"{DateTime.Now.ToString("O")} Sent booking by {request.Email} ({request.Name}) to travel agent for tour {request.TourId}." + Environment.NewLine);
        }
    }
}
