using JkShop.Data;
using JkShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JkShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private ApplicationDbContext _db;

        public CategoriesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Categories.ToList());
        }

        //GET Create Action Method

        public ActionResult Create()
        {
            return View();
        }

        //POST Create Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Categories categories)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(categories);
                await _db.SaveChangesAsync();
                TempData["save"] = "Category has been saved";
                return RedirectToAction(nameof(Index));
            }

            return View(categories);
        }

        //GET Edit Action Method

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categories = _db.Categories.Find(id);
            if (categories == null)
            {
                return NotFound();
            }
            return View(categories);
        }

        //POST Edit Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Categories categories)
        {
            if (ModelState.IsValid)
            {
                _db.Update(categories);
                await _db.SaveChangesAsync();
                TempData["edit"] = "Categories has been updated";
                return RedirectToAction(nameof(Index));
            }

            return View(categories);
        }

        //GET Details Action Method

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categories = _db.Categories.Find(id);
            if (categories == null)
            {
                return NotFound();
            }
            return View(categories);
        }

        //POST Details Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(Categories categories)
        {
            return RedirectToAction(nameof(Index));

        }

        //GET Delete Action Method

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categories = _db.Categories.Find(id);
            if (categories == null)
            {
                return NotFound();
            }
            return View(categories);
        }

        

    }
}
    