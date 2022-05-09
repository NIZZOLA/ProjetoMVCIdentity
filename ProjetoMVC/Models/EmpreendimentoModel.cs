using ProjetoMVC.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMVC.Models
{
    [Table("Empreendimento")]
    public class EmpreendimentoModel : BaseModel
    {
        [MaxLength(50, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string Nome  { get; set; }

        [ForeignKey("Cliente")]
        public Guid? ClienteId { get; set; }
        public ClienteFornecedorModel Cliente { get; set; }
        
        public DateTime DataOrcamento { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataPrevistaTermino { get; set; }
        public DateTime? DataTermino { get; set; }

        public ICollection<EnderecoModel> Enderecos { get; set; }
    }
}
