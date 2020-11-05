using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HPlusSportsWeb.Controllers
{
    public class ProductController : Controller
    {
        HttpClient client;

        public ProductController(HttpClient apiClient)
        {
            client = apiClient;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var response = await client.GetStringAsync("product");
            var products = JArray.Parse(response);
            return View(products);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var response = await client.GetStringAsync($"product/{id}" );

            var product = JsonConvert.DeserializeObject<Models.Product>(response);
            return View(product);
        }
    }
}
