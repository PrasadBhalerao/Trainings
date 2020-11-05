using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExploreCalifornia.EventSourcing.Pages
{
    public class BookingCanceledModel : PageModel
    {
        public string TourName { get; set; }
        public string Name { get; set; }

        public void OnGet()
        {
            TourName = Request.Query["tourname"];
            Name = Request.Query["name"];
        }
    }
}