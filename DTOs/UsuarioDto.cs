namespace GestionClasesGim.DTOs
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public int RoleId { get; set; }
        public string Clave { get; set; }
        public bool Activo { get; set; }
    }
}
