using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppTiendaMascotas.logica;

namespace AppTiendaMascotas
{
    public partial class Tienda : Form
    {
        public Tienda()
        {
            InitializeComponent();
        }
        Residencia res = new Residencia();
        Cliente cli = new Cliente();
        Atiende atiende = new Atiende();
        Aloja aloja = new Aloja();
        Empleado emp = new Empleado();
        HaceCompra comp = new HaceCompra();
        Producto prod = new Producto();
        Mascota ani = new Mascota();
        Venta venta = new Venta();

        private void btmGuardarR_Click(object sender, EventArgs e)
        {
            int idResidencia, numResidentes, resultado;
            string tipoResidencia;

            idResidencia = int.Parse(txtIdR.Text);
            numResidentes = int.Parse(txtNumResi.Text);
            tipoResidencia = cbxTipoR.Text;
            try
            {
                resultado = res.ingresarResidencia(idResidencia, numResidentes, tipoResidencia);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (resultado > 0)
            {
                MessageBox.Show("Residencia registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Residencia no registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarC_Click(object sender, EventArgs e)
        {
            int resultado;
            long numTelefono, cedulaCliente;
            string nombreCliente;

            cedulaCliente = long.Parse(txtCedulaCliente.Text);
            numTelefono = long.Parse(txtNumTele.Text);
            nombreCliente = txtNombreC.Text;
            try
            {
                resultado = cli.ingresarCliente(cedulaCliente, nombreCliente, numTelefono);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (resultado > 0)
            {
                MessageBox.Show("Cliente registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cliente no registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarEmp_Click(object sender, EventArgs e)
        {
            int codEmpleado, resultado;
            long salarioEmpleado;
            string nombreEmpleado, apellidoEmpleado, cargoEmpleado, fechaIngreso;

            DateTime fechaIEmp = timeFechaIngreso.Value;
            fechaIngreso = fechaIEmp.ToString("dd'/'MM'/'yyyy");
            codEmpleado = int.Parse(txtCodEmpleado.Text);
            salarioEmpleado = int.Parse(txtSalarioEmp.Text);
            nombreEmpleado = txtNombreEmpleado.Text;
            apellidoEmpleado = txtApellidoEmpleado.Text;
            cargoEmpleado = cbxCargoEmp.Text;
            try
            {
                resultado = emp.ingresarEmpleado(codEmpleado, nombreEmpleado, apellidoEmpleado, cargoEmpleado, fechaIngreso, salarioEmpleado);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (resultado > 0)
            {
                MessageBox.Show("Empleado registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Empleado no registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            int precioProducto, resultado;
            long serialProducto;
            string nombreProducto, tipoProducto;

            serialProducto = int.Parse(txtSerialP.Text);
            precioProducto = int.Parse(txtPrecioP.Text);
            nombreProducto = txtNombreProducto.Text;
            tipoProducto = cbxTipoP.Text;
            try
            {
                resultado = prod.ingresarProducto(serialProducto, nombreProducto, precioProducto, tipoProducto);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (resultado > 0)
            {
                MessageBox.Show("Producto registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Producto no registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarMascota_Click(object sender, EventArgs e)
        {
            int idMascota, cedulaDuenio, resultado;
            string nombreMascota, tipoMascota, especieMascota, generoMascota;

            idMascota = int.Parse(txtMascotaId.Text);
            cedulaDuenio = int.Parse(txtCedulaDuenioM.Text);
            nombreMascota = txtNombreMascota.Text;
            tipoMascota = cbxTipoMascota.Text;
            especieMascota = txtEspecieMascota.Text;
            generoMascota = cbxGeneroMascota.Text;
            try
            {
                resultado = ani.ingresarMascota(idMascota, nombreMascota, tipoMascota, especieMascota, generoMascota, cedulaDuenio);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (resultado > 0)
            {
                MessageBox.Show("Mascota registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Mascota no registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarAlojamiento_Click(object sender, EventArgs e)
        {
            int idResidencia, idMascota, resultado;
            DateTime fechaInicio = timeFechaInicioAloj.Value;
            DateTime fechaFin = timeFechaFinAloj.Value;

            string fechaInicioAlojamiento, fechaFinAlojamiento;
            fechaInicioAlojamiento = fechaInicio.ToString("dd'/'MM'/'yyyy HH:mm:ss");
            fechaFinAlojamiento = fechaFin.ToString("dd'/'MM'/'yyyy HH:mm:ss");
            idResidencia = int.Parse(txtResidenciaIdA.Text);
            idMascota = int.Parse(txtMascotaIdA.Text);
            try
            {
                resultado = aloja.ingresarAlojamiento(idResidencia, idMascota, fechaInicioAlojamiento, fechaFinAlojamiento);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (resultado > 0)
            {
                MessageBox.Show("Alojamiento registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Residencio no registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarAtencion_Click(object sender, EventArgs e)
        {
            int codEmpleado, idMascota, costoAtencion, resultado;
            string tipoAtencion, fechaAtencion, descripcion;
            DateTime fechaA = timeFechaAtencion.Value;
            fechaAtencion = fechaA.ToString("dd'/'MM'/'yyyy");
            codEmpleado = int.Parse(txtCodEmpAten.Text);
            idMascota = int.Parse(txtMascotaIdAten.Text);
            costoAtencion = int.Parse(txtCostoAtencion.Text);
            tipoAtencion = cbxTipoAtencion.Text;
            descripcion = txtDescAtencion.Text;
            try
            {
                resultado = atiende.ingresarAtencion(codEmpleado, idMascota, tipoAtencion, descripcion, fechaAtencion, costoAtencion);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (resultado > 0)
            {
                MessageBox.Show("Atencion registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Atencion no registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarVenta_Click(object sender, EventArgs e)
        {
            int idProducto, codEmpleado, numProducto, valorVenta, resultado;
            DateTime fechaV = timeFechaVenta.Value;
            idProducto = int.Parse(txtCodProducto.Text);
            codEmpleado = int.Parse(txtCodEmp.Text);
            numProducto = int.Parse(txtCantProd.Text);
            valorVenta = int.Parse(txtCostoVenta.Text);
            try
            {
                resultado = venta.ingresarVenta(idProducto, codEmpleado, numProducto, fechaV.ToString("dd'/'MM'/'yyyy HH:mm:ss"), valorVenta);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (resultado > 0)
            {
                MessageBox.Show("Venta registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Venta no registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //Eliminar:

        private void btnEliminarResidencia_Click(object sender, EventArgs e)
        {
            int numResidencia, resultado;

            numResidencia = int.Parse(txtIdResidenciaDelete.Text);
            try
            {
                resultado = res.eliminarResidencia(numResidencia);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (resultado > 0)
            {
                MessageBox.Show("Residencia eliminada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Residencia no eliminada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            int idCliente, resultado;

            idCliente = int.Parse(txtIdClienteDelete.Text);
            try
            {
                resultado = cli.eliminarCliente(idCliente);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (resultado > 0)
            {
                MessageBox.Show("Cliente eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cliente no eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarEmpleado_Click(object sender, EventArgs e)
        {
            int codEmpleado, resultado;

            codEmpleado = int.Parse(txtCodEmpleadoDelete.Text);
            try
            {
                resultado = emp.eliminarEmpleado(codEmpleado);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (resultado > 0)
            {
                MessageBox.Show("Empleado eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Empleado no eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            int serialProducto, resultado;

            serialProducto = int.Parse(txtSerialProdDelete.Text);
            try
            {
                resultado = prod.eliminarProducto(serialProducto);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (resultado > 0)
            {
                MessageBox.Show("Producto eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Producto no eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarMascota_Click(object sender, EventArgs e)
        {
            int idMascota, resultado;

            idMascota = int.Parse(txtIdMascotaDelete.Text);
            try
            {
                resultado = ani.eliminarMascota(idMascota);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (resultado > 0)
            {
                MessageBox.Show("Mascota eliminada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Mascota no eliminada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarAlojamiento_Click(object sender, EventArgs e)
        {
            int idAlojamiento, resultado;

            idAlojamiento = int.Parse(txtAlojamientoDelete.Text);
            try
            {
                resultado = aloja.eliminarAlojamiento(idAlojamiento);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (resultado > 0)
            {
                MessageBox.Show("Alojamiento eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Alojamiento no eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        private void btnEliminarAtencion_Click(object sender, EventArgs e)
        {
            int idAtencion, resultado;

            idAtencion = int.Parse(txtAtencionDelete.Text);
            try
            {
                resultado = atiende.eliminarAtencion(idAtencion);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (resultado > 0)
            {
                MessageBox.Show("Atencion eliminada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Atencion no eliminada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarVenta_Click(object sender, EventArgs e)
        {
            int idVenta, resultado;

            idVenta = int.Parse(txtIdVentaDelete.Text);
            try
            {
                resultado = venta.eliminarVenta(idVenta);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (resultado > 0)
            {
                MessageBox.Show("Venta eliminada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Venta no eliminada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        //Consultas:

        private void btnConsultarResTR_Click(object sender, EventArgs e)
        {
            //paso 1: creo un dataset vacio
            DataSet dsResultado = new DataSet();
            //paso2: ejecutar el metodo en la capa de la logica que permite
            //consultar todos los animales
            try
            {
                dsResultado = res.consultarResidencia();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvDatosResidenciaR.DataSource = dsResultado;
            dgvDatosResidenciaR.DataMember = "ResultadoDatos";
        }

        private void btnConsultarClienteC_Click(object sender, EventArgs e)
        {
            //paso 1: creo un dataset vacio
            DataSet dsResultado = new DataSet();
            //paso2: ejecutar el metodo en la capa de la logica que permite
            //consultar todos los animales
            try
            {
                dsResultado = cli.consultarCliente();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvConsultaClientes.DataSource = dsResultado;
            dgvConsultaClientes.DataMember = "ResultadoDatos";
        }

        private void btnConsultarEmpleados_Click(object sender, EventArgs e)
        {
            //paso 1: creo un dataset vacio
            DataSet dsResultado = new DataSet();
            //paso2: ejecutar el metodo en la capa de la logica que permite
            //consultar todos los animales
            try
            {
                dsResultado = emp.consultarEmpleado();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvConsultaEmp.DataSource = dsResultado;
            dgvConsultaEmp.DataMember = "ResultadoDatos";
        }

        private void btnConsultarProductos_Click(object sender, EventArgs e)
        {
            //paso 1: creo un dataset vacio
            DataSet dsResultado = new DataSet();
            //paso2: ejecutar el metodo en la capa de la logica que permite
            //consultar todos los animales
            try
            {
                dsResultado = prod.consultarProducto();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvConsultaProducto.DataSource = dsResultado;
            dgvConsultaProducto.DataMember = "ResultadoDatos";
        }

        private void btnConsultarMascota_Click(object sender, EventArgs e)
        {
            //paso 1: creo un dataset vacio
            DataSet dsResultado = new DataSet();
            //paso2: ejecutar el metodo en la capa de la logica que permite
            //consultar todos los animales
            try
            {
                dsResultado = ani.consultarMascotas();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvConsultaMascota.DataSource = dsResultado;
            dgvConsultaMascota.DataMember = "ResultadoDatos";
        }

        private void btnConsultarCliente_Click(object sender, EventArgs e)
        {
            //paso 1: creo un dataset vacio
            DataSet dsResultado = new DataSet();
            //paso2: ejecutar el metodo en la capa de la logica que permite
            //consultar todos los animales
            try
            {
                dsResultado = cli.consultarCliente();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvConsultaDuenios.DataSource = dsResultado;
            dgvConsultaDuenios.DataMember = "ResultadoDatos";
        }

        private void btnConsultarResidencia_Click(object sender, EventArgs e)
        {
            //paso 1: creo un dataset vacio
            DataSet dsResultado = new DataSet();
            //paso2: ejecutar el metodo en la capa de la logica que permite
            //consultar todos los animales
            try
            {
                dsResultado = res.consultarResidencia();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvConsultaResidencia.DataSource = dsResultado;
            dgvConsultaResidencia.DataMember = "ResultadoDatos";
        }

        private void btnConsultaMascota_Click(object sender, EventArgs e)
        {
            //paso 1: creo un dataset vacio
            DataSet dsResultado = new DataSet();
            //paso2: ejecutar el metodo en la capa de la logica que permite
            //consultar todos los animales
            try
            {
                dsResultado = ani.consultarMascotas();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvConsultaMascotaA.DataSource = dsResultado;
            dgvConsultaMascotaA.DataMember = "ResultadoDatos";
        }

        private void btnConsultarEmpleadosAt_Click(object sender, EventArgs e)
        {
            //paso 1: creo un dataset vacio
            DataSet dsResultado = new DataSet();
            //paso2: ejecutar el metodo en la capa de la logica que permite
            //consultar todos los animales
            try
            {
                dsResultado = emp.consultarEmpleado();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvConsultaEmpleadoAti.DataSource = dsResultado;
            dgvConsultaEmpleadoAti.DataMember = "ResultadoDatos";
        }

        private void btnConsultarMascotaAt_Click(object sender, EventArgs e)
        {
            //paso 1: creo un dataset vacio
            DataSet dsResultado = new DataSet();
            //paso2: ejecutar el metodo en la capa de la logica que permite
            //consultar todos los animales
            try
            {
                dsResultado = ani.consultarMascotas();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvConsultaMascotaAt.DataSource = dsResultado;
            dgvConsultaMascotaAt.DataMember = "ResultadoDatos"; 
        }

        private void btnConsultaProductoV_Click(object sender, EventArgs e)
        {
            //paso 1: creo un dataset vacio
            DataSet dsResultado = new DataSet();
            //paso2: ejecutar el metodo en la capa de la logica que permite
            //consultar todos los animales
            try
            {
                dsResultado = prod.consultarProducto();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvConsultaProductoV.DataSource = dsResultado;
            dgvConsultaProductoV.DataMember = "ResultadoDatos";
        }

        private void btnConsultaEmpleadoV_Click(object sender, EventArgs e)
        {
            //paso 1: creo un dataset vacio
            DataSet dsResultado = new DataSet();
            //paso2: ejecutar el metodo en la capa de la logica que permite
            //consultar todos los animales
            try
            {
                dsResultado = emp.consultarEmpleado();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvConsultaEmpleadoV.DataSource = dsResultado;
            dgvConsultaEmpleadoV.DataMember = "ResultadoDatos";
        }

        private void btnConsultaClienteComp_Click(object sender, EventArgs e)
        {
            //paso 1: creo un dataset vacio
            DataSet dsResultado = new DataSet();
            //paso2: ejecutar el metodo en la capa de la logica que permite
            //consultar todos los animales
            try
            {
                dsResultado = cli.consultarCliente();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvConsultaClientesComp.DataSource = dsResultado;
            dgvConsultaClientesComp.DataMember = "ResultadoDatos";
        }

        private void btnConsultaVentaC_Click(object sender, EventArgs e)
        {
            //paso 1: creo un dataset vacio
            DataSet dsResultado = new DataSet();
            //paso2: ejecutar el metodo en la capa de la logica que permite
            //consultar todos los animales
            try
            {
                dsResultado = venta.consultarVentas();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvConsultaVentasC.DataSource = dsResultado;
            dgvConsultaVentasC.DataMember = "ResultadoDatos";
        }

        private void btnConsultarAlojamiento_Click(object sender, EventArgs e)
        {
            //paso 1: creo un dataset vacio
            DataSet dsResultado = new DataSet();
            //paso2: ejecutar el metodo en la capa de la logica que permite
            //consultar todos los animales
            try
            {
                dsResultado = aloja.consultarAlojamiento();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvConsultaAlojamiento.DataSource = dsResultado;
            dgvConsultaAlojamiento.DataMember = "ResultadoDatos";
        }

        private void btnConsultaAtenciones_Click(object sender, EventArgs e)
        {
            //paso 1: creo un dataset vacio
            DataSet dsResultado = new DataSet();
            //paso2: ejecutar el metodo en la capa de la logica que permite
            //consultar todos los animales
            try
            {
                dsResultado = atiende.consultarAtenciones();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvConsultaAtenciones.DataSource = dsResultado;
            dgvConsultaAtenciones.DataMember = "ResultadoDatos";
        }

        private void btnConsultarVentas_Click(object sender, EventArgs e)
        {
            //paso 1: creo un dataset vacio
            DataSet dsResultado = new DataSet();
            //paso2: ejecutar el metodo en la capa de la logica que permite
            //consultar todos los animales
            try
            {
                dsResultado = venta.consultarVentas();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvConsultarVentas.DataSource = dsResultado;
            dgvConsultarVentas.DataMember = "ResultadoDatos";
        }

        private void btnConsultarCompra_Click(object sender, EventArgs e)
        {
            //paso 1: creo un dataset vacio
            DataSet dsResultado = new DataSet();
            //paso2: ejecutar el metodo en la capa de la logica que permite
            //consultar todos los animales
            try
            {
                dsResultado = comp.consultarCompras();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvConsultaCompra.DataSource = dsResultado;
            dgvConsultaCompra.DataMember = "ResultadoDatos";
        }

        private void btnGuardarCompra_Click(object sender, EventArgs e)
        {
            int codVenta, codCliente, resultado;

            codVenta = int.Parse(txtCodVenta.Text);
            codCliente = int.Parse(txtCodCliente.Text);
            try
            {
                resultado = comp.ingresarCompra(codCliente, codVenta);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (resultado > 0)
            {
                MessageBox.Show("Compra registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Compra no registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsulta1_Click(object sender, EventArgs e)
        {
            try
            {
                lblResConsulta1.Text = res.consultarCantidadResidencias();
                lblResConsulta2.Text = cli.consultarCantidadClientes();
                lblResConsulta3.Text = emp.consultarSalarioPromedioEmpleado();
                lblResConsulta4.Text = prod.consultarProductoMasCaro();
                lblResConsulta5.Text = prod.consultarCantidadProductos();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
