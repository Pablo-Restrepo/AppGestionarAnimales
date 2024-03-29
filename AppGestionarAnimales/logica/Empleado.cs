﻿using AppTiendaMascotas.accesoDatos;
using System.Data;

namespace AppTiendaMascotas.logica
{
    internal class Empleado
    {
        private Datos dt = new Datos();

        public int ingresarEmpleado(int codEmpleado, string nombreEmpleado, string apellidoEmpleado, string cargoEmpleado, long salarioEmpleado)
        {
            int resultado;
            //paso 1: construyo la sentencia sql para insertar
            string consulta = "INSERT INTO EMPLEADO (CODEMPLEADO,NOMBREEMPLEADO,APELLIDOEMPLEADO,CARGOEMPLEADO,SALARIOEMPLEADO) VALUES (" +
                codEmpleado + ",'" + nombreEmpleado + "','" + apellidoEmpleado + "','" + cargoEmpleado + "'," + salarioEmpleado + ")";
            //paso 2: enviar la consulta a la capa de accesoDatos para ejecutarla
            resultado = dt.ejecutarDML(consulta);
            return resultado;
        }

        public int eliminarEmpleado(int codEmpleado)
        {
            int resultado;
            //paso 1: construyo la sentencia sql para insertar
            string consulta = "DELETE FROM EMPLEADO WHERE CODEMPLEADO = " + codEmpleado;
            resultado = dt.ejecutarDML(consulta);
            return resultado;
        }

        public DataSet consultarEmpleado()
        {
            DataSet rDT = new DataSet();
            string consulta;
            consulta = "SELECT CODEMPLEADO CODIGO,NOMBREEMPLEADO NOMBRE,APELLIDOEMPLEADO APELLIDO,CARGOEMPLEADO CARGO,FECHAINGRESO INGRESO,SALARIOEMPLEADO SALARIO FROM EMPLEADO";
            rDT = dt.ejecutarSELECT(consulta);
            return rDT;
        }

        public string consultarSalarioPromedioEmpleado()
        {
            DataSet rDT = new DataSet();
            string consulta;
            consulta = "SELECT AVG(SALARIOEMPLEADO) FROM EMPLEADO";
            rDT = dt.ejecutarSELECT(consulta);
            return rDT.Tables[0].Rows[0][0].ToString();
        }

        public DataTable consultarEmpleadoIDs()
        {
            DataSet mids = new DataSet();
            string consulta;
            consulta = "SELECT CODEMPLEADO, NOMBREEMPLEADO FROM EMPLEADO";
            mids = dt.ejecutarSELECT(consulta);
            DataTable dta = mids.Tables[0];
            return dta;
        }
    }
}