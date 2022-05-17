using ProjetoMVC.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMVC.Models
{
    [Table("Contatos")]
    public class ContatoModel : BaseModel
    {
        [ForeignKey("ClienteFornecedor")]
        public Guid ClienteId { get; set; }    
        public ClienteFornecedorModel ClienteFornecedor { get; set; }

        [MaxLength(50, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string Nome { get; set; }
        [MaxLength(20, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string Funcao { get; set; }
        [MaxLength(80, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string Email { get; set; }
        [MaxLength(15, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string Telefone { get; set; }


    }
}
