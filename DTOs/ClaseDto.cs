using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionClasesGim.DTOs
{
    public class ClaseDto
    {
        public string Nombre { get; set; }
        public DateTime FechaHorario { get; set; }
        public int CapacidadMax { get; set; }
        public int Cupos { get; set; }
        public bool Activo { get; set; }
    }
}
