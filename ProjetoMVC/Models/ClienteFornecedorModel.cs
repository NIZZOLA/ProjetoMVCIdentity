using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMVC.Models
{
    [Table("ClienteFornecedor")]
    public class ClienteFornecedorModel : BaseModel
    {
        [ForeignKey("PessoaFisica")]
        public Guid? PessoaId { get; set; }
        public PessoaModel? PessoaFisica { get; set; }

        [ForeignKey("PessoaJuridica")]
        public Guid? PessoaJuridicaId { get; set; }
        public PessoaJuridicaModel? PessoaJuridica { get; set; }

        public bool Cliente { get; set; }
        public bool Fornecedor { get; set; }

        public string? Observacoes { get; set; }

        public ICollection<ContatoModel> Contatos { get; set; }
        public ICollection<EnderecoModel> Enderecos { get; set; }


        public string Nome
        {
            get
            {
                if (this.PessoaFisica != null)
                    return this.PessoaFisica.Nome;
                else if (this.PessoaJuridica != null)
                    return this.PessoaJuridica.NomeFantasia;
                else
                    return "";
            }
        }
    }
}
