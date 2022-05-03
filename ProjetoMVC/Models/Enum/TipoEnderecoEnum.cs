using System.ComponentModel;

namespace ProjetoMVC.Models.Enum
{
    public enum TipoEnderecoEnum
    {
        [Description("Principal")]
        PRINCIPAL,
        [Description("Cobrança")]
        COBRANÇA,
        [Description("Entrega")]
        ENTREGA,
        [Description("Outros")]
        OUTROS
        
    }
}
