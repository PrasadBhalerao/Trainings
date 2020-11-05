using System.Collections.Generic;
using ExploreCalifornia.Website.Domain.ReadModel;

namespace ExploreCalifornia.Website.DataAccess.ReadModel
{
    public interface IToursRepository
    {
        IList<Tour> GetTours();
        Tour GetTour(int id);
    }
}