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
    public class ContatoController : Controller
    {
        private readonly ProjetoMVCContext _context;

        public ContatoController(ProjetoMVCContext context)
        {
            _context = context;
        }

        // GET: Contato
        public async Task<IActionResult> Index()
        {
            var projetoMVCContext = _context.Contatos.Include(c => c.ClienteFornecedor);
            return View(await projetoMVCContext.ToListAsync());
        }

        // GET: Contato/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contatoModel = await _context.Contatos
                .Include(c => c.ClienteFornecedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contatoModel == null)
            {
                return NotFound();
            }

            return View(contatoModel);
        }

        // GET: Contato/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.ClientesFornecedores, "Id", "Id");
            return View();
        }

        // POST: Contato/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,Nome,Funcao,Email,Telefone,Id")] ContatoModel contatoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contatoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.ClientesFornecedores, "Id", "Id", contatoModel.ClienteId);
            return View(contatoModel);
        }

        // GET: Contato/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contatoModel = await _context.Contatos.FindAsync(id);
            if (contatoModel == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.ClientesFornecedores, "Id", "Id", contatoModel.ClienteId);
            return View(contatoModel);
        }

        // POST: Contato/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("ClienteId,Nome,Funcao,Email,Telefone,Id")] ContatoModel contatoModel)
        {
            if (id != contatoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contatoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContatoModelExists(contatoModel.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.ClientesFornecedores, "Id", "Id", contatoModel.ClienteId);
            return View(contatoModel);
        }

        // GET: Contato/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contatoModel = await _context.Contatos
                .Include(c => c.ClienteFornecedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contatoModel == null)
            {
                return NotFound();
            }

            return View(contatoModel);
        }

        // POST: Contato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            var contatoModel = await _context.Contatos.FindAsync(id);
            _context.Contatos.Remove(contatoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContatoModelExists(Guid? id)
        {
            return _context.Contatos.Any(e => e.Id == id);
        }
    }
}
