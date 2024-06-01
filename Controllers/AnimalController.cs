using AdoptionMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdoptionMVC.Controllers
{
    public class AnimalController : Controller
    {
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
        public IActionResult ConfirmAdoption(int id)
        {
            Animal result = dbContext.Animals.FirstOrDefault(p => p.Id == id);
            return View(result);
        }

        public IActionResult Delete(int id)
        {

            Animal result = dbContext.Animals.FirstOrDefault(p => p.Id == id);
            dbContext.Animals.Remove(result);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");

        }

    }
}
