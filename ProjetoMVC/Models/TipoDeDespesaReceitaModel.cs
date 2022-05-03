using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMVC.Models
{
    [Table("TipoDeDespesaReceita")]
    public class TipoDeDespesaReceitaModel : BaseModel
    {
        [MaxLength(50, ErrorMessage = "")]
        public string Nome { get; set; }
        public bool Receita { get; set; }
        public bool Despesa { get; set; }
    }
}
