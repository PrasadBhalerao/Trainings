using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HPlusSportsWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace HPlusSportsWeb. Controllers
{
    public class AdminController : Controller
    {
        //Add Product
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index(Product newProduct)
        {
            //Call API to add new product
            return View();
        }

        /* add operation for adding image to product
         * this will add the image to blob storage and update the data store with the link */

    }
}