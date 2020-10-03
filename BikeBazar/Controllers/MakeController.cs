using BikeBazar.AppDbContext;
using BikeBazar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Linq;

namespace BikeBazar.Controllers
{
    public class MakeController : Controller
    {
        private readonly BikeDbContext _context;
        public MakeController(BikeDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var getAllData = _context.Makes.ToList();
            return View(getAllData);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Make make)
        {
            if(ModelState.IsValid)
            {
                _context.Add(make);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }    
            return View(make);
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var make = _context.Makes.Find(id);
            if(make == null)
            {
                return NotFound();
            }
            _context.Makes.Remove(make);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var make = _context.Makes.Find(id);
            if (make == null)
            {
                return NotFound();
            }
            return View(make);
        }

        [HttpPost]
        public IActionResult Edit(Make make)
        {
            if (ModelState.IsValid)
            {
                _context.Update(make);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(make);
        }

    }
}
