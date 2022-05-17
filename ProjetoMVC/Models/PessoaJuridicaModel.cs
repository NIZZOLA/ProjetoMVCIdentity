using ProjetoMVC.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMVC.Models
{
    [Table("PessoaJuridica")]
    public class PessoaJuridicaModel: BaseModel
    {
        [MaxLength(50, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string NomeFantasia { get; set; }
        [MaxLength(50, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string RazaoSocial { get; set; }

        [MaxLength(18, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string Cnpj { get; set; }
        [MaxLength(18, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string InscricaoEstadual { get; set; }
        public bool OptanteDoSimples { get; set; }

    }
}
