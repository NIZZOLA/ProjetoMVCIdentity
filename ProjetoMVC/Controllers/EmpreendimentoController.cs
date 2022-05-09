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
    public class EmpreendimentoController : Controller
    {
        private readonly ProjetoMVCContext _context;

        public EmpreendimentoController(ProjetoMVCContext context)
        {
            _context = context;
        }

        // GET: Empreendimento
        public async Task<IActionResult> Index()
        {
            var projetoMVCContext = _context.Empreendimentos.Include(e => e.Cliente);
            return View(await projetoMVCContext.ToListAsync());
        }

        // GET: Empreendimento/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empreendimentoModel = await _context.Empreendimentos
                .Include(e => e.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empreendimentoModel == null)
            {
                return NotFound();
            }

            return View(empreendimentoModel);
        }

        // GET: Empreendimento/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.ClientesFornecedores, "Id", "Id");
            return View();
        }

        // POST: Empreendimento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,ClienteId,DataOrcamento,DataInicio,DataPrevistaTermino,DataTermino,Id")] EmpreendimentoModel empreendimentoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empreendimentoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.ClientesFornecedores, "Id", "Id", empreendimentoModel.ClienteId);
            return View(empreendimentoModel);
        }

        // GET: Empreendimento/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empreendimentoModel = await _context.Empreendimentos.FindAsync(id);
            if (empreendimentoModel == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.ClientesFornecedores, "Id", "Id", empreendimentoModel.ClienteId);
            return View(empreendimentoModel);
        }

        // POST: Empreendimento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("Nome,ClienteId,DataOrcamento,DataInicio,DataPrevistaTermino,DataTermino,Id")] EmpreendimentoModel empreendimentoModel)
        {
            if (id != empreendimentoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empreendimentoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpreendimentoModelExists(empreendimentoModel.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.ClientesFornecedores, "Id", "Id", empreendimentoModel.ClienteId);
            return View(empreendimentoModel);
        }

        // GET: Empreendimento/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empreendimentoModel = await _context.Empreendimentos
                .Include(e => e.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empreendimentoModel == null)
            {
                return NotFound();
            }

            return View(empreendimentoModel);
        }

        // POST: Empreendimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            var empreendimentoModel = await _context.Empreendimentos.FindAsync(id);
            _context.Empreendimentos.Remove(empreendimentoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpreendimentoModelExists(Guid? id)
        {
            return _context.Empreendimentos.Any(e => e.Id == id);
        }
    }
}
