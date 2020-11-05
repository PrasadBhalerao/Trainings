using System.Collections.Generic;
using ExploreCalifornia.ToursService.Domain;

namespace ExploreCalifornia.ToursService.DataAccess
{
    public interface IToursRepository
    {
        IList<Tour> GetTours();
        Tour GetTour(int id);
    }
}