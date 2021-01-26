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
    public class SalePersonsController : Controller
    {
        private readonly CarGlamContext _context;

        public SalePersonsController(CarGlamContext context)
        {
            _context = context;
        }
       
        // GET: SalePersons
        public async Task<IActionResult> Index()
        {
            return View(await _context.SalePerson.ToListAsync());
        }

        // GET: SalePersons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salePerson = await _context.SalePerson
                .FirstOrDefaultAsync(m => m.SalePersonId == id);
            if (salePerson == null)
            {
                return NotFound();
            }

            return View(salePerson);
        }
        [Authorize]
        // GET: SalePersons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalePersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalePersonId,SalePersonsName,AgreedAmount,SaleDate")] SalePerson salePerson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salePerson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salePerson);
        }

        // GET: SalePersons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salePerson = await _context.SalePerson.FindAsync(id);
            if (salePerson == null)
            {
                return NotFound();
            }
            return View(salePerson);
        }

        // POST: SalePersons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalePersonId,SalePersonsName,AgreedAmount,SaleDate")] SalePerson salePerson)
        {
            if (id != salePerson.SalePersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salePerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalePersonExists(salePerson.SalePersonId))
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
            return View(salePerson);
        }
        [Authorize]

        // GET: SalePersons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salePerson = await _context.SalePerson
                .FirstOrDefaultAsync(m => m.SalePersonId == id);
            if (salePerson == null)
            {
                return NotFound();
            }

            return View(salePerson);
        }

        // POST: SalePersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salePerson = await _context.SalePerson.FindAsync(id);
            _context.SalePerson.Remove(salePerson);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalePersonExists(int id)
        {
            return _context.SalePerson.Any(e => e.SalePersonId == id);
        }
    }
}
