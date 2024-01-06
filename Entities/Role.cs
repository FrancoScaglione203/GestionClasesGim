using System.ComponentModel.DataAnnotations.Schema;

namespace GestionClasesGim.Entities
{
    public class Role
    {
        [Column("role_id")]
        public int Id { get; set; }
        [Column("role_name")]
        public string Name { get; set; }
        [Column("role_description")]
        public string Description { get; set; }
        [Column("role_activo")]
        public bool Activo { get; set; }
    }
}
