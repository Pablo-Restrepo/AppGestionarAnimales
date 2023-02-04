using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTiendaMascotas.accesoDatos;

namespace AppTiendaMascotas.logica
{
    class Gerente
    {
        Datos dt = new Datos();

        public int ConsultarIngXEmpleado(int codEmpleado, DateTime fechaInicio, DateTime fechaFin)
        {
            return dt.ConsultarIngXEmpleado(codEmpleado, fechaInicio, fechaFin);
        }
        public DataSet ConsultarListarEmpleados(DateTime fechaInicio, DateTime fechaFin)
        {
            return dt.ConsultarListarEmpleados(fechaInicio, fechaFin);
        }
    }
}
