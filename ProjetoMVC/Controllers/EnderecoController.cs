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
    public class EnderecoController : Controller
    {
        private readonly ProjetoMVCContext _context;

        public EnderecoController(ProjetoMVCContext context)
        {
            _context = context;
        }

        // GET: Endereco
        public async Task<IActionResult> Index()
        {
            var projetoMVCContext = _context.Enderecos.Include(e => e.Cidade).Include(e => e.ClienteFornecedor).Include(e => e.Empreendimento);
            return View(await projetoMVCContext.ToListAsync());
        }

        // GET: Endereco/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enderecoModel = await _context.Enderecos
                .Include(e => e.Cidade)
                .Include(e => e.ClienteFornecedor)
                .Include(e => e.Empreendimento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enderecoModel == null)
            {
                return NotFound();
            }

            return View(enderecoModel);
        }

        // GET: Endereco/Create
        public IActionResult Create()
        {
            ViewData["CidadeId"] = new SelectList(_context.Cidades, "Id", "Id");
            ViewData["ClienteFornecedorId"] = new SelectList(_context.ClientesFornecedores, "Id", "Id");
            ViewData["EmpreendimentoId"] = new SelectList(_context.Empreendimentos, "Id", "Id");
            return View();
        }

        // POST: Endereco/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteFornecedorId,EmpreendimentoId,Logradouro,Numero,Bairro,CidadeId,Cep,Tipo,Latitude,Longitude,Id")] EnderecoModel enderecoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enderecoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CidadeId"] = new SelectList(_context.Cidades, "Id", "Id", enderecoModel.CidadeId);
            ViewData["ClienteFornecedorId"] = new SelectList(_context.ClientesFornecedores, "Id", "Id", enderecoModel.ClienteFornecedorId);
            ViewData["EmpreendimentoId"] = new SelectList(_context.Empreendimentos, "Id", "Id", enderecoModel.EmpreendimentoId);
            return View(enderecoModel);
        }

        // GET: Endereco/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enderecoModel = await _context.Enderecos.FindAsync(id);
            if (enderecoModel == null)
            {
                return NotFound();
            }
            ViewData["CidadeId"] = new SelectList(_context.Cidades, "Id", "Id", enderecoModel.CidadeId);
            ViewData["ClienteFornecedorId"] = new SelectList(_context.ClientesFornecedores, "Id", "Id", enderecoModel.ClienteFornecedorId);
            ViewData["EmpreendimentoId"] = new SelectList(_context.Empreendimentos, "Id", "Id", enderecoModel.EmpreendimentoId);
            return View(enderecoModel);
        }

        // POST: Endereco/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("ClienteFornecedorId,EmpreendimentoId,Logradouro,Numero,Bairro,CidadeId,Cep,Tipo,Latitude,Longitude,Id")] EnderecoModel enderecoModel)
        {
            if (id != enderecoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enderecoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnderecoModelExists(enderecoModel.Id))
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
            ViewData["CidadeId"] = new SelectList(_context.Cidades, "Id", "Id", enderecoModel.CidadeId);
            ViewData["ClienteFornecedorId"] = new SelectList(_context.ClientesFornecedores, "Id", "Id", enderecoModel.ClienteFornecedorId);
            ViewData["EmpreendimentoId"] = new SelectList(_context.Empreendimentos, "Id", "Id", enderecoModel.EmpreendimentoId);
            return View(enderecoModel);
        }

        // GET: Endereco/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enderecoModel = await _context.Enderecos
                .Include(e => e.Cidade)
                .Include(e => e.ClienteFornecedor)
                .Include(e => e.Empreendimento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enderecoModel == null)
            {
                return NotFound();
            }

            return View(enderecoModel);
        }

        // POST: Endereco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            var enderecoModel = await _context.Enderecos.FindAsync(id);
            _context.Enderecos.Remove(enderecoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnderecoModelExists(Guid? id)
        {
            return _context.Enderecos.Any(e => e.Id == id);
        }
    }
}
