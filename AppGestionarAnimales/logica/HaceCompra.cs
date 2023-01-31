using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTiendaMascotas.accesoDatos;
using System.Data;

namespace AppTiendaMascotas.logica
{
    class HaceCompra
    {
        Datos dt = new Datos();
        public int ingresarCompra(int idCliente, int idVenta)
        {
            int resultado;
            //paso 1: construyo la sentencia sql para insertar
            string consulta = "INSERT INTO HACECOMPRA (IDCLIENTE,IDVENTA) VALUES (" +
                idCliente + "," + idVenta + ")";
            //paso 2: enviar la consulta a la capa de accesoDatos para ejecutarla
            resultado = dt.ejecutarDML(consulta);
            return resultado;
        }
        public DataSet consultarCompras()
        {
            DataSet rDT = new DataSet();
            string consulta;
            consulta = "SELECT IDCLIENTE ID_DEL_CLIENTE,IDVENTA ID_DE_LA_VENTA FROM HACECOMPRA";
            rDT = dt.ejecutarSELECT(consulta);
            return rDT;
        }
    }
}
