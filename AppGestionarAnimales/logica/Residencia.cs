﻿using AppTiendaMascotas.accesoDatos;
using System.Data;

namespace AppTiendaMascotas.logica
{
    internal class Residencia
    {
        private Datos dt = new Datos();

        public int ingresarResidencia(int idResidencia, int numResidentes, string tipoResidencia)
        {
            int resultado;
            //paso 1: construyo la sentencia sql para insertar
            string consulta = "INSERT INTO RESIDENCIA (IDRESIDENCIA,NUMRESIDENTESMAX,TIPORESIDENCIA) VALUES (" +
                idResidencia + "," + numResidentes + ",'" + tipoResidencia + "')";
            //paso 2: enviar la consulta a la capa de accesoDatos para ejecutarla
            resultado = dt.ejecutarDML(consulta);
            return resultado;
        }

        public int eliminarResidencia(int numResidencia)
        {
            int resultado;
            //paso 1: construyo la sentencia sql para insertar
            string consulta = "DELETE FROM RESIDENCIA WHERE IDRESIDENCIA = " + numResidencia;
            resultado = dt.ejecutarDML(consulta);
            return resultado;
        }

        public DataSet consultarResidencia()
        {
            DataSet rDT = new DataSet();
            string consulta;
            consulta = "SELECT IDRESIDENCIA ID,NUMRESIDENTESMAX MAXIMO_DE_RESIDENTES,TIPORESIDENCIA TIPO_DE_RESIDENCIA FROM RESIDENCIA";
            rDT = dt.ejecutarSELECT(consulta);
            return rDT;
        }

        public string consultarCantidadResidencias()
        {
            DataSet rDT = new DataSet();
            string consulta;
            consulta = "SELECT COUNT(IDRESIDENCIA) FROM RESIDENCIA";
            rDT = dt.ejecutarSELECT(consulta);
            return rDT.Tables[0].Rows[0][0].ToString();
        }

        public DataTable consultarResidenciaIDs()
        {
            DataSet mids = new DataSet();
            string consulta;
            consulta = "SELECT IDRESIDENCIA FROM RESIDENCIA";
            mids = dt.ejecutarSELECT(consulta);
            DataTable dta = mids.Tables[0];
            return dta;
        }
    }
}