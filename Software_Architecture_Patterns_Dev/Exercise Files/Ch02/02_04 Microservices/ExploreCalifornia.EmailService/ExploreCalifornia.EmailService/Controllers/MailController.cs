using System;
using ExploreCalifornia.EmailService.Contracts;
using ExploreCalifornia.EmailService.Tours;
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
        public void Post(BookingConfirmationMail request)
        {
            var tour = _toursProxy.GetTour(request.TourId);
            System.IO.File.AppendAllText("/data/EmailService/mails.txt", $"{DateTime.Now.ToString("O")} Sent mail to {request.Email} ({request.Name}) for the '{tour.Name}' tour." + Environment.NewLine);
        }
    }
}