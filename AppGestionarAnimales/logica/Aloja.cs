using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTiendaMascotas.accesoDatos;
using System.Data;

namespace AppTiendaMascotas.logica
{
    class Aloja
    {
        Datos dt = new Datos();
        public int ingresarAlojamiento(int idResidencia, int idMascota, string fechaFinAlojamiento)
        {
            int resultado;
            //paso 1: construyo la sentencia sql para insertar
            string consulta = "INSERT INTO ALOJA (IDRESIDENCIA,IDMASCOTA,FECHAINICIOALOJAMIENTO,FECHAFINALOJAMIENTO) VALUES (" +
                idResidencia + "," + idMascota + ",TO_TIMESTAMP('" + fechaFinAlojamiento + "','DD/MM/YYYY HH24:MI:SS'))";
            //paso 2: enviar la consulta a la capa de accesoDatos para ejecutarla
            resultado = dt.ejecutarDML(consulta);
            return resultado;
        }

        public int eliminarAlojamiento(int idAlojamiento)
        {
            int resultado;
            //paso 1: construyo la sentencia sql para insertar
            string consulta = "DELETE FROM ALOJA WHERE IDALOJA = " + idAlojamiento;
            resultado = dt.ejecutarDML(consulta);
            return resultado;
        }

        public DataSet consultarAlojamiento()
        {
            DataSet rDT = new DataSet();
            string consulta;
            consulta = "SELECT IDALOJA ID,IDRESIDENCIA ID_RESIDENCIA,IDMASCOTA ID_MASCOTA,FECHAINICIOALOJAMIENTO FECHA_INICIO,FECHAFINALOJAMIENTO FECHA_FINAL FROM ALOJA";
            rDT = dt.ejecutarSELECT(consulta);
            return rDT;
        }

		public DataSet consultarNumAlojamiento()
		{
			DataSet rDT = new DataSet();
			string consulta;
			consulta = "SELECT COUNT(IDALOJA) FROM ALOJA WHERE fechafinalojamiento >= SYSDATE";
			rDT = dt.ejecutarSELECT(consulta);
			return rDT;
		}

		public DataTable consultarAlojamientoIDs()
		{
			DataSet mids = new DataSet();
			string consulta;
			consulta = "SELECT IDALOJA, IDALOJA FROM ALOJA";
			mids = dt.ejecutarSELECT(consulta);
			DataTable dta = mids.Tables[0];
			return dta;
		}
	}
}
