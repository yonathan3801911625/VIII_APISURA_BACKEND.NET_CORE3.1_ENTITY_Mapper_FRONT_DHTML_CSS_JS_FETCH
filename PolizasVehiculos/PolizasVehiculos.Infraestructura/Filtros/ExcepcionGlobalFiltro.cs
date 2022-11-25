using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PolizasVehiculos.Core.Excepciones;
using System.Net;

namespace PolizasVehiculos.Infraestructura.Filtros
{
    public class ExcepcionGlobalFiltro : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(ExcepcionNegocio)) 
            {
                var excepsion = (ExcepcionNegocio)context.Exception;
                var validacion = new
                {
                    Status = 400,
                    Title = "Bad Request",
                    Detail = excepsion.Message
                };

                var json = new
                {
                    errors = new[] { validacion }
                };

                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }
        }
    }
}
