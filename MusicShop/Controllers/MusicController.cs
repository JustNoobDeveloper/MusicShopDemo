using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicShop.Models;

namespace MusicShop.Controllers
{
    public class MusicController : Controller
    {
        private readonly MusicShopContentContext _context;

        public MusicController(MusicShopContentContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Music.Include(g => g.Genre).ToList());
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var music = _context.Music
                .FirstOrDefault(m => m.ID == id);
            if (music == null)
            {
                return NotFound();
            }

            return View(music);
        }

        public IActionResult Create()
        {
            ViewBag.Genre   = new SelectList(_context.Genre, "ID", "GenreName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind ("ID,MusicName,ArtistName,Price,Quantity,GenreId")] Music music)
        {
            if (ModelState.IsValid)
            {
                _context.Add(music);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            return View(music);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var music = _context.Music.Find(id);
            if (music == null)
            {
                return NotFound();
            }
            ViewBag.Genre = new SelectList(_context.Genre, "ID", "GenreName");
            return View(music);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit( int id, [Bind("ID,MusicName,ArtistName,Price,Quantity,GenreId")] Music music)
        {
            if ( id != music.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(music);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!MusicExists(music.ID))
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
            return View(music);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var music = _context.Music
                .FirstOrDefault(m => m.ID == id);
            if (music == null)
            {
                return NotFound();
            }
            ViewBag.Genre = new SelectList(_context.Genre, "ID", "GenreName");
            return View(music);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed (int id)
        {
            var music = _context.Music.Find(id);
            _context.Music.Remove(music);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool MusicExists(int Id)
        {
            return _context.Music.Any(e => e.ID == Id);
        }
    }
}