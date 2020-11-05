using System.Collections.Generic;
using ExploreCalifornia.Website.Models;

namespace ExploreCalifornia.Website.ESB
{
    public interface IToursProxy
    {
        IList<Tour> GetTours();
        Tour GetTour(int id);
    }
}
