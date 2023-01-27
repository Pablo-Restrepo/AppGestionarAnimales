using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTiendaMascotas.accesoDatos;
using System.Data;

namespace AppTiendaMascotas.logica
{
    class Venta
    {
        Datos dt = new Datos();
        public int ingresarVenta(int idProducto, int idEmpleado, int numProducto, string fechaVenta, int valorVenta)
        {
            int resultado;
            //paso 1: construyo la sentencia sql para insertar
            string consulta = "INSERT INTO VENTA (IDPRODUCTO,IDEMPLEADO,NUMPRODUCTO,FECHAVENTA,VALORVENTA) VALUES (" +
                idProducto + "," + idEmpleado + "," + numProducto + ",TO_TIMESTAMP('" + fechaVenta + "','DD/MM/YYYY HH24:MI:SS')," + valorVenta + ")";
            //paso 2: enviar la consulta a la capa de accesoDatos para ejecutarla
            resultado = dt.ejecutarDML(consulta);
            return resultado;
        }

        public int eliminarVenta(int idVenta)
        {
            int resultado;
            //paso 1: construyo la sentencia sql para insertar
            string consulta = "DELETE FROM VENTA WHERE IDVENTA = " + idVenta;
            resultado = dt.ejecutarDML(consulta);
            return resultado;
        }
        public DataSet consultarVentas()
        {
            DataSet rDT = new DataSet();
            string consulta;
            consulta = "SELECT IDVENTA,IDPRODUCTO,IDEMPLEADO,NUMPRODUCTO,FECHAVENTA,VALORVENTA FROM VENTA";
            rDT = dt.ejecutarSELECT(consulta);
            return rDT;
        }
    }
}
