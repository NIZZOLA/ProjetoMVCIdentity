using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMVC.Models
{
    [Table("PessoaJuridica")]
    public class PessoaJuridicaModel: BaseModel
    {
        [MaxLength(50, ErrorMessage = "")]
        public string NomeFantasia { get; set; }
        [MaxLength(50, ErrorMessage = "")]
        public string RazaoSocial { get; set; }

        [MaxLength(18, ErrorMessage = "")]
        public string Cnpj { get; set; }
        [MaxLength(18, ErrorMessage = "")]
        public string InscricaoEstadual { get; set; }
        public bool OptanteDoSimples { get; set; }

        public string Observacoes { get; set; }
    }
}
