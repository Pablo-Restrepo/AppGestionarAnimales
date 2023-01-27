using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTiendaMascotas.accesoDatos;
using System.Data;

namespace AppTiendaMascotas.logica
{
    class Producto
    {
        Datos dt = new Datos();
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
            consulta = "SELECT SERIALPRODUCTO,NOMBREPRODUCTO,PRECIOPRODUCTO,TIPOPRODUCTO FROM PRODUCTO";
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
    }
}
