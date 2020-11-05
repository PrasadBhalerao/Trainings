using System.Linq;
using Dapper;
using ExploreCalifornia.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace ExploreCalifornia.MVC.Controllers
{
    public class BookingsController : Controller
    {
        private string _connectionString;

        public BookingsController()
        {
            _connectionString = "Data Source=AppData/mvc-database.db;";
        }

        [HttpGet("/booking/{tourId:int}")]
        public IActionResult Booking(int tourId)
        {
            Tour tour;
            using (var connection = new SqliteConnection(_connectionString))
            {
                tour = connection
                    .Query<Tour>("SELECT Id, Name, Description, Image FROM Tour WHERE Id = @Id", new { Id = tourId })
                    .FirstOrDefault();
            }

            var booking = new Booking
            {
                Tour = tour
            };

            return View(booking);
        }

        [HttpPost("booking/{id:int}"), ValidateAntiForgeryToken]
        public IActionResult CreateBooking(Booking booking)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Execute(
                    "INSERT INTO Booking (TourId, Name, Email, Transport) VALUES (@TourId, @Name, @Email, @Transport)",
                    new
                    {
                        TourId = booking.Tour.Id,
                        Name = booking.Name,
                        Email = booking.Email,
                        Transport = booking.Transport
                    });
            }

            var routeValues = new { tourId = booking.Tour.Id, name = booking.Name, email = booking.Email, transport = booking.Transport };
            return RedirectToAction("Confirmation", "Bookings", routeValues);
        }

        [HttpGet("booking/confirmation")]
        public IActionResult Confirmation([FromQuery] int tourId, [FromQuery] string name, [FromQuery] string email, [FromQuery] bool transport)
        {
            Tour tour;
            using (var connection = new SqliteConnection(_connectionString))
            {
                tour = connection
                    .Query<Tour>("SELECT Id, Name, Description, Image FROM Tour WHERE Id = @Id", new { Id = tourId })
                    .FirstOrDefault();
            }

            var viewModel = new Booking
            {
                Tour = tour,
                Name = name,
                Email = email,
                Transport = transport
            };

            return View(viewModel);
        }
    }
}