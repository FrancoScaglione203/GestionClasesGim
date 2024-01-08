using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionClasesGim.Entities
{
    public class Alumno : Usuario
    {
        [Column("alumno_fechainscripcion", TypeName = "datetime2")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaInscripcion { get; set; }
    }
}
