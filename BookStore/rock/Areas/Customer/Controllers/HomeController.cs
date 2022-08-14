using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using rock.DataAccess.Repository.IRepository;
using rock.Models;

namespace rock.Controllers { 
[Area("Customer")]
    public class HomeController : Controller
    { 
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productlist = _unitOfWork.product.GetAll(includeProperties:"Category,CoverType");
            return View(productlist);
        }
        public IActionResult Details(int id)
        {
            ShoppingCart cartObj = new()
            {
                Count = 1,
                product = _unitOfWork.product.GetFirstOrDefault(u => u.Id == id, includeProperties: "Category,CoverType"),
            };
            return View(cartObj);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
