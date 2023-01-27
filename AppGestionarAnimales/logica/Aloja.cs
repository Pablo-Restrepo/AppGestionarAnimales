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
        public int ingresarAlojamiento(int idResidencia, int idMascota, string fechaInicioAlojamiento, string fechaFinAlojamiento)
        {
            int resultado;
            //paso 1: construyo la sentencia sql para insertar
            string consulta = "INSERT INTO ALOJA (IDRESIDENCIA,IDMASCOTA,FECHAINICIOALOJAMIENTO,FECHAFINALOJAMIENTO) VALUES (" +
                idResidencia + "," + idMascota + ",TO_TIMESTAMP('" + fechaInicioAlojamiento + "','DD/MM/YYYY HH24:MI:SS'),TO_TIMESTAMP('" + fechaFinAlojamiento + "','DD/MM/YYYY HH24:MI:SS'))";
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
            consulta = "SELECT IDALOJA,IDRESIDENCIA,IDMASCOTA,FECHAINICIOALOJAMIENTO,FECHAFINALOJAMIENTO FROM ALOJA";
            rDT = dt.ejecutarSELECT(consulta);
            return rDT;
        }
    }
}
