using System.ComponentModel.DataAnnotations.Schema;

namespace GestionClasesGim.Entities
{
    public class TipoMov
    {
        [Column("tipoMov_id")]
        public int Id { get; set; }
        [Column("tipoMov_descripcion")]
        public string Descripcion { get; set; }
        [Column("tipoMov_activo")]
        public bool Activo { get; set; }
    }
}
