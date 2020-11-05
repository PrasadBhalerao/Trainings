using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HPlusSportsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET api/product
        [HttpGet]
        public JsonResult Get()
        {
            List<Models.Product> products = GetProducts();

            return new JsonResult(products);
        }

        private static List<Models.Product> GetProducts()
        {
            var serializer = JsonSerializer.CreateDefault();
            var textReader = new StringReader(@"[
    {
        'id': '259',
        'name': 'Raspberry Mineral Water',
        'description': 'An 8-ounce serving of our refreshing H+ Sport raspberry mineral water fulfills a day\'s nutritional requirements for over 12 vitamins and minerals.',
        'imageTitle': 'mineralwater-raspberry',
        'image': '/images/products/mineralwater-raspberry.jpg'
    },
    {
        'id': '429',
        'name': 'Strawberry Mineral Water',
        'description': 'An 8-ounce serving of our refreshing H+ Sport strawberry mineral water fulfills a day\'s nutritional requirements for over 12 vitamins and minerals.',
        'imageTitle': 'mineralwater-strawberry',
        'image': '/images/products/mineralwater-strawberry.jpg'
    },
    {
        'id': '436',
        'name': 'Blueberry Mineral Water',
        'description': 'An 8-ounce serving of our refreshing H+ Sport blueberry mineral water fulfills a day\'s nutritional requirements for over 12 vitamins and minerals.',
        'imageTitle': 'minearlwater-blueberry',
        'image': '/images/products/mineralwater-blueberry.jpg'
    },
    {
        'id': '437',
        'name': 'Lemon-Lime Mineral Water',
        'description': 'An 8-ounce serving of our refreshing H+ Sport lemon-lime\u00a0mineral water fulfills a day\'s nutritional requirements for over 12 vitamins and minerals',
        'imageTitle': 'mineralwater-lemonlime',
        'image': '/images/products/mineralwater-lemonlime.jpg'
    },
    {
        'id': '438',
        'name': 'Peach Mineral Water',
        'description': 'An 8-ounce serving of our refreshing H+ Sport peach mineral water \u00a0fulfills a day\'s nutritional requirements for over 12 vitamins and minerals.',
        'imageTitle': 'mineralwater-peach',
        'image': '/images/products/mineralwater-peach.jpg'
    },
    {
        'id': '439',
        'name': 'Orange Mineral Water',
        'description': 'An 8-ounce serving of refreshing H+ Sport orange mineral water fulfills a day\'s nutritional requirements for over 12 vitamins and minerals.',
        'imageTitle': 'mineralwater-orange',
        'image': '/images/products/mineralwater-orange.jpg'
    },
    {
        'id': '440',
        'name': 'Multi-Vitamin (90 capsules)',
        'description': 'A daily dose of our Multi-Vitamins fulfills a day\'s nutritional needs for over 12 vitamins and minerals.',
        'imageTitle': 'multi-vitamin',
        'image': '/images/products/vitamin-multi.jpg'
    },
    {
        'id': '471',
        'name': 'Flaxseed Oil 1000 mg (90 capsules)',
        'description': 'Our Flaxseed Oil contains Omegas 3, 6, and 9 for a heart-healthy option without the use of fish oil.',
        'imageTitle': 'flaxseed-oil',
        'image': '/images/products/vitamin-flaxseed-oil.jpg'
    },
    {
        'id': '472',
        'name': 'Magnesium 250 mg (100 tablets)',
        'description': 'Magnesium is critical to many bodily processes, and supports nerve, muscle, and heart function.',
        'imageTitle': 'magnesium',
        'image': '/images/products/vitamin-magnesium.jpg'
    },
    {
        'id': '473',
        'name': 'Iron 65 mg (150 caplets)',
        'description': 'Iron is essential for transporting oxygen in the body and for the formation of red blood cells.',
        'imageTitle': 'iron',
        'image': '/images/products/vitamin-iron.jpg'
    },
    {
        'id': '474',
        'name': 'Calcium 400 IU (150 tablets)',
        'description': 'Our Calcium supports strong bones and teeth and may help prevent osteoporosis.<strong>\u00a0</strong>',
        'imageTitle': 'calcium',
        'image': '/images/products/vitamin-calcium.jpg'
    },
    {
        'id': '475',
        'name': 'Vitamin D3 1000 IU (100 tablets)',
        'description': 'Vitamin D<sub>3</sub> is the body\u0092s preferred form of Vitamin D, and helps support bone, teeth, and immune health.',
        'imageTitle': 'vitamin-d',
        'image': '/images/products/vitamin-D.jpg'
    },
    {
        'id': '476',
        'name': 'Vitamin A 10,000 IU (125 caplets)',
        'description': 'Vitamin A is essential for normal and night vision, and helps maintain healthy skin and mucous membranes.',
        'imageTitle': 'vitamin-a',
        'image': '/images/products/vitamin-A.jpg'
    },
    {
        'id': '477',
        'name': 'Vitamin C 1000 mg (100 tablets)',
        'description': 'Protects against free radicals and supports the immune system.',
        'imageTitle': 'vitamin-c',
        'image': '/images/products/vitamin-C.jpg'
    },
    {
        'id': '478',
        'name': 'Vitamin B-Complex (100 caplets)',
        'description': 'Contains a combination of essential B vitamins that help convert food to energy.',
        'imageTitle': 'b-complex',
        'image': '/images/products/vitamin-bcomplex.jpg'
    }
]
");

            var reader = new JsonTextReader(textReader);
            var products = serializer.Deserialize<List<Models.Product>>(
                reader);
            return products;
        }

        // GET api/product/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var products = GetProducts();
            var product = products.Find(p => p.ID == id);

            return new JsonResult(product);
        }

        
    }
}
