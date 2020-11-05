using System.Collections.Generic;
using ExploreCalifornia.Website.Domain.WriteModel;

namespace ExploreCalifornia.Website.DataAccess.WriteModel
{
    public interface IToursRepository
    {
        IList<Tour> GetTours();
        Tour GetTour(int id);
    }
}
