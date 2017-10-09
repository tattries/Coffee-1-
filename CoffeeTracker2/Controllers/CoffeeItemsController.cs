using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoffeeTracker.Models;

namespace CoffeeTracker.Controllers
{
    public class CoffeeItemsController : Controller
    {
        private readonly CoffeeTrackerContext _context;

        public CoffeeItemsController(CoffeeTrackerContext context)
        {
            _context = context;
        }

        // GET: CoffeeItems
        public async Task<IActionResult> Index(string profileId)
        {
            var profiles = _context.UserProfile.ToList();
            ViewBag.Profiles = profiles;
            

            if (profileId == null)
            {
                profileId = "0";
                if (profiles != null && profiles.Count > 0)
                    profileId = profiles.First().Id;
            }

            ViewBag.ProfileId= profileId;
          
            return View(await _context.CoffeeItems.Where(item=>item.ProfileId == profileId).ToListAsync());
        }

        // GET: CoffeeItems/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffeeItems = await _context.CoffeeItems
                .SingleOrDefaultAsync(m => m.Id == id);
            if (coffeeItems == null)
            {
                return NotFound();
            }

            return View(coffeeItems);
        }

        // GET: CoffeeItems/Create
        public IActionResult Create(string profileId)
        {
            ViewBag.ProfileId =  profileId;
            return View();
        }

        // POST: CoffeeItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,ProfileId,CreationDate,CoffeeType,CoffeeSize")] CoffeeItems coffeeItems)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coffeeItems);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { profileId = coffeeItems.ProfileId });
            }
            return View(coffeeItems);
        }

        // GET: CoffeeItems/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffeeItems = await _context.CoffeeItems.SingleOrDefaultAsync(m => m.Id == id);
            if (coffeeItems == null)
            {
                return NotFound();
            }
            return View(coffeeItems);
        }

        // POST: CoffeeItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Description,ProfileId,CreationDate,CoffeeType,CoffeeSize")] CoffeeItems coffeeItems)
        {
            if (id != coffeeItems.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coffeeItems);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoffeeItemsExists(coffeeItems.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { profileId = coffeeItems.ProfileId });
            }
            return View(coffeeItems);
        }

        // GET: CoffeeItems/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffeeItems = await _context.CoffeeItems
                .SingleOrDefaultAsync(m => m.Id == id);
            if (coffeeItems == null)
            {
                return NotFound();
            }

            return View(coffeeItems);
        }

        // POST: CoffeeItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var coffeeItems = await _context.CoffeeItems.SingleOrDefaultAsync(m => m.Id == id);
            _context.CoffeeItems.Remove(coffeeItems);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { profileId = coffeeItems.ProfileId });
        }

        private bool CoffeeItemsExists(string id)
        {
            return _context.CoffeeItems.Any(e => e.Id == id);
        }


        public async Task<IActionResult> GoTo(string id)
        {
            return View(await _context.CoffeeItems.ToListAsync());
        }
       
    }
}
