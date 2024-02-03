namespace GestionClasesGim.Infraestructure
{
    public class ApiSuccessResponse
    {
        /// <summary>
        /// Representa una respuesta HTTP exitosa que contiene un código de estado y datos.
        /// </summary>
        public int Status { get; set; }
        public object? Data { get; set; }
    }
}
