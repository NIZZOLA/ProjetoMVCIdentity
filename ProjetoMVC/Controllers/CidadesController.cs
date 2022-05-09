#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoMVC.Data;
using ProjetoMVC.Models;

namespace ProjetoMVC.Controllers
{
    public class CidadesController : Controller
    {
        private readonly ProjetoMVCContext _context;

        public CidadesController(ProjetoMVCContext context)
        {
            _context = context;
        }

        // GET: Cidades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cidades.ToListAsync());
        }

        // GET: Cidades/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidadeModel = await _context.Cidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cidadeModel == null)
            {
                return NotFound();
            }

            return View(cidadeModel);
        }

        // GET: Cidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NomeCidade,Estado,Id")] CidadeModel cidadeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cidadeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cidadeModel);
        }

        // GET: Cidades/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidadeModel = await _context.Cidades.FindAsync(id);
            if (cidadeModel == null)
            {
                return NotFound();
            }
            return View(cidadeModel);
        }

        // POST: Cidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("NomeCidade,Estado,Id")] CidadeModel cidadeModel)
        {
            if (id != cidadeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cidadeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CidadeModelExists(cidadeModel.Id))
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
            return View(cidadeModel);
        }

        // GET: Cidades/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidadeModel = await _context.Cidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cidadeModel == null)
            {
                return NotFound();
            }

            return View(cidadeModel);
        }

        // POST: Cidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            var cidadeModel = await _context.Cidades.FindAsync(id);
            _context.Cidades.Remove(cidadeModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CidadeModelExists(Guid? id)
        {
            return _context.Cidades.Any(e => e.Id == id);
        }
    }
}
