using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTiendaMascotas.accesoDatos;
using System.Data;

namespace AppTiendaMascotas.logica
{
    class Mascota
    {
        //creo un objeto de la clase datos;
        Datos dt = new Datos();
        public int ingresarMascota(int idMascota, string nombreMascota, string tipoMascota, string especieMascota, string generoMascota, int cedulaDuenio) {
            int resultado;
            //paso 1: construyo la sentencia sql para insertar
            string consulta = "INSERT INTO MASCOTA (IDMASCOTA,NOMBREMASCOTA,TIPOMASCOTA,ESPECIEMASCOTA,GENEROMASCOTA,CEDULADUENIO) VALUES (" +
                idMascota + ",'" + nombreMascota + "','" + tipoMascota + "','" + especieMascota + "','" + generoMascota + "'," + cedulaDuenio + ")";
            //paso 2: enviar la consulta a la capa de accesoDatos para ejecutarla
            resultado = dt.ejecutarDML(consulta);
            return resultado;
        }

        public int eliminarMascota(int idMascota)
        {
            int resultado;
            //paso 1: construyo la sentencia sql para insertar
            string consulta = "DELETE FROM MASCOTA WHERE IDMASCOTA = " + idMascota;
            resultado = dt.ejecutarDML(consulta);
            return resultado;
        }

        public DataSet consultarMascotas()
        {
            DataSet rDT = new DataSet();
            string consulta;
            consulta = "SELECT IDMASCOTA,NOMBREMASCOTA,TIPOMASCOTA,ESPECIEMASCOTA,GENEROMASCOTA,CEDULADUENIO FROM MASCOTA";
            rDT = dt.ejecutarSELECT(consulta);
            return rDT;
        }

		public DataSet consultarMascotasMenu()
		{
			DataSet rDT = new DataSet();
			string consulta;
			consulta = "SELECT NOMBREMASCOTA Nombre,TIPOMASCOTA Tipo,ESPECIEMASCOTA Especie,GENEROMASCOTA Genero FROM MASCOTA";
			rDT = dt.ejecutarSELECT(consulta);
			return rDT;
		}
	}
}
