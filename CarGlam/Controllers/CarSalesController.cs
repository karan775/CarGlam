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
    public class CarSalesController : Controller
    {
        private readonly CarGlamContext _context;

        public CarSalesController(CarGlamContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: CarSales
        public async Task<IActionResult> Index()
        {
            var carGlamContext = _context.CarSale.Include(c => c.Customer).Include(c => c.SalePerson);
            return View(await carGlamContext.ToListAsync());
        }

        // GET: CarSales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carSale = await _context.CarSale
                .Include(c => c.Customer)
                .Include(c => c.SalePerson)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (carSale == null)
            {
                return NotFound();
            }

            return View(carSale);
        }

        // GET: CarSales/Create
        public IActionResult Create()
        {
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerFName");
            ViewData["SalePersonID"] = new SelectList(_context.SalePerson, "SalePersonId", "SalePersonsName");
            return View();
        }

        // POST: CarSales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CustomerID,SalePersonID")] CarSale carSale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carSale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerFName", carSale.CustomerID);
            ViewData["SalePersonID"] = new SelectList(_context.SalePerson, "SalePersonId", "SalePersonsName", carSale.SalePersonID);
            return View(carSale);
        }

        // GET: CarSales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carSale = await _context.CarSale.FindAsync(id);
            if (carSale == null)
            {
                return NotFound();
            }
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerFName", carSale.CustomerID);
            ViewData["SalePersonID"] = new SelectList(_context.SalePerson, "SalePersonId", "SalePersonsName", carSale.SalePersonID);
            return View(carSale);
        }

        // POST: CarSales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CustomerID,SalePersonID")] CarSale carSale)
        {
            if (id != carSale.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carSale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarSaleExists(carSale.ID))
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
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerID", carSale.CustomerID);
            ViewData["SalePersonID"] = new SelectList(_context.SalePerson, "SalePersonId", "SalePersonId", carSale.SalePersonID);
            return View(carSale);
        }

        // GET: CarSales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carSale = await _context.CarSale
                .Include(c => c.Customer)
                .Include(c => c.SalePerson)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (carSale == null)
            {
                return NotFound();
            }

            return View(carSale);
        }

        // POST: CarSales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carSale = await _context.CarSale.FindAsync(id);
            _context.CarSale.Remove(carSale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarSaleExists(int id)
        {
            return _context.CarSale.Any(e => e.ID == id);
        }
    }
}
