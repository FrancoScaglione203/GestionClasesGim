namespace GestionClasesGim.Entities
{
    public class Login
    {
        public int Id { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public string Activo { get; set; }
    }
}
