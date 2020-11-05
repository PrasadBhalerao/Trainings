using System.Collections.Generic;
using ExploreCalifornia.Website.DataAccess.ReadModel;
using ExploreCalifornia.Website.Domain.ReadModel;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExploreCalifornia.Website.Pages
{
    public class ToursModel : PageModel
    {
        private readonly IToursRepository _repository;

        public ToursModel(IToursRepository repository)
        {
            _repository = repository;
        }

        public void OnGet()
        {
            Tours = _repository.GetTours();
        }

        public IEnumerable<Tour> Tours { get; private set; }
    }
}
