using System.ComponentModel.DataAnnotations;

namespace ProjetoMVC.Models
{
    public class BaseModel
    {
        [Key]
        public Guid? Id { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? DataCriacao { get; set; }
        [ScaffoldColumn(false)]
        public Guid? UsuarioIdCriacao { get; set; }
        [ScaffoldColumn(false)]
        public DateTime? DataAlteracao { get; set; }
        [ScaffoldColumn(false)]
        public Guid? UsuarioIdAlteracao { get; set; }
        [ScaffoldColumn(false)]
        public DateTime? DataExclusao { get; set; }
        [ScaffoldColumn(false)]
        public Guid? UsuarioIdExclusao { get; set; }
    }
}
