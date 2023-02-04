using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;

namespace AppTiendaMascotas.accesoDatos
{
    class Datos
    {
		public static string cadenaConexion = "";

		//metodo que crea una intruccion dml;
		public int ejecutarDML(string consulta) 
        {
            int filasAfectadas = 0;
            OracleConnection miConexion = new OracleConnection(cadenaConexion);
            OracleCommand miComando = new OracleCommand(consulta, miConexion);
            try
            {
                miConexion.Open();
                filasAfectadas = miComando.ExecuteNonQuery();
                miConexion.Close();
                return filasAfectadas;
            }
            catch (Exception ex)
            {
                miConexion.Close();
                MessageBox.Show("Ocurrió un error con la base de datos: " + ex.Message);
            }
            return filasAfectadas;
        }

		public void setCadenaConexion(string userId, string hostName, string portNumber, string password)
		{
			cadenaConexion = "Data Source = " + hostName + ":" + portNumber + "/ xe; User Id = " + userId + "; Password = " + password;
		}

		public string getCadenaConexion()
		{
			return cadenaConexion;
		}

		public DataSet ejecutarSELECT(string consulta) 
        {
            //paso1: crear un dataset vacio
            DataSet ds = new DataSet();
            //paso2: creo un adaptador
            OracleDataAdapter miAdaptador = new OracleDataAdapter(consulta, cadenaConexion);
            //paso3: a traves del adaptador llenar el dataset
            miAdaptador.Fill(ds, "ResultadoDatos");
            return ds;
        }

        public int ConsultarIngXEmpleado(int codEmpleado, DateTime fechaInicio, DateTime fechaFin)
        {
            int total = 0;
            OracleConnection connection = new OracleConnection(cadenaConexion);
            try
            {
                connection.Open();

                // Crear un objeto OracleCommand y establecer sus propiedades
                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = "paq_gerente.total_ingresos_empleado";
                command.CommandType = CommandType.StoredProcedure;

                // Agregar los parámetros de entrada al objeto OracleCommand
                command.Parameters.Add("p_codEmpleado", OracleDbType.Int32).Value = codEmpleado;
                command.Parameters.Add("p_fechaInicio", OracleDbType.Date).Value = fechaInicio;
                command.Parameters.Add("p_fechaFin", OracleDbType.Date).Value = fechaFin;

                command.Parameters.Add("p_total", OracleDbType.Int32).Direction = ParameterDirection.Output;

                command.ExecuteScalar();

                total = Convert.ToInt32(command.Parameters["p_total"].Value);
                return total;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error con la base de datos: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return total;
        }
        public DataSet ConsultarListarEmpleados(DateTime fechaInicio, DateTime fechaFin)
        {
            DataSet ds = new DataSet();
            OracleConnection connection = new OracleConnection(getCadenaConexion());
            try
            {
                connection.Open();
                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = "paq_gerente.listar_empleados";
                command.CommandType = CommandType.StoredProcedure;
                // Agregar los parámetros de entrada al objeto OracleCommand
                command.Parameters.Add("p_fechaInicio", OracleDbType.Date).Value = fechaInicio;
                command.Parameters.Add("p_fechaFin", OracleDbType.Date).Value = fechaFin;
                command.Parameters.Add("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
                command.CommandType = CommandType.StoredProcedure;
                OracleDataAdapter myAdapter = new OracleDataAdapter(command);
                myAdapter.Fill(ds, "ResultadoDatos");
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error con la base de datos: " + ex.Message);
            }
            finally
            {
                connection.Close();                
            }
            return ds;
        }
    }
}
