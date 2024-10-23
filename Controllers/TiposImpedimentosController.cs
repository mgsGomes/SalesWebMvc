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
    public class TiposImpedimentosController : Controller
    {
        private readonly SalesWebMvcContext _context;
        private readonly TipoImpedimentoService _tipoImpedimentoService;

        public TiposImpedimentosController(SalesWebMvcContext context, TipoImpedimentoService tipoImpedimentoService)
        {
            _context = context;
            _tipoImpedimentoService = tipoImpedimentoService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _tipoImpedimentoService.FindAllAsync();
            return View(list);
        }

        public IActionResult Create()
        {            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Impedimento")] TipoImpedimento tipoImpedimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoImpedimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoImpedimento);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoImpedimento = await _context.TipoImpedimento.FindAsync(id);
            if (tipoImpedimento == null)
            {
                return NotFound();
            }
            return View(tipoImpedimento);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Impedimento")] TipoImpedimento tipoImpedimento)
        {
            if (id != tipoImpedimento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoImpedimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoImpedimentoExists(tipoImpedimento.Id))
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
            return View(tipoImpedimento);
        }
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoImpedimento = await _context.TipoImpedimento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoImpedimento == null)
            {
                return NotFound();
            }

            return View(tipoImpedimento);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoImpedimento = await _context.TipoImpedimento.FindAsync(id);
            _context.TipoImpedimento.Remove(tipoImpedimento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoImpedimentoExists(int id)
        {
            return _context.TipoImpedimento.Any(e => e.Id == id);
        }
    }
}
