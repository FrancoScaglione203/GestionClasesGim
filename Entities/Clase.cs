using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionClasesGim.Entities
{
    public class Clase
    {
        [Column("clase_id")]
        public int Id { get; set; }
        [Required]
        [Column("clase_nombre", TypeName = "VARCHAR(50)")]
        public string Nombre { get; set; }
        [Column("clase_fechahorario")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime FechaHorario { get; set; }
        [Required]
        [Column("clase_capacidadMax")]
        public int CapacidadMax { get; set; }
        [Required]
        [Column("clase_cupos")]
        public int Cupos { get; set; }
        [Required]
        [Column("clase_activo")]
        public bool Activo { get; set; }
    }
}
