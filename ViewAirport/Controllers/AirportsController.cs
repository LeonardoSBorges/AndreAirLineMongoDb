﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ViewAirport.Data;
using ViewAirport.Models;

namespace ViewAirport.Controllers
{
    public class AirportsController : Controller
    {
        private readonly ViewAirportContext _context;

        public AirportsController(ViewAirportContext context)
        {
            _context = context;
        }

        // GET: Airports
        public async Task<IActionResult> Index()
        {
            return View(await _context.Airport.ToListAsync());
        }

        // GET: Airports/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airport = await _context.Airport
                .FirstOrDefaultAsync(m => m.Iata == id);
            if (airport == null)
            {
                return NotFound();
            }

            return View(airport);
        }

        // GET: Airports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Airports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Iata,Name")] Airport airport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(airport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(airport);
        }

        // GET: Airports/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airport = await _context.Airport.FindAsync(id);
            if (airport == null)
            {
                return NotFound();
            }
            return View(airport);
        }

        // POST: Airports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Iata,Name")] Airport airport)
        {
            if (id != airport.Iata)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(airport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AirportExists(airport.Iata))
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
            return View(airport);
        }

        // GET: Airports/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airport = await _context.Airport
                .FirstOrDefaultAsync(m => m.Iata == id);
            if (airport == null)
            {
                return NotFound();
            }

            return View(airport);
        }

        // POST: Airports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var airport = await _context.Airport.FindAsync(id);
            _context.Airport.Remove(airport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AirportExists(string id)
        {
            return _context.Airport.Any(e => e.Iata == id);
        }
    }
}
