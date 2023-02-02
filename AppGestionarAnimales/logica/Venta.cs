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

		public DataSet consultarVentasMenu()
		{
			DataSet rDT = new DataSet();
			string consulta;
			consulta = "SELECT NOMBREPRODUCTO Nombre, NUMPRODUCTO Cantidad, VALORVENTA Total FROM VENTA INNER JOIN PRODUCTO ON producto.serialproducto = venta.idproducto ORDER BY FECHAVENTA DESC";
			rDT = dt.ejecutarSELECT(consulta);
			return rDT;
		}

		public DataSet consultarVentaTotal()
		{
			DataSet rDT = new DataSet();
			string consulta;
			consulta = "SELECT SUM(VALORVENTA) FROM VENTA";
			rDT = dt.ejecutarSELECT(consulta);
			return rDT;
		}

		public DataTable consultarVentaIDs()
		{
			DataSet mids = new DataSet();
			string consulta;
			consulta = "SELECT IDVENTA FROM VENTA";
			mids = dt.ejecutarSELECT(consulta);
			DataTable dta = mids.Tables[0];
			return dta;
		}
	}
}
