using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaWebVendas.Data;
using SistemaWebVendas.Models;

namespace SistemaWebVendas.Controllers
{
    public class RegistroDeVendasController : Controller
    {
        private readonly SistemaWebVendasContext _context;

        public RegistroDeVendasController(SistemaWebVendasContext context)
        {
            _context = context;
        }

        // GET: RegistroDeVendas
        public async Task<IActionResult> Index()
        {
            return View(await _context.RegistroDeVendas.ToListAsync());
        }

        // GET: RegistroDeVendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroDeVendas = await _context.RegistroDeVendas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registroDeVendas == null)
            {
                return NotFound();
            }

            return View(registroDeVendas);
        }

        // GET: RegistroDeVendas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegistroDeVendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data,Montante,Status")] RegistroDeVendas registroDeVendas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroDeVendas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registroDeVendas);
        }

        // GET: RegistroDeVendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroDeVendas = await _context.RegistroDeVendas.FindAsync(id);
            if (registroDeVendas == null)
            {
                return NotFound();
            }
            return View(registroDeVendas);
        }

        // POST: RegistroDeVendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data,Montante,Status")] RegistroDeVendas registroDeVendas)
        {
            if (id != registroDeVendas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroDeVendas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroDeVendasExists(registroDeVendas.Id))
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
            return View(registroDeVendas);
        }

        // GET: RegistroDeVendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroDeVendas = await _context.RegistroDeVendas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registroDeVendas == null)
            {
                return NotFound();
            }

            return View(registroDeVendas);
        }

        // POST: RegistroDeVendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registroDeVendas = await _context.RegistroDeVendas.FindAsync(id);
            _context.RegistroDeVendas.Remove(registroDeVendas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> PesquisaSimples(DateTime? dtmin, DateTime? dtmax)
        {
            if (!dtmin.HasValue)
            {
                dtmin = DateTime.Now;
            }

            if (!dtmax.HasValue)
            {
                dtmax = DateTime.Now;
            }

            ViewData["dtmin"] = dtmin.Value.ToString("yyyy-MM-dd");
            ViewData["dtmax"] = dtmax.Value.ToString("yyyy-MM-dd");

            var result = await BuscarPorData(dtmin, dtmax);
            return View(result);
        }

        public async Task<IActionResult> PesquisaGrupos()
        {
            return View();
        }

        private bool RegistroDeVendasExists(int id)
        {
            return _context.RegistroDeVendas.Any(e => e.Id == id);
        }

        private async Task<List<RegistroDeVendas>> BuscarPorData(DateTime? dtmin, DateTime? dtmax)
        {
            var result = from obj in _context.RegistroDeVendas select obj;
            if (dtmin.HasValue)
            {
                result = result.Where(x => x.Data >= dtmin.Value);
            }
            if (dtmax.HasValue)
            {
                result = result.Where(x => x.Data <= dtmax.Value);
            }

            return await result.Include(x => x.Vendedor).Include(x => x.Vendedor.Departamento).OrderByDescending(x => x.Data).ToListAsync();
        }
    }
}
