using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HPlusSportsWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace HPlusSportsWeb.Controllers
{
    public class CartController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Order order)
        {
            return Ok();
        }

        public IActionResult OrderComplete()
        {
            return View();
        }
    }
}