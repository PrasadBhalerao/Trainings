using System.Collections.Generic;
using ExploreCalifornia.PresentationTier.Models;

namespace ExploreCalifornia.PresentationTier.Business
{
    public interface IToursProxy
    {
        IList<Tour> GetTours();
        Tour GetTour(int id);
    }
}
