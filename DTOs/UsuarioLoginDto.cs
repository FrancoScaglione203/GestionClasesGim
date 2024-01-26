namespace GestionClasesGim.DTOs
{
    public class UsuarioLoginDto
    {
        public int Id {  get; set; }    
        public long Dni { get; set; }
        public int RoleId { get; set; }
        public string Token { get; set; }
    }
}
