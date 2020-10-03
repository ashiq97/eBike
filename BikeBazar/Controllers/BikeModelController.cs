using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeBazar.AppDbContext;
using BikeBazar.Models;
using BikeBazar.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeBazar.Controllers
{
    public class BikeModelController : Controller
    {
        private readonly BikeDbContext _context;
        public BikeModelVM ModelVM { get; set; }
        public BikeModelController(BikeDbContext context)
        {
            _context = context;
            ModelVM = new BikeModelVM()
            {
                Makes = _context.Makes.ToList(),
                BikeModel = new Models.BikeModel()
            };
        }
        public IActionResult Index()
        {
            //  eager loading approach
            /* eager loading is entity framework processing mechanism where run 1 query for 1 entity and loads is associated entity.
               we do not need to write seperate query for loading associated entity
            */
            var bikeModelWithMake = _context.BikeModels.Include(m => m.Make);
            return View(bikeModelWithMake);
        }
        public IActionResult Create()
        {
            return View(ModelVM);
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost(BikeModelVM bikeModelVM)
        {
            if (!ModelState.IsValid)
            {
                return View(ModelVM);
            }
            _context.BikeModels.Add(bikeModelVM.BikeModel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    
        public IActionResult Edit(int id)
        {
             ModelVM.BikeModel = _context.BikeModels.Include(m => m.Make).SingleOrDefault(b => b.Id == id);
            if(ModelVM.BikeModel == null)
            {
                return NotFound();
            }
            return View(ModelVM);
        }

        [HttpPost,ActionName("Edit")]
        public IActionResult EditPost(BikeModelVM bikeModelVM)
        {
            if(!ModelState.IsValid)
            {
                return View(ModelVM);
            }
            _context.Update(bikeModelVM.BikeModel);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var model = _context.BikeModels.Find(id);
            if(model == null)
            {
                return NotFound();
            }
            _context.BikeModels.Remove(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
