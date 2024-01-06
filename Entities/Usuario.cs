using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace GestionClasesGim.Entities
{
    public class Usuario
    {
        [Key]
        [Column("usuario_id")]
        public int Id { get; set; }
        [Required]
        [Column("usuario_dni")]
        public int Dni { get; set; }
        [Required]
        [Column("usuario_clave", TypeName = "VARCHAR(250)")]
        public string Clave { get; set; }
        [Required]
        [Column("usuario_nombre", TypeName = "VARCHAR(50)")]
        public string Nombre { get; set; }

        [Required]
        [Column("usuario_apellido", TypeName = "VARCHAR(50)")]
        public string Apellido { get; set; }
        [Required]
        [Column("role_id")]
        public int RoleId { get; set; }
        public Role? Role { get; set; }
        
        [Required]
        [Column("usuario_activo")]
        public bool Activo { get; set; }
    }
}
