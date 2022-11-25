using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolizasVehiculos.Api.ApiRespuesta
{
    public class ApiRespuesta<T>
    {
        public ApiRespuesta(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}
