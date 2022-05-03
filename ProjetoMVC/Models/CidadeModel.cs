using ProjetoMVC.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMVC.Models
{
    [Table("Cidades")]
    public class CidadeModel : BaseModel
    {
        [MaxLength(50, ErrorMessage = "")]
        public string NomeCidade { get; set; }

        public EstadoEnum Estado { get; set; }
    }
}
