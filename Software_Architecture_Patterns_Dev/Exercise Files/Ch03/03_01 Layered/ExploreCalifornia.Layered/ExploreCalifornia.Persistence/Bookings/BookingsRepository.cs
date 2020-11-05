using Dapper;
using ExploreCalifornia.Business.Bookings;
using Microsoft.Data.Sqlite;

namespace ExploreCalifornia.Persistence.Bookings
{
    public class BookingsRepository : IBookingsRepository
    {
        private string _connectionString;

        public BookingsRepository()
        {
            _connectionString = 
                "Data Source=../ExploreCalifornia.Database/" +
                "layered-database.db;";
        }

        public void Save(Booking booking)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Execute(
                    "INSERT INTO Booking (TourId, Name, Email, Transport)" +
                    " VALUES (@TourId, @Name, @Email, @Transport)",
                    new 
                    { 
                        TourId = booking.TourId, 
                        Name = booking.Name, 
                        Email = booking.Email, 
                        Transport = booking.Transport 
                    });
            }
        }
    }
}