using System.Collections.Generic;
using System.Linq;
using Dapper;
using ExploreCalifornia.Website.Domain.ReadModel;
using Microsoft.Data.Sqlite;

namespace ExploreCalifornia.Website.DataAccess.ReadModel
{
    public class ToursRepository : IToursRepository
    {
        private readonly string _connectionString;

        public ToursRepository()
        {
            _connectionString = "Data Source=AppData/cqrs-read-database.db;";
        }

        public IList<Tour> GetTours()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var tours = connection.Query<Tour>("SELECT TourId, Name, Description, Image FROM Tour");
                return tours.ToList();
            }
        }

        public Tour GetTour(int id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var tours = connection.Query<Tour>("SELECT TourId, Name, Description, Image FROM Tour WHERE TourId = @Id", new { Id = id });
                return tours.FirstOrDefault();
            }
        }
    }
}