using AppTiendaMascotas.accesoDatos;
using System.Data;

namespace AppTiendaMascotas.logica
{
    internal class Venta
    {
        private Datos dt = new Datos();

        public int ingresarVenta(int idProducto, int idEmpleado, int numProducto, int valorVenta)
        {
            int resultado;
            //paso 1: construyo la sentencia sql para insertar
            string consulta = "INSERT INTO VENTA (IDPRODUCTO,IDEMPLEADO,NUMPRODUCTO,VALORVENTA) VALUES (" +
                idProducto + "," + idEmpleado + "," + numProducto + "," + valorVenta + ")";
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
            consulta = "SELECT SUM(VALORVENTA*NUMPRODUCTO) FROM VENTA";
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

        public DataSet valorVenta(string idProducto)
        {
            DataSet rDT = new DataSet();
            string consulta = "SELECT PRECIOPRODUCTO FROM PRODUCTO WHERE NOMBREPRODUCTO = 'Cama Perro'";
            rDT = dt.ejecutarSELECT(consulta);
            return rDT;
        }
    }
}