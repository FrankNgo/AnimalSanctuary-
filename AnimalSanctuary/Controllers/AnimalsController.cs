using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AnimalSanctuary.Models;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Controllers
{
    public class ItemsController : Controller
    {
        private IAnimalRepository itemRepo;  // New!

        public ItemsController()
        {
            itemRepo = new EFAnimalRepository();
        }
        public ItemsController(IItemRepository repo)
        {
            itemRepo = repo;
        }

        public ViewResult Index()
        {
            // Updated:
            return View(itemRepo.Animals.ToList());
        }

        public IActionResult Details(int id)
        {
            // Updated:
            Animal thisItem = itemRepo.Animals.FirstOrDefault(x => x.ItemId == id);
            return View(thisItem);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Animal animal)
        {
            itemRepo.Save(item);   // Updated
            // Removed db.SaveChanges() call
            //return RedirectToAction("Index");
            return View("Index");

        }

        public IActionResult Edit(int id)
        {
            // Updated:
            Animal thisItem = itemRepo.Animal.FirstOrDefault(x => x.ItemId == id);
            return View(thisItem);
        }

        [HttpPost]
        public IActionResult Edit(Animal item)
        {
            itemRepo.Edit(item);   // Updated!
            // Removed db.SaveChanges() call
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            // Updated:
            Animal thisItem = itemRepo.Animals.FirstOrDefault(x => x.ItemId == id);
            return View(thisItem);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            // Updated:
            Animal thisAnimal = itemRepo.Animals.FirstOrDefault(x => x.ItemId == id);
            itemRepo.Remove(thisItem);   // Updated!
            // Removed db.SaveChanges() call
            return RedirectToAction("Index");
        }
    }
}