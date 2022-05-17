#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoMVC.Data;
using ProjetoMVC.Models;

namespace ConstrutoraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteFornecedorController : ControllerBase
    {
        private readonly ProjetoMVCContext _context;

        public ClienteFornecedorController(ProjetoMVCContext context)
        {
            _context = context;
        }

        // GET: api/ClienteFornecedor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteFornecedorModel>>> GetClientesFornecedores()
        {
            return await _context.ClientesFornecedores.ToListAsync();
        }

        // GET: api/ClienteFornecedor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteFornecedorModel>> GetClienteFornecedorModel(Guid? id)
        {
            var clienteFornecedorModel = await _context.ClientesFornecedores.FindAsync(id);

            if (clienteFornecedorModel == null)
            {
                return NotFound();
            }

            return clienteFornecedorModel;
        }

        // PUT: api/ClienteFornecedor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClienteFornecedorModel(Guid? id, ClienteFornecedorModel clienteFornecedorModel)
        {
            if (id != clienteFornecedorModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(clienteFornecedorModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteFornecedorModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ClienteFornecedor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClienteFornecedorModel>> PostClienteFornecedorModel(ClienteFornecedorModel clienteFornecedorModel)
        {
            _context.ClientesFornecedores.Add(clienteFornecedorModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClienteFornecedorModel", new { id = clienteFornecedorModel.Id }, clienteFornecedorModel);
        }

        // DELETE: api/ClienteFornecedor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClienteFornecedorModel(Guid? id)
        {
            var clienteFornecedorModel = await _context.ClientesFornecedores.FindAsync(id);
            if (clienteFornecedorModel == null)
            {
                return NotFound();
            }

            _context.ClientesFornecedores.Remove(clienteFornecedorModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteFornecedorModelExists(Guid? id)
        {
            return _context.ClientesFornecedores.Any(e => e.Id == id);
        }
    }
}
