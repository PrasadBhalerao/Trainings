using Dapper;
using ExploreCalifornia.Website.Domain.WriteModel;
using Microsoft.Data.Sqlite;

namespace ExploreCalifornia.Website.DataAccess.WriteModel
{
    public class BookingsRepository : IBookingsRepository
    {
        private readonly IDataSync _dataSync;
        private readonly string _connectionString;

        public BookingsRepository(IDataSync dataSync)
        {
            _dataSync = dataSync;
            _connectionString = "Data Source=AppData/cqrs-write-database.db;";
        }

        public void Save(Booking booking)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Execute(
                    "INSERT INTO Booking (TourId, Name, Email, Transport) " +
                    "VALUES (@TourId, @Name, @Email, @Transport)",
                    new { TourId = booking.Tour.Id, Name = booking.Name, Email = booking.Email, Transport = booking.Transport });

                _dataSync.SyncBooking(booking);
            }
        }
    }
}
