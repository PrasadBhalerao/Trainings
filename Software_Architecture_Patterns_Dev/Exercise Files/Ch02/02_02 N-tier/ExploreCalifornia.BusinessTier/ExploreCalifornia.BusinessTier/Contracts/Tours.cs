using System.Collections;
using System.Collections.Generic;

namespace ExploreCalifornia.BusinessTier.Contracts
{
    public class Tours
    {
        public IList<Tour> Data { get; set; }
        public int Count { get; set; }
    }
}