using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMVC.Models
{
    [Table("Contas")]
    public class ContaModel : BaseModel
    {
        [ForeignKey("Empreendimento")]
        public Guid? EmpreendimentoId { get; set; }
        public EmpreendimentoModel Empreendimento { get; set; }

        public DateTime Vencimento { get; set; }
        public DateTime? DataDoPagamento { get; set; }
        public DateTime? DataDaCompra { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Valor { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ValorPago { get; set; }

        public string NumeroDoDocumento { get; set; }

        public string Observacoes { get; set; }

        [ForeignKey("TipoDespesaReceita")]
        public Guid? TipoDeDespesaId { get; set; }
        public TipoDeDespesaReceitaModel TipoDeDespesaReceita { get; set; }

        [ForeignKey("TipoDePagamento")]
        public Guid? TipoDePagamentoId { get; set; }
        public TipoDePagamentoModel TipoDePagamento { get; set; }

    }
}
