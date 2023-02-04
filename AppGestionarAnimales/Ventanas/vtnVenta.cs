using AppTiendaMascotas.logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppTiendaMascotas.Ventanas
{
	public partial class vtnVenta : Form
	{
		public vtnVenta()
		{
			InitializeComponent();
			style();
			informacion();
		}

		private Boolean bandera = true;
		private Boolean bandera2 = false;
		private Producto pro = new Producto();
		private Empleado emp = new Empleado();
		private Venta vent = new Venta();

		private void informacion()
		{
			cbxProducto.DataSource = pro.consultarProductoIDs();
			cbxProducto.DisplayMember = "NOMBREPRODUCTO";
			cbxProducto.ValueMember = "SERIALPRODUCTO";

			cbxEmpleado.DataSource = emp.consultarEmpleadoIDs();
			cbxEmpleado.DisplayMember = "NOMBREEMPLEADO";
			cbxEmpleado.ValueMember = "CODEMPLEADO";

			cbxIdVentaDelete.DataSource = vent.consultarVentaIDs();
			cbxIdVentaDelete.DisplayMember = "IDVENTA";
			cbxIdVentaDelete.ValueMember = "IDVENTA";

			DataSet dsResultado = new DataSet();
			dsResultado = vent.consultarVentas();
			dgvConsultaEmp.DataSource = dsResultado;
			dgvConsultaEmp.DataMember = "ResultadoDatos";
		}

		private void style()
		{
			dgvConsultaEmp.Region = new System.Drawing.Region(CreateRoundedRectangle(dgvConsultaEmp.Width, dgvConsultaEmp.Height));

			txtCantProd.Anchor = AnchorStyles.Top;
			cbxIdVentaDelete.Anchor = AnchorStyles.Top;
			lblCostoVenta.Anchor = AnchorStyles.Top;
			cbxEmpleado.Anchor = AnchorStyles.Top;
			cbxProducto.Anchor = AnchorStyles.Top;
			btnEliminar.Anchor = AnchorStyles.Top;
			btnGuardar.Anchor = AnchorStyles.Top;
			dgvConsultaEmp.Anchor = AnchorStyles.Top;
			pictureBox3.Anchor = AnchorStyles.Top;
			lblCostoVenta.Anchor = AnchorStyles.Top;
			timeFechaVenta.Anchor = AnchorStyles.Top;
			label1.Anchor = AnchorStyles.Top;
			label2.Anchor = AnchorStyles.Top;
			label3.Anchor = AnchorStyles.Top;
			label4.Anchor = AnchorStyles.Top;
			label5.Anchor = AnchorStyles.Top;
			label6.Anchor = AnchorStyles.Top;
			label7.Anchor = AnchorStyles.Top;
			label8.Anchor = AnchorStyles.Top;
			label10.Anchor = AnchorStyles.Top;
		}

		private System.Drawing.Drawing2D.GraphicsPath CreateRoundedRectangle(int buttonWidth, int buttonHeight)
		{
			System.Drawing.Drawing2D.GraphicsPath buttonPath = new System.Drawing.Drawing2D.GraphicsPath();
			int cornerRadius = 20;
			buttonPath.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
			buttonPath.AddArc(buttonWidth - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
			buttonPath.AddArc(buttonWidth - cornerRadius, buttonHeight - cornerRadius, cornerRadius, cornerRadius, 0, 90);
			buttonPath.AddArc(0, buttonHeight - cornerRadius, cornerRadius, cornerRadius, 90, 90);
			buttonPath.CloseFigure();
			return buttonPath;
		}

		private void scrollBar()
		{
			if (this.VerticalScroll.Visible && bandera)
			{
				bandera = false;
				bandera2 = true;
				label1.Location = new Point(label1.Location.X + 1, label1.Location.Y);
				label2.Location = new Point(label2.Location.X + 1, label2.Location.Y);
				label3.Location = new Point(label3.Location.X + 1, label3.Location.Y);
				label4.Location = new Point(label4.Location.X + 1, label4.Location.Y);
				label5.Location = new Point(label5.Location.X + 1, label5.Location.Y);
				label6.Location = new Point(label6.Location.X + 1, label6.Location.Y);
				label7.Location = new Point(label7.Location.X + 1, label7.Location.Y);
				label8.Location = new Point(label8.Location.X + 1, label8.Location.Y);
				label10.Location = new Point(label10.Location.X + 1, label10.Location.Y);
				dgvConsultaEmp.Location = new Point(dgvConsultaEmp.Location.X + 1, dgvConsultaEmp.Location.Y);
			}
			else if (!this.VerticalScroll.Visible && bandera2)
			{
				bandera = true;
				bandera2 = false;
				label1.Location = new Point(label1.Location.X - 2, label1.Location.Y);
				label2.Location = new Point(label2.Location.X - 2, label2.Location.Y);
				label3.Location = new Point(label3.Location.X - 2, label3.Location.Y);
				label4.Location = new Point(label4.Location.X - 2, label4.Location.Y);
				label5.Location = new Point(label5.Location.X - 2, label5.Location.Y);
				label6.Location = new Point(label6.Location.X - 2, label6.Location.Y);
				label7.Location = new Point(label7.Location.X - 2, label7.Location.Y);
				label8.Location = new Point(label8.Location.X - 2, label8.Location.Y);
				label10.Location = new Point(label10.Location.X - 2, label10.Location.Y);
				dgvConsultaEmp.Location = new Point(dgvConsultaEmp.Location.X - 2, dgvConsultaEmp.Location.Y);
			}
		}

		private void vtnResidencia_Resize(object sender, EventArgs e)
		{
			scrollBar();
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			if (cbxProducto.Text.Equals("") || cbxEmpleado.Text.Equals("") || txtCantProd.Text.Equals("") || lblCostoVenta.Text.Equals(""))
			{
				MessageBox.Show("Hay espacios vacios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			int idProducto, codEmpleado, numProducto, valorVenta, resultado;

			try
			{
				idProducto = Convert.ToInt32(cbxProducto.SelectedValue);
				codEmpleado = Convert.ToInt32(cbxEmpleado.SelectedValue);
				numProducto = int.Parse(txtCantProd.Text);
				valorVenta = int.Parse(lblCostoVenta.Text);
				resultado = vent.ingresarVenta(idProducto, codEmpleado, numProducto, valorVenta);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			if (resultado > 0)
			{
				informacion();
				MessageBox.Show("Venta registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCantProd.Text = "";
				lblCostoVenta.Text = "";
			}
			else
			{
				MessageBox.Show("Venta no registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnEliminar_Click(object sender, EventArgs e)
		{
			if (cbxIdVentaDelete.Text.Equals(""))
			{
				MessageBox.Show("Hay espacios vacios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			int idVenta, resultado;

			try
			{
				idVenta = Convert.ToInt32(cbxIdVentaDelete.SelectedValue);
				resultado = vent.eliminarVenta(idVenta);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			if (resultado > 0)
			{
				informacion();
				MessageBox.Show("Venta eliminada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("Venta no eliminada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        private void txtCantProd_TextChanged(object sender, EventArgs e)
        {
			string idProducto = Convert.ToString(cbxProducto.Text);
			if (txtCantProd.Text.Equals(""))
			{
				lblCostoVenta.Text = "";
            }
            else
            {
				int cantProducto = Convert.ToInt32(txtCantProd.Text);
				DataSet res = new DataSet();
				res = vent.valorVenta(idProducto);
				int valor = Convert.ToInt32(res.Tables["ResultadoDatos"].Rows[0]["PRECIOPRODUCTO"].ToString());
				lblCostoVenta.Text = Convert.ToString(valor * cantProducto);	
            }
			
		}
    }
}
