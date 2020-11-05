using System;
using ExploreCalifornia.EmailService.Contracts;
using ExploreCalifornia.EmailService.ESB;
using Microsoft.AspNetCore.Mvc;

namespace ExploreCalifornia.EmailService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MailController : ControllerBase
    {
        private readonly IToursProxy _toursProxy;

        public MailController(IToursProxy toursProxy)
        {
            _toursProxy = toursProxy;
        }

        [HttpPost]
        [Route("booking")]
        public void Post(SendBookingMailRequest request)
        {
            var tour = _toursProxy.GetTour(request.TourId);
            System.IO.File.AppendAllText("AppData\\mails.txt", $"{DateTime.Now.ToString("O")} Sent mail to {request.Email} ({request.Name}) for the '{tour.Name}' tour." + Environment.NewLine);
        }
    }
}
