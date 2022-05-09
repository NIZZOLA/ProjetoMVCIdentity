using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoMVC.Areas.Identity.Data;
using ProjetoMVC.Models;
using ProjetoMVC.Models.Contracts.Request;

namespace ProjetoMVC.Data;

public class ProjetoMVCContext : IdentityDbContext<UsuarioModel>
{
    public ProjetoMVCContext(DbContextOptions<ProjetoMVCContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<ClienteFornecedorModel> ClientesFornecedores { get; set; }
    public DbSet<EnderecoModel> Enderecos { get; set; }
    public DbSet<CidadeModel> Cidades { get; set; }
    public DbSet<EmpreendimentoModel> Empreendimentos { get; set; }
    public DbSet<ContaModel> Contas { get; set; }
    public DbSet<TipoDePagamentoModel> TiposDePagamento { get; set; }
    public DbSet<TipoDeDespesaReceitaModel> TiposDeDespesas { get; set; }
    public DbSet<ContatoModel> Contatos { get; set; }
    public DbSet<ProjetoMVC.Models.PessoaModel> PessoaModel { get; set; }
    public DbSet<ProjetoMVC.Models.PessoaJuridicaModel> PessoaJuridicaModel { get; set; }
    public DbSet<ProjetoMVC.Models.Contracts.Request.ClienteFornecedorRequestModel> ClienteFornecedorRequestModel { get; set; }
   
}
