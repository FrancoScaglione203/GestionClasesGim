using System.ComponentModel.DataAnnotations.Schema;

namespace GestionClasesGim.Entities
{
    public class Historial
    {
        [Column("historial_id")]
        public int Id { get; set; }
        [Column("usuario_id")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        [Column("clase_id")]
        public int ClaseId { get; set; }
        public Clase Clase { get; set; }
        [Column("tipoMov_id")]
        public int TipoMovId { get; set; }
        public TipoMov TipoMov { get; set; }
    }
}
