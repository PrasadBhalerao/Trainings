using ExploreCalifornia.Monolith.Domain;
using Dapper;
using Microsoft.Data.Sqlite;

namespace ExploreCalifornia.Monolith.DataAccess
{
    public class BookingsRepository : IBookingsRepository
    {
        private readonly string _connectionString;

        public BookingsRepository()
        {
            _connectionString = "Data Source=AppData/monolith-database.db;";
        }

        public void Save(Booking booking)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Execute(
                    "INSERT INTO Booking (TourId, Name, Email, Transport) VALUES (@TourId, @Name, @Email, @Transport)",
                    new { TourId = booking.TourId, Name = booking.Name, Email = booking.Email, Transport = booking.Transport });
            }
        }
    }
}
