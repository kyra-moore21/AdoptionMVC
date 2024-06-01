using AdoptionMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdoptionMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AddAPet()
        {

        return View(); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        AdoptiondbContext dbContext = new AdoptiondbContext();
        public IActionResult Index()
        {
            List<Animal> result = dbContext.Animals.ToList();
            return View(result);
        }
        public IActionResult ListByBreed(string breed)
        {
            List<Animal> result = dbContext.Animals.Where(p => p.Breed == breed).ToList();
            return View(result);

        }
        public IActionResult Result(Animal a)
        {
            dbContext.Animals.Add(a);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        //public IActionResult AdoptAnAnimal(Animal a) {
    }

}

