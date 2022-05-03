﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMVC.Models
{
    [Table("ClienteFornecedor")]
    public class ClienteFornecedorModel : BaseModel
    {
        [ForeignKey("PessoaFisica")]
        public Guid? PessoaId { get; set; }
        public PessoaModel? PessoaFisica { get; set; }
        [ForeignKey("PessoaJuridica")]
        public Guid? PessoaJuridicaId { get; set; }
        public PessoaJuridicaModel? PessoaJuridica { get; set; }

        public bool Cliente { get; set; }
        public bool Fornecedor { get; set; }

        public ICollection<ContatoModel> Contatos { get; set; }
        public ICollection<EnderecoModel> Enderecos { get; set; }
    }
}
