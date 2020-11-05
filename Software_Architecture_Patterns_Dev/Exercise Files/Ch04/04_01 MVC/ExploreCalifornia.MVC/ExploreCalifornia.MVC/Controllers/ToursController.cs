using System.Collections.Generic;
using System.Linq;
using Dapper;
using ExploreCalifornia.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace ExploreCalifornia.MVC.Controllers
{
    public class ToursController : Controller
    {
        private string _connectionString;

        public ToursController()
        {
            _connectionString = "Data Source=AppData/mvc-database.db;";
        }

        [HttpGet("/tours")]
        public IActionResult Index()
        {
            List<Tour> tours;
            using (var connection = new SqliteConnection(_connectionString))
            {
                tours = connection.Query<Tour>("SELECT Id, Name, Description, Image FROM Tour").ToList();
            }

            return View(tours);
        }

        [HttpGet("tours/{id:int}")]
        public IActionResult Tour(int id)
        {
            Tour tour;
            using (var connection = new SqliteConnection(_connectionString))
            {
                tour = connection
                    .Query<Tour>("SELECT Id, Name, Description, Image FROM Tour WHERE Id = @Id", new { Id = id })
                    .FirstOrDefault();
            }
            
            return View(tour);
        }
    }
}