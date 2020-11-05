using System.Collections.Generic;
using System.Linq;
using Dapper;
using ExploreCalifornia.Website.Domain.ReadModel;
using ExploreCalifornia.Website.Domain.WriteModel;
using Microsoft.Data.Sqlite;

namespace ExploreCalifornia.Website.DataAccess.ReadModel
{
    public class BookingOverviewItemRepository : IBookingOverviewItemRepository
    {
        private readonly string _connectionString;

        public BookingOverviewItemRepository()
        {
            _connectionString = "Data Source=AppData/cqrs-read-database.db;";
        }

        public IList<BookingOverviewItem> GetBookingOverviewItems()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                var items = connection.Query<BookingOverviewItem>("SELECT BookingId, Name, Email, Transport, TourName FROM BookingOverviewItem");
                return items.ToList();
            }
        }

        public void Save(BookingOverviewItem bookingOverviewItem)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Execute(
                    "INSERT INTO BookingOverviewItem (BookingId, Name, Email, Transport, TourName) VALUES (@BookingId, @Name, @Email, @Transport, @TourName)",
                    new { BookingId = bookingOverviewItem.BookingId, Name = bookingOverviewItem.Name, Email = bookingOverviewItem.Email, Transport = bookingOverviewItem.Transport, TourName = bookingOverviewItem.TourName });
            }
        }
    }
}