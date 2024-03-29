﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MusicShop.Models
{
    public class GenreController : Controller
    {
        private readonly MusicShopContentContext _context;

        public GenreController(MusicShopContentContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var genres = _context.Genre.ToList();
            return View(genres);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = _context.Genre
                .FirstOrDefault(m => m.ID == id);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,GenreName")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genre);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(genre);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = _context.Genre.Find(id);
            if (genre == null)
            {
                return NotFound();
            }
            return View(genre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,GenreName")] Genre genre)
        {
            if (id != genre.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genre);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenreExists(genre.ID))
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
            return View(genre);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre =  _context.Genre
                .FirstOrDefault(m => m.ID == id);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var genre = _context.Genre.Find(id);
            _context.Genre.Remove(genre);
            _context.SaveChanges();
            ViewBag.Message = "Data Deleted";
            return RedirectToAction(nameof(Index));
        }

        private bool GenreExists(int id)
        {
            return _context.Genre.Any(e => e.ID == id);
        }
    }

}