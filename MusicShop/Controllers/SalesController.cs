using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicShop.Models;

namespace MusicShop.Controllers
{
    public class SalesController : Controller
    {
        private readonly MusicShopContentContext _context;

        public SalesController(MusicShopContentContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var sales = _context.Sales.ToList();
            return View(sales);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sales = _context.Sales
                .FirstOrDefault(m => m.ID == id);
            if (sales == null)
            {
                return NotFound();
            }

            return View(sales);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind ("ID,ProductID,Date,PaymentMethod,Total")] Sales sales)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sales);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(sales);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sales = _context.Sales.Find(id);
            if (sales == null)
            {
                return NotFound();
            }
            return View(sales);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(int id, [Bind ("ID,ProductID,Date,PaymentMethod,Total") ] Sales sales )
        {
            if (id != sales.ID)
            {
                return NotFound();
            }

            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sales);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!SalesExists(sales.ID))
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
            return View(sales);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sales = _context.Sales
                .FirstOrDefault(m => m.ID == id);
            if (sales == null)
            {
                return NotFound();
            }
            return View(sales);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteConfirmed(int id)
        {

            var sales = _context.Sales.Find(id);
            _context.Sales.Remove(sales);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesExists(int iD)
        {
            return _context.Sales.Any(e => e.ID == iD);
        }
    }
}