using ProjetoMVC.Helpers;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMVC.Models.Contracts.Request
{
    public class ClienteFornecedorRequestModel
    {
        [Key]
        public Guid? Id { get; set; }

        public bool Cliente { get; set; }
        public bool Fornecedor { get; set; }

        public string TipoDeCliente { get; set; }

        [MaxLength(50, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string Nome { get; set; }
        [MaxLength(18, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string Cpf { get; set; }

        public DateTime? DataDeNascimento { get; set; }

        [MaxLength(50, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string NomeFantasia { get; set; }
        [MaxLength(50, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string RazaoSocial { get; set; }

        [MaxLength(18, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string Cnpj { get; set; }
        [MaxLength(18, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string InscricaoEstadual { get; set; }
        public bool OptanteDoSimples { get; set; }

        public string Observacoes { get; set; }

    }
}
