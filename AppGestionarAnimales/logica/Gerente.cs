using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTiendaMascotas.accesoDatos;

namespace AppTiendaMascotas.logica
{
    class Gerente
    {
        Datos dt = new Datos();

        public int ConsultarIngXEmpleado(long codEmpleado, DateTime fechaInicio, DateTime fechaFin)
        {
            return dt.ConsultarIngXEmpleado(codEmpleado, fechaInicio, fechaFin);
        }
    }
}
