using AppTiendaMascotas.accesoDatos;
using System.Data;

namespace AppTiendaMascotas.logica
{
    internal class Producto
    {
        private Datos dt = new Datos();

        public int ingresarProducto(long serialProducto, string nombreProducto, int precioProducto, string tipoProducto)
        {
            int resultado;
            //paso 1: construyo la sentencia sql para insertar
            string consulta = "INSERT INTO PRODUCTO (SERIALPRODUCTO,NOMBREPRODUCTO,PRECIOPRODUCTO,TIPOPRODUCTO) VALUES (" +
                serialProducto + ",'" + nombreProducto + "'," + precioProducto + ",'" + tipoProducto + "')";
            //paso 2: enviar la consulta a la capa de accesoDatos para ejecutarla
            resultado = dt.ejecutarDML(consulta);
            return resultado;
        }

        public int eliminarProducto(int serialProducto)
        {
            int resultado;
            //paso 1: construyo la sentencia sql para insertar
            string consulta = "DELETE FROM PRODUCTO WHERE SERIALPRODUCTO = " + serialProducto;
            resultado = dt.ejecutarDML(consulta);
            return resultado;
        }

        public DataSet consultarProducto()
        {
            DataSet rDT = new DataSet();
            string consulta;
            consulta = "SELECT SERIALPRODUCTO SERIAL,NOMBREPRODUCTO NOMBRE,PRECIOPRODUCTO PRECIO,TIPOPRODUCTO TIPO FROM PRODUCTO";
            rDT = dt.ejecutarSELECT(consulta);
            return rDT;
        }

        public DataSet consultarProductoMenu()
        {
            DataSet rDT = new DataSet();
            string consulta;
            consulta = "SELECT SERIALPRODUCTO Serial,NOMBREPRODUCTO Nombre,PRECIOPRODUCTO Precio,TIPOPRODUCTO Tipo FROM PRODUCTO";
            rDT = dt.ejecutarSELECT(consulta);
            return rDT;
        }

        public string consultarProductoMasCaro()
        {
            DataSet rDT = new DataSet();
            string consulta;
            consulta = "SELECT NOMBREPRODUCTO FROM PRODUCTO WHERE PRECIOPRODUCTO = (SELECT MAX(PRECIOPRODUCTO) FROM PRODUCTO)";
            rDT = dt.ejecutarSELECT(consulta);
            return rDT.Tables[0].Rows[0][0].ToString();
        }

        public string consultarCantidadProductos()
        {
            DataSet rDT = new DataSet();
            string consulta;
            consulta = "SELECT COUNT(SERIALPRODUCTO) FROM PRODUCTO";
            rDT = dt.ejecutarSELECT(consulta);
            return rDT.Tables[0].Rows[0][0].ToString();
        }

        public DataSet buscar(string aux)
        {
            DataSet rDT = new DataSet();
            string consulta;
            consulta = "SELECT serialproducto ID, nombreproducto nombre, precioproducto informacion FROM producto WHERE lower(nombreproducto) like '%" + aux + "%' UNION SELECT codempleado, nombreempleado, salarioempleado FROM empleado WHERE lower(nombreempleado) like '%" + aux + "%' UNION SELECT ceduladuenio, nombreduenio, numtelefonoduenio FROM duenio WHERE lower(nombreduenio) like '%" + aux + "%' UNION SELECT idmascota, nombremascota, ceduladuenio FROM mascota WHERE lower(nombremascota) like '%" + aux + "%'";
            rDT = dt.ejecutarSELECT(consulta);
            return rDT;
        }

        public DataTable consultarProductoIDs()
        {
            DataSet mids = new DataSet();
            string consulta;
            consulta = "SELECT SERIALPRODUCTO, NOMBREPRODUCTO FROM PRODUCTO";
            mids = dt.ejecutarSELECT(consulta);
            DataTable dta = mids.Tables[0];
            return dta;
        }
    }
}