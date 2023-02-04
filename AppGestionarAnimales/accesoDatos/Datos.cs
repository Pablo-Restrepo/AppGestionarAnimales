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
            OracleConnection connection = new OracleConnection(getCadenaConexion());
            try
            {
                connection.Open();
<<<<<<< HEAD
                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = "paq_gerente.total_ingresos_empleado";
=======

                OracleCommand command = new OracleCommand("paq_gerente.total_ingresos_empleado",connection);
>>>>>>> 73c16b7c5df4dc65f154f6f3c94191f2cd8cb2e3
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("p_codEmpleado", OracleDbType.Decimal, ParameterDirection.Input).Value = codEmpleado;
                command.Parameters.Add("p_fechaInicio", OracleDbType.Date, ParameterDirection.Input).Value = fechaInicio;
                command.Parameters.Add("p_fechaFin", OracleDbType.Date, ParameterDirection.Input).Value = fechaFin;

<<<<<<< HEAD
                command.Parameters.Add("v_total", OracleDbType.Int32, ParameterDirection.Output);
                Console.WriteLine(command.CommandText);
                object result = command.ExecuteScalar();
                total = Convert.ToInt32(result);
                return total;
=======
                command.Parameters.Add("v_total", OracleDbType.Decimal).Direction = ParameterDirection.ReturnValue;
                Console.WriteLine(command.CommandText);
                command.ExecuteNonQuery();
                total = Convert.ToInt32(command.Parameters["v_total"].Value);
>>>>>>> 73c16b7c5df4dc65f154f6f3c94191f2cd8cb2e3
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
        public DataSet ConsultarResidenciasXAlojamiento(string tipoResidencia)
        {
            DataSet ds = new DataSet();
            OracleConnection connection = new OracleConnection(getCadenaConexion());
            try
            {
                connection.Open();
                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = "paq_gerente.pr_verificacion_residencias";
                command.Parameters.Add("p_tipo_residencia", OracleDbType.Varchar2, ParameterDirection.Input).Value = tipoResidencia;
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
                // Agregar los parámetros de entrada al objeto OracleCommand
                command.Parameters.Add("p_fechaInicio", OracleDbType.Date, ParameterDirection.Input).Value = fechaInicio;
                command.Parameters.Add("p_fechaFin", OracleDbType.Date, ParameterDirection.Input).Value = fechaFin;
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
