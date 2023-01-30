using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace AppTiendaMascotas.accesoDatos
{
    class Datos
    {
        string cadenaConexion = "DATA SOURCE=localhost:1522/xe;USER ID=proyecto;Password=2802";

        //metodo que crea una intruccion dml;
        public int ejecutarDML(string consulta) 
        {
            int filasAfectadas;
            //paso1: crear conexion:
            OracleConnection miConexion = new OracleConnection(cadenaConexion);
            //paso 2:crear un objeto de tipo oracle command
            OracleCommand miComando = new OracleCommand(consulta, miConexion);
            //paso3: abrir la conexion:
            miConexion.Open();
            /*este comando devuelve un valor entero que indica las filas que se modificaron
             en la operacion*/
            filasAfectadas = miComando.ExecuteNonQuery();
            //paso 5: cierro la conexion:
            miConexion.Close();
            return filasAfectadas;
        }

        public DataSet ejecutarSELECT(string consulta) 
        {
            //paso1: crear un dataset vacio
            DataSet ds = new DataSet();
            //paso2: creo un adaptador
            OracleDataAdapter miAdaptador = new OracleDataAdapter(consulta,cadenaConexion);
            //paso3: a traves del adaptador llenar el dataset
            miAdaptador.Fill(ds, "ResultadoDatos");
            return ds;
        }

    }
}
