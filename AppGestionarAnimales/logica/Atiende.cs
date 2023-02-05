using AppTiendaMascotas.accesoDatos;
using System.Data;

namespace AppTiendaMascotas.logica
{
    internal class Atiende
    {
        private Datos dt = new Datos();

        public int ingresarAtencion(int codEmpledo, int idMascota, string tipoAtencion, string descripcionAtencion, int costoAtencion)
        {
            int resultado;
            //paso 1: construyo la sentencia sql para insertar
            string consulta = "INSERT INTO ATIENDE (CODEMPLEADO,IDMASCOTA,TIPOATENCION,COSTOATENCION,descriptcion) VALUES (" +
                codEmpledo + "," + idMascota + ",'" + tipoAtencion + "'," + costoAtencion + ",'" + descripcionAtencion + "')";
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