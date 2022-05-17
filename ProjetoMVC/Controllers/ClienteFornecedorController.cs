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
using ProjetoMVC.Models.Contracts.Request;

namespace ProjetoMVC.Controllers
{
    public class ClienteFornecedorController : Controller
    {
        private readonly ProjetoMVCContext _context;

        public ClienteFornecedorController(ProjetoMVCContext context)
        {
            _context = context;
        }

        // GET: ClienteFornecedor
        public async Task<IActionResult> Index()
        {
            var projetoMVCContext = _context.ClientesFornecedores
                .Include(c => c.PessoaFisica)
                .Include(c => c.PessoaJuridica);
            return View(await projetoMVCContext.ToListAsync());
        }

        // GET: ClienteFornecedor/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteFornecedorModel = await _context.ClientesFornecedores
                .Include(c => c.PessoaFisica)
                .Include(c => c.PessoaJuridica)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienteFornecedorModel == null)
            {
                return NotFound();
            }

            return View(clienteFornecedorModel);
        }

        // GET: ClienteFornecedor/Create
        public IActionResult Create()
        {
            var model = new ClienteFornecedorRequestModel();
           
            return View(model);
        }

        // POST: ClienteFornecedor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteFornecedorRequestModel clienteFornecedorPost)
        {
                var model = new ClienteFornecedorModel();
                model.Fornecedor = clienteFornecedorPost.Fornecedor;
                model.Cliente = clienteFornecedorPost.Cliente;
                model.Observacoes = clienteFornecedorPost.Observacoes;

                if (clienteFornecedorPost.TipoDeCliente == "F")
                {
                    var clienteFisica = new PessoaModel();
                    clienteFisica.Id = Guid.NewGuid();
                    clienteFisica.Nome = clienteFornecedorPost.Nome;
                    clienteFisica.DataDeNascimento = clienteFornecedorPost.DataDeNascimento;
                    clienteFisica.Cpf = clienteFornecedorPost.Cpf;
                    clienteFisica.DataCriacao = DateTime.Now;
                    //clienteFisica.UsuarioIdCriacao = 
                    _context.Add(clienteFisica);
                    model.PessoaId = clienteFisica.Id;
                    
                }
                else
                {
                    var clienteJuridica = new PessoaJuridicaModel();
                    clienteJuridica.NomeFantasia = clienteFornecedorPost.NomeFantasia;
                    clienteJuridica.RazaoSocial = clienteFornecedorPost.RazaoSocial;
                    clienteJuridica.Cnpj = clienteFornecedorPost.Cnpj;
                    clienteJuridica.InscricaoEstadual = clienteFornecedorPost.InscricaoEstadual;
                    clienteJuridica.OptanteDoSimples = clienteFornecedorPost.OptanteDoSimples;
                    clienteJuridica.DataCriacao = DateTime.Now;
                    _context.Add(clienteJuridica);
                    model.PessoaJuridicaId = clienteJuridica.Id;
                }

                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            return View(clienteFornecedorPost);
        }

        // GET: ClienteFornecedor/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteFornecedorModel = await _context.ClientesFornecedores.FindAsync(id);
            if (clienteFornecedorModel == null)
            {
                return NotFound();
            }
            ViewData["PessoaId"] = new SelectList(_context.Set<PessoaModel>(), "Id", "Id", clienteFornecedorModel.PessoaId);
            ViewData["PessoaJuridicaId"] = new SelectList(_context.Set<PessoaJuridicaModel>(), "Id", "Id", clienteFornecedorModel.PessoaJuridicaId);
            return View(clienteFornecedorModel);
        }

        // POST: ClienteFornecedor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("PessoaId,PessoaJuridicaId,Cliente,Fornecedor,Id")] ClienteFornecedorModel clienteFornecedorModel)
        {
            if (id != clienteFornecedorModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteFornecedorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteFornecedorModelExists(clienteFornecedorModel.Id))
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
            ViewData["PessoaId"] = new SelectList(_context.Set<PessoaModel>(), "Id", "Id", clienteFornecedorModel.PessoaId);
            ViewData["PessoaJuridicaId"] = new SelectList(_context.Set<PessoaJuridicaModel>(), "Id", "Id", clienteFornecedorModel.PessoaJuridicaId);
            return View(clienteFornecedorModel);
        }

        // GET: ClienteFornecedor/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteFornecedorModel = await _context.ClientesFornecedores
                .Include(c => c.PessoaFisica)
                .Include(c => c.PessoaJuridica)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienteFornecedorModel == null)
            {
                return NotFound();
            }

            return View(clienteFornecedorModel);
        }

        // POST: ClienteFornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            var clienteFornecedorModel = await _context.ClientesFornecedores.FindAsync(id);
            _context.ClientesFornecedores.Remove(clienteFornecedorModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteFornecedorModelExists(Guid? id)
        {
            return _context.ClientesFornecedores.Any(e => e.Id == id);
        }
    }
}
