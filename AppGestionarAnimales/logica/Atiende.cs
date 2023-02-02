using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTiendaMascotas.accesoDatos;
using System.Data;

namespace AppTiendaMascotas.logica
{
    class Atiende
    {
        Datos dt = new Datos();
        public int ingresarAtencion(int codEmpledo, int idMascota, string tipoAtencion, string descripcionAtencion, string fechaAtencion, int costoAtencion)
        {
            int resultado;
            //paso 1: construyo la sentencia sql para insertar
            string consulta = "INSERT INTO ATIENDE (CODEMPLEADO,IDMASCOTA,TIPOATENCION,FECHAATENCION,COSTOATENCION,descriptcion) VALUES (" +
                codEmpledo + "," + idMascota + ",'" + tipoAtencion + "',TO_DATE('" + fechaAtencion + "','DD/MM/YY')," + costoAtencion + ",'" + descripcionAtencion+ "')";
            //paso 2: enviar la consulta a la capa de accesoDatos para ejecutarla
            resultado = dt.ejecutarDML(consulta);
            return resultado;
        }

        public int eliminarAtencion(int idAtencion)
        {
            int resultado;
            //paso 1: construyo la sentencia sql para insertar
            string consulta = "DELETE FROM ATIENDE WHERE IDATENCION = " + idAtencion;
            resultado = dt.ejecutarDML(consulta);
            return resultado;
        }

        public DataSet consultarAtenciones()
        {
            DataSet rDT = new DataSet();
            string consulta;
            consulta = "SELECT IDATENCION ID,CODEMPLEADO ID_EMPLEADO,IDMASCOTA ID_MASCOTA,TIPOATENCION TIPO,descriptcion DESCRIPCION,FECHAATENCION FECHA,COSTOATENCION COSTO FROM ATIENDE";
            rDT = dt.ejecutarSELECT(consulta);
            return rDT;
        }

		public DataTable consultarAtencionesIDs()
		{
			DataSet mids = new DataSet();
			string consulta;
			consulta = "SELECT IDATENCION FROM ATIENDE";
			mids = dt.ejecutarSELECT(consulta);
			DataTable dta = mids.Tables[0];
			return dta;
		}
	}
}
