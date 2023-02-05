using AppTiendaMascotas.accesoDatos;
using System;
using System.Data;

namespace AppTiendaMascotas.logica
{
    internal class Gerente
    {
        private Datos dt = new Datos();

        public int ConsultarIngXEmpleado(int codEmpleado, DateTime fechaInicio, DateTime fechaFin)
        {
            return dt.ConsultarIngXEmpleado(codEmpleado, fechaInicio, fechaFin);
        }

        public DataSet ConsultarResidenciasXAlojamiento(string tipoResidencia)
        {
            return dt.ConsultarResidenciasXAlojamiento(tipoResidencia);
        }

        public DataSet ConsultarListarEmpleados(DateTime fechaInicio, DateTime fechaFin)
        {
            return dt.ConsultarListarEmpleados(fechaInicio, fechaFin);
        }
    }
}