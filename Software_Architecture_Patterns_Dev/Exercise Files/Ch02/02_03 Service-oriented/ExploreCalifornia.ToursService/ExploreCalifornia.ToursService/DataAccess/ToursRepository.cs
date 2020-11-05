using System.Collections.Generic;
using System.Linq;
using Dapper;
using ExploreCalifornia.ToursService.Domain;
using Microsoft.Data.Sqlite;

namespace ExploreCalifornia.ToursService.DataAccess
{
    public class ToursRepository : IToursRepository
    {
        private readonly string _connectionString;

        public ToursRepository()
        {
            _connectionString = "Data Source=AppData/soa-tours-database.db;";
        }

        public IList<Tour> GetTours()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var tours = connection.Query<Tour>("SELECT Id, Name, Description, Image FROM Tour");
                return tours.ToList();
            }
        }

        public Tour GetTour(int id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var tours = connection.Query<Tour>("SELECT Id, Name, Description, Image FROM Tour WHERE Id = @Id", new { Id = id });
                return tours.FirstOrDefault();
            }
        }
    }
}