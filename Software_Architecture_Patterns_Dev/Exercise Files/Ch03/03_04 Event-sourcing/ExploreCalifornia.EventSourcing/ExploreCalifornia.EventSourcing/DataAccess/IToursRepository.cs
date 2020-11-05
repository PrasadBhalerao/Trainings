using System.Collections.Generic;
using ExploreCalifornia.EventSourcing.Domain;

namespace ExploreCalifornia.EventSourcing.DataAccess
{
    public interface IToursRepository
    {
        IList<Tour> GetTours();
        Tour GetTour(int id);
    }
}
