using ProjetoMVC.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMVC.Models
{
    [Table("PessoaFisica")]
    public class PessoaModel :BaseModel
    {
        [MaxLength(50, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string Nome { get; set; }
        [MaxLength(18, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string Cpf { get; set; }

        public DateTime? DataDeNascimento { get; set; }

      
    }
}
