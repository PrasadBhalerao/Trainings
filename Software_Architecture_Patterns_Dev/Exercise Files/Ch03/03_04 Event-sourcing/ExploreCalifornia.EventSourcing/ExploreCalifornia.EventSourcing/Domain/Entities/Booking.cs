using ExploreCalifornia.EventSourcing.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.EventSourcing.Domain.Entities
{
    public class Booking : EventSourced
    {
        private Booking(Guid id) : base(id)
        {
            Handles<TourBooked>(OnTourBooked);
            Handles<BookingCanceled>(OnBookingCanceled);
        }

        /// <summary>
        /// Create a brand new booking.
        /// </summary>
        public Booking(Guid id, int tourId, string name, string email, bool transport) : this(id)
        {
            Update(new TourBooked
            { 
                TourId = tourId, 
                Name = name, 
                Email = email, 
                Transport = transport 
            });
        }

        /// <summary>
        /// Create a Booking object from a list of previous events.
        /// </summary>
        public Booking(Guid id, IEnumerable<VersionedEvent> history) : this(id)
        {
            LoadFrom(history);
        }

        public void Cancel(string reason)
        {
            Update(new BookingCanceled 
            { 
                Email = Email, 
                Name = Name, 
                TourId = TourId, 
                Reason = reason });
        }

        private void OnTourBooked(TourBooked tourBooked)
        {
            TourId = tourBooked.TourId;
            Name = tourBooked.Name;
            Email = tourBooked.Email;
            Transport = tourBooked.Transport;
        }

        private void OnBookingCanceled(BookingCanceled bookingCanceled)
        {
            IsCanceled = true;
            CancellationReason = bookingCanceled.Reason;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public bool Transport { get; private set; }
        public int TourId { get; private set; }
        public bool IsCanceled { get; private set; }
        public string CancellationReason { get; private set; }
    }
}
