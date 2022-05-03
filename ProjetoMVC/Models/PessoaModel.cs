using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMVC.Models
{
    [Table("PessoaFisica")]
    public class PessoaModel :BaseModel
    {
        [MaxLength(50, ErrorMessage = "")]
        public string Nome { get; set; }
        [MaxLength(18, ErrorMessage = "")]
        public string Cpf { get; set; }

        public DateTime? DataDeNascimento { get; set; }

      
    }
}
