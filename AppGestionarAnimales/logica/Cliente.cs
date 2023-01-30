using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTiendaMascotas.accesoDatos;
using System.Data;

namespace AppTiendaMascotas.logica
{
    class Cliente
    {
        Datos dt = new Datos();
        public int ingresarCliente(long cedulaDuenio, string nombreDuenio, long numTelefonoDuenio)
        {
            int resultado;
            //paso 1: construyo la sentencia sql para insertar
            string consulta = "INSERT INTO DUENIO (CEDULADUENIO,NOMBREDUENIO,NUMTELEFONODUENIO) VALUES (" +
                cedulaDuenio + ",'" + nombreDuenio + "'," + numTelefonoDuenio + ")";
            //paso 2: enviar la consulta a la capa de accesoDatos para ejecutarla
            resultado = dt.ejecutarDML(consulta);
            return resultado;
        }
        public int eliminarCliente(int cedulaCliente)
        {
            int resultado;
            //paso 1: construyo la sentencia sql para insertar
            string consulta = "DELETE FROM DUENIO WHERE CEDULADUENIO = " + cedulaCliente;
            resultado = dt.ejecutarDML(consulta);
            return resultado;
        }

        public DataSet consultarCliente()
        {
            DataSet rDT = new DataSet();
            string consulta;
            consulta = "SELECT CEDULADUENIO,NOMBREDUENIO,NUMTELEFONODUENIO FROM DUENIO";
            rDT = dt.ejecutarSELECT(consulta);
            return rDT;
        }

		public DataSet consultarClienteMenu()
		{
			DataSet rDT = new DataSet();
			string consulta;
			consulta = "SELECT CEDULADUENIO Cedula,NOMBREDUENIO Nombre,NUMTELEFONODUENIO Numero FROM DUENIO";
			rDT = dt.ejecutarSELECT(consulta);
			return rDT;
		}

		public string consultarCantidadClientes()
        {
            DataSet rDT = new DataSet();
            string consulta;
            consulta = "SELECT COUNT(CEDULADUENIO) FROM DUENIO";
            rDT = dt.ejecutarSELECT(consulta);
            return rDT.Tables[0].Rows[0][0].ToString();
        }

		public DataTable consultarClienteIDs()
		{
			DataSet mids = new DataSet();
			string consulta;
			consulta = "SELECT CEDULADUENIO, NOMBREDUENIO FROM DUENIO";
			mids = dt.ejecutarSELECT(consulta);
			DataTable dta = mids.Tables[0];
			return dta;
		}
	}
}
