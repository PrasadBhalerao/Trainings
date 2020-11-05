using System.Collections.Generic;

namespace ExploreCalifornia.Website.ExternalServices.Tours
{
    public interface IToursProxy
    {
        IEnumerable<Models.Tour> GetTours();
        Models.Tour GetTour(int id);
    }
}
