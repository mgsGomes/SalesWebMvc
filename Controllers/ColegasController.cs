using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using SalesWebMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class ColegasController : Controller
    {
        private readonly SalesWebMvcContext _context;
        private readonly ColegaService _colegaService;

        public ColegasController(SalesWebMvcContext context, ColegaService colegaService)
        {
            _context = context;
            _colegaService = colegaService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _colegaService.FindAllAsync();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Colega colega)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colega);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(colega);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colega = await _context.Colega.FindAsync(id);
            if (colega == null)
            {
                return NotFound();
            }
            return View(colega);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Colega colega)
        {
            if (id != colega.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colega);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColegaExists(colega.Id))
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
            return View(colega);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colega = await _context.Colega
                .FirstOrDefaultAsync(m => m.Id == id);
            if (colega == null)
            {
                return NotFound();
            }

            return View(colega);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var colega = await _context.Colega.FindAsync(id);
            _context.Colega.Remove(colega);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColegaExists(int id)
        {
            return _context.Colega.Any(e => e.Id == id);
        }
    }
}
