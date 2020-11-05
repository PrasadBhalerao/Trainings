namespace ExploreCalifornia.Website.DataAccess
{

    public interface IDataSync
    {
        void SyncBooking(Domain.WriteModel.Booking booking);
    }
}