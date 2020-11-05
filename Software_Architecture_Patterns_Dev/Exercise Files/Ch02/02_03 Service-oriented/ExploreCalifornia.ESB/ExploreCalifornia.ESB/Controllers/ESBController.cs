using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using ExploreCalifornia.ESB.Contracts;
using ExploreCalifornia.ESB.Contracts.Bookings;
using ExploreCalifornia.ESB.Contracts.Mails;
using ExploreCalifornia.ESB.Contracts.Tours;
using ExploreCalifornia.ESB.Contracts.TravelAgents;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace ExploreCalifornia.ESB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ESBController : ControllerBase
    {
        [HttpPost]
        [Route("{*url}")]
        public Message Post(string url, Message message)
        {
            var dataText = ((JsonElement)message.Data).GetRawText();

            // Here we route the request to the correct service
            // A real ESB does this mapping by configuration
            // For simplicity's sake, this is hard-coded
            // You would not want to implement your own ESB
            // You would use an existing product
            switch (url)
            {
                case "explorecalifornia/tours":
                {
                    var client = new RestClient(
                        "https://localhost:6001/");
                    var request = new RestRequest(
                        "tours", 
                        DataFormat.Json);
                    var response = client.Get<dynamic>(request);
                    return new Message
                    {
                        Data = response.Data["data"]
                    };
                }
                case "explorecalifornia/tour":
                {
                    var client = new RestClient("https://localhost:6001/");
                    var data = JsonSerializer.Deserialize<TourRequest>(dataText);
                    var tourId = data.TourId;
                    var request = new RestRequest($"tours/{tourId}", DataFormat.Json);
                    var response = client.Get<dynamic>(request);
                    return new Message
                    {
                        Data = response.Data
                    };
                }
                case "explorecalifornia/booking":
                {
                    var booking = JsonSerializer.Deserialize<CreateBookingRequest>(dataText);
                    SendRequest("https://localhost:7001/", "bookings", booking);
                    return new Message();
                }
                case "explorecalifornia/bookingmade":
                {
                    var bookingMade = 
                            JsonSerializer.Deserialize<BookingMade>(
                                dataText);

                    // Call EmailService
                    var sendBookingMailRequest = 
                            new SendBookingMailRequest 
                    { 
                        Name = bookingMade.Name,
                        Email = bookingMade.Email,
                        TourId = bookingMade.TourId,
                        Transport = bookingMade.Transport
                    };
                    SendRequest("https://localhost:8001", 
                        "mail/booking", 
                        sendBookingMailRequest);

                    // Call TravelAgentService
                    var sendTravelAgentBookingMailRequest = new SendTravelAgentBookingMailRequest
                    {
                        Name = bookingMade.Name,
                        Email = bookingMade.Email,
                        TourId = bookingMade.TourId
                    };
                    SendRequest("https://localhost:9001", 
                        "travelagent/mail",
                        sendTravelAgentBookingMailRequest);

                    return new Message();
                }
            }

            return new Message
            {
                Data = "Unknown Route!"
            };
        }

        private IRestResponse SendRequest(string baseUrl, string path, object body)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(path, DataFormat.Json).AddJsonBody(body);
            var response = client.Post(request);
            return response;
        }
    }
}
