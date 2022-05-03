using System.ComponentModel.DataAnnotations;

namespace ProjetoMVC.Models
{
    public class BaseModel
    {
        [Key]
        public Guid? Id { get; set; }

        public DateTime? DataCriacao { get; set; }
        public Guid? UsuarioIdCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public Guid? UsuarioIdAlteracao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public Guid? UsuarioIdExclusao { get; set; }
    }
}
