using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FN.Store.UI.Models
{
    [Table(nameof(Usuario))]
    public class Usuario : Entity
    {
        [Column(TypeName = "varchar(100)")]
        [Required]
        public string Nome { get; set; }

        [Column(TypeName = "varchar(80)")]
        [Required]
        public string Email { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required]
        public string Senha { get; set; }
    }
}
