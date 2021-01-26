using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarGlam.Data;
using CarGlam.Models;
using Microsoft.AspNetCore.Authorization;

namespace CarGlam.Controllers
{
    public class CentersController : Controller
    {
        private readonly CarGlamContext _context;

        public CentersController(CarGlamContext context)
        {
            _context = context;
        }

        // GET: Centers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Center.ToListAsync());
        }

        // GET: Centers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var center = await _context.Center
                .FirstOrDefaultAsync(m => m.CenterID == id);
            if (center == null)
            {
                return NotFound();
            }

            return View(center);
        }
        [Authorize]
        // GET: Centers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Centers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CenterID,CenterName,Address,OpeningDate")] Center center)
        {
            if (ModelState.IsValid)
            {
                _context.Add(center);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(center);
        }

        // GET: Centers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var center = await _context.Center.FindAsync(id);
            if (center == null)
            {
                return NotFound();
            }
            return View(center);
        }

        // POST: Centers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CenterID,CenterName,Address,OpeningDate")] Center center)
        {
            if (id != center.CenterID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(center);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CenterExists(center.CenterID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(center);
        }
        [Authorize]

        // GET: Centers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var center = await _context.Center
                .FirstOrDefaultAsync(m => m.CenterID == id);
            if (center == null)
            {
                return NotFound();
            }

            return View(center);
        }

        // POST: Centers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var center = await _context.Center.FindAsync(id);
            _context.Center.Remove(center);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CenterExists(int id)
        {
            return _context.Center.Any(e => e.CenterID == id);
        }
    }
}
