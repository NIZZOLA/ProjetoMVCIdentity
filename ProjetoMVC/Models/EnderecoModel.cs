using ProjetoMVC.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMVC.Models
{
    [Table("Endereco")]
    public class EnderecoModel : BaseModel
    {
        [ForeignKey("ClienteFornecedor")]
        public Guid? ClienteFornecedorId { get; set; }
        public ClienteFornecedorModel ClienteFornecedor { get; set; }

        [ForeignKey("Empreendimento")]
        public Guid? EmpreendimentoId { get; set; }
        public EmpreendimentoModel? Empreendimento { get; set; }

        [MaxLength(50, ErrorMessage = "")]
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        [MaxLength(50, ErrorMessage = "")]
        public string Bairro { get; set; }

        [ForeignKey("Cidade")]
        public Guid? CidadeId { get; set; }
        public CidadeModel Cidade { get; set; }

        [MaxLength(10, ErrorMessage = "")]
        public string Cep { get; set; }
        public TipoEnderecoEnum Tipo { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
