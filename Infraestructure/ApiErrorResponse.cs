namespace GestionClasesGim.Infraestructure
{
    public class ApiErrorResponse
    {
        /// <summary>
        /// Representa una respuesta HTTP de error que contiene un código de estado y una lista de errores.
        /// </summary>
        public int Status { get; set; }
        public List<ResponseError> Error { get; set; }

        /// <summary>
        /// Representa un error individual dentro de la respuesta de error.
        /// </summary>
        public class ResponseError
        {
            public string? Error { get; set; }
        }
    }
}
