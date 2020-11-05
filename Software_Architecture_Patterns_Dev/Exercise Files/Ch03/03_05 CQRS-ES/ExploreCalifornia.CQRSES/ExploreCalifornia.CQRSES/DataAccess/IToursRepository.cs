using System.Collections.Generic;
using ExploreCalifornia.CQRSES.Domain;

namespace ExploreCalifornia.CQRSES.DataAccess
{
    public interface IToursRepository
    {
        IList<Tour> GetTours();
        Tour GetTour(int id);
    }
}
