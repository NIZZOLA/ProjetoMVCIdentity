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
using ProjetoMVC.Models.Enum;

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
        public async Task<IActionResult> Index(Guid? id)
        {
            if (id.HasValue)
            {
                ViewBag.ClienteId = id.Value;

                var cliente = _context.ClientesFornecedores.Where(x => x.Id == id.Value)
                            .Include(x => x.PessoaJuridica)
                            .Include(x => x.PessoaFisica)
                            .FirstOrDefault();
                ViewBag.ClienteNome = cliente.PessoaFisica != null ? cliente.PessoaFisica.Nome : cliente.PessoaJuridica.NomeFantasia;

                var projetoMVCContext = _context.Enderecos.Where(a => a.ClienteFornecedorId == id.Value).Include(e => e.Cidade).Include(e => e.ClienteFornecedor).Include(e => e.Empreendimento);
                return View(await projetoMVCContext.ToListAsync());
            }
            else
            {
                var projetoMVCContext = _context.Enderecos
                                    .Include(e => e.Cidade)
                                    .Include(e => e.ClienteFornecedor)
                                    .Include(e => e.ClienteFornecedor.PessoaJuridica)
                                    .Include(e => e.ClienteFornecedor.PessoaFisica)
                                    .Include(e => e.Empreendimento);
                return View(await projetoMVCContext.ToListAsync());
            }
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

        public void CreateViewBags(EnderecoModel ende)
        {
            var clientes = _context.ClientesFornecedores
                .Include(c => c.PessoaFisica)
                .Include(c => c.PessoaJuridica)
                .ToList()
                .OrderBy(c => c.Nome);

            var tiposDeEndereco = from TipoEnderecoEnum e in Enum.GetValues(typeof(TipoEnderecoEnum))
                                  select new { ID = (int)e, Name = e.ToString() };

            if (ende == null)
            {
                ViewData["ClienteFornecedorId"] = new SelectList(clientes, "Id", "Nome");
                ViewData["EmpreendimentoId"] = new SelectList(_context.Empreendimentos.OrderBy(a => a.Nome), "Id", "Nome");
                ViewData["CidadeId"] = new SelectList(_context.Cidades, "Id", "NomeCidade");
                ViewData["Tipo"] = new SelectList(tiposDeEndereco.OrderBy(a => a.Name), "ID", "Name", (int)TipoEnderecoEnum.PRINCIPAL);
            }
            else
            {
                ViewData["ClienteFornecedorId"] = new SelectList(clientes, "Id", "Nome", ende.ClienteFornecedorId);
                
                ViewData["CidadeId"] = new SelectList(_context.Cidades, "Id", "NomeCidade", ende.CidadeId);
                
                if (ende.EmpreendimentoId.HasValue)
                    ViewData["EmpreendimentoId"] = new SelectList(_context.Empreendimentos.OrderBy(a => a.Nome), "Id", "Nome", ende.EmpreendimentoId.Value);
                else
                    ViewData["EmpreendimentoId"] = new SelectList(_context.Empreendimentos.OrderBy(a => a.Nome), "Id", "Nome");

                ViewData["Tipo"] = new SelectList(tiposDeEndereco.OrderBy(a => a.Name), "ID", "Name", (int)TipoEnderecoEnum.PRINCIPAL);
            }
        }

        // GET: Endereco/Create
        public IActionResult Create()
        {
            CreateViewBags(null);
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
            CreateViewBags(enderecoModel);
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
