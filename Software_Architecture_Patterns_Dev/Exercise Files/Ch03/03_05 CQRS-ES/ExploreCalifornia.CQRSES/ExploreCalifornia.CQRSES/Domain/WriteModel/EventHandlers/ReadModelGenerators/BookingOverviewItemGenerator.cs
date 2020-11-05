using ExploreCalifornia.CQRSES.DataAccess;
using ExploreCalifornia.CQRSES.DataAccess.ReadModel;
using ExploreCalifornia.CQRSES.Domain.Events;
using ExploreCalifornia.CQRSES.Domain.WriteModel.EventHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.CQRSES.Domain.EventHandlers.ReadModelGenerators
{
    /// <summary>
    /// Generates a read model for an overview of bookings.
    /// </summary>
    public class BookingOverviewItemGenerator : IEventHandler<TourBooked>
    {
        private readonly IBookingOverviewItemRepository _bookingOverviewItemRepository;
        private readonly IToursRepository _toursRepository;

        public BookingOverviewItemGenerator(IBookingOverviewItemRepository bookingOverviewItemRepository, IToursRepository toursRepository)
        {
            _bookingOverviewItemRepository = bookingOverviewItemRepository;
            _toursRepository = toursRepository;
        }

        public void Handle(TourBooked e)
        {
            var tour = _toursRepository.GetTour(e.TourId);

            _bookingOverviewItemRepository.Save(
                new ReadModel.BookingOverviewItem
            {
                BookingId = e.EntityId,
                Email = e.Email,
                Name = e.Name,
                Transport = e.Transport,
                TourName = tour.Name
            });
        }
    }
}
