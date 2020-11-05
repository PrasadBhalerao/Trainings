using System.Collections.Generic;

namespace ExploreCalifornia.Business.Tours
{
    public interface IToursService
    {
        IEnumerable<Tour> GetTours();
        Tour GetTour(int id);
    }
}