using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;

namespace GestionClasesGim.Entities
{
    public class Historial
    {
        public Historial(int usuarioId, int claseId, int tipoMovId)
        {
            UsuarioId = usuarioId;
            ClaseId = claseId;
            TipoMovId = tipoMovId;
        }

        public Historial()
        {

        }


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
