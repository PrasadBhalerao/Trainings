using System.Collections.Generic;

namespace ExploreCalifornia.Business.Tours
{
    public interface IToursRepository
    {
        IList<Tour> GetTours();
        Tour GetTour(int id);
    }
}