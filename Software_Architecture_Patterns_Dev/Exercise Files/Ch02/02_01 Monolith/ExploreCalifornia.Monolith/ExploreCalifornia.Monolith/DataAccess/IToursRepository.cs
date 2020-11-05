using System.Collections.Generic;
using ExploreCalifornia.Monolith.Domain;

namespace ExploreCalifornia.Monolith.DataAccess
{
    public interface IToursRepository
    {
        IList<Tour> GetTours();
        Tour GetTour(int id);
    }
}