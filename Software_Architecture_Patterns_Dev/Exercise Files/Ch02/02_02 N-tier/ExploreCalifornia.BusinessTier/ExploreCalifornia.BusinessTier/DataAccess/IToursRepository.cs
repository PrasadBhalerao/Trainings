using System.Collections.Generic;
using ExploreCalifornia.BusinessTier.Domain;

namespace ExploreCalifornia.BusinessTier.DataAccess
{
    public interface IToursRepository
    {
        IList<Tour> GetTours();
        Tour GetTour(int id);
    }
}