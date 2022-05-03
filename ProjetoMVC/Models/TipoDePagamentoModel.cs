using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMVC.Models
{
    [Table("TipoDePagamento")]
    public class TipoDePagamentoModel : BaseModel
    {
        [MaxLength(50, ErrorMessage = "")]
        public string Nome { get; set; }
    }
}
