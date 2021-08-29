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
    public class TagController : Controller
    {
        private ApplicationDbContext _db;

        public TagController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Tags.ToList());
        }

        //GET Create Action Method

        public ActionResult Create()
        {
            return View();
        }

        //POST Create Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tag tag)
        {
            if (ModelState.IsValid)
            {
                _db.Tags.Add(tag);
                await _db.SaveChangesAsync();
                TempData["save"] = "Tag has been saved";
                return RedirectToAction(nameof(Index));
            }

            return View(tag);
        }

        //GET Edit Action Method

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = _db.Tags.Find(id);
            if (tag == null)
            {
                return NotFound();
            }
            return View(tag);
        }

        //POST Edit Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Tag tag)
        {
            if (ModelState.IsValid)
            {
                _db.Update(tag);
                await _db.SaveChangesAsync();
                TempData["edit"] = "Tag has been updated";
                return RedirectToAction(nameof(Index));
            }

            return View(tag);
        }

        //GET Details Action Method

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = _db.Tags.Find(id);
            if (tag == null)
            {
                return NotFound();
            }
            return View(tag);
        }

        //POST Details Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(Tag tag)
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

            var tag = _db.Tags.Find(id);
            if (tag == null)
            {
                return NotFound();
            }
            return View(tag);
        }

        //POST Delete Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, Tag tag)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (id != tag.Id)
            {
                return NotFound();
            }

            var Name = _db.Tags.Find(id);
            if (Name == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Remove(Name);
                await _db.SaveChangesAsync();
                TempData["delete"] = "Tag has been deleted";
                return RedirectToAction(nameof(Index));
            }

            return View(tag);
        }


    }
}
