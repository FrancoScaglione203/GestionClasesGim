using Microsoft.AspNetCore.Mvc;

namespace GestionClasesGim.Infraestructure
{
    public class ResponseFactory
    {
        /// <summary>
        /// Crea una respuesta HTTP de éxito con el código de estado especificado y datos proporcionados por parametro.
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="data"></param>
        /// <returns>Una instancia de IActionResult que representa una respuesta de éxito.</returns>
        public static IActionResult CreateSuccessResponse(int statusCode, object? data)
        {
            var response = new ApiSuccessResponse()
            {
                Status = statusCode,
                Data = data
            };

            return new ObjectResult(response)
            {
                StatusCode = statusCode,
            };
        }

        /// <summary>
        /// Crea una respuesta HTTP de error con el código de estado especificado y mensajes de error
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="errors"></param>
        /// <returns>Una instancia de IActionResult que representa una respuesta de error</returns>
        public static IActionResult CreateErrorResponse(int statusCode, params string[] errors)
        {
            var response = new ApiErrorResponse()
            {
                Status = statusCode,
                Error = new List<ApiErrorResponse.ResponseError>()
            };

            foreach (var error in errors)
            {
                response.Error.Add(new ApiErrorResponse.ResponseError() { Error = error });
            }

            return new ObjectResult(response)
            {
                StatusCode = statusCode,
            };
        }
    }
}
