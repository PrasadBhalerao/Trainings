using System.Collections.Generic;

namespace ExploreCalifornia.ToursService.Contracts
{
    public class Tours
    {
        public IList<Tour> Data { get; set; }
        public int Count { get; set; }
    }
}