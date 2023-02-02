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
	public partial class vtnProducto : Form
	{
		public vtnProducto()
		{
			InitializeComponent();
			style();
			informacion();
		}

		private Boolean bandera = true;
		private Boolean bandera2 = false;
		private Producto prod = new Producto();

		private void informacion()
		{
			cbxSerialProdDelete.DataSource = prod.consultarProductoIDs(); 
			cbxSerialProdDelete.DisplayMember = "NOMBREPRODUCTO";
			cbxSerialProdDelete.ValueMember = "SERIALPRODUCTO";

			DataSet dsResultado = new DataSet();
			dsResultado = prod.consultarProducto();
			dgvConsultaProducto.DataSource = dsResultado;
			dgvConsultaProducto.DataMember = "ResultadoDatos";
		}

		private void style()
		{
			dgvConsultaProducto.Region = new System.Drawing.Region(CreateRoundedRectangle(dgvConsultaProducto.Width, dgvConsultaProducto.Height));

			txtSerialP.Anchor = AnchorStyles.Top;
			txtPrecioP.Anchor = AnchorStyles.Top;
			txtNombreProducto.Anchor = AnchorStyles.Top;
			cbxSerialProdDelete.Anchor = AnchorStyles.Top;
			cbxTipoP.Anchor = AnchorStyles.Top;
			pictureBox1.Anchor = AnchorStyles.Top;
			btnEliminarProducto.Anchor = AnchorStyles.Top;
			btnGuardarProducto.Anchor = AnchorStyles.Top;
			dgvConsultaProducto.Anchor = AnchorStyles.Top;
			pictureBox2.Anchor = AnchorStyles.Top;
			pictureBox3.Anchor = AnchorStyles.Top;
			label1.Anchor = AnchorStyles.Top;
			label2.Anchor = AnchorStyles.Top;
			label3.Anchor = AnchorStyles.Top;
			label4.Anchor = AnchorStyles.Top;
			label5.Anchor = AnchorStyles.Top;
			label6.Anchor = AnchorStyles.Top;
			label7.Anchor = AnchorStyles.Top;
			label8.Anchor = AnchorStyles.Top;
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
				dgvConsultaProducto.Location = new Point(dgvConsultaProducto.Location.X + 1, dgvConsultaProducto.Location.Y);
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
				dgvConsultaProducto.Location = new Point(dgvConsultaProducto.Location.X - 2, dgvConsultaProducto.Location.Y);
			}
		}

		private void vtnResidencia_Resize(object sender, EventArgs e)
		{
			scrollBar();
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			if (txtSerialP.Text.Equals("") || txtPrecioP.Text.Equals("") || txtNombreProducto.Text.Equals("") || cbxTipoP.Text.Equals(""))
			{
				MessageBox.Show("Hay espacios vacios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			int precioProducto, resultado;
			long serialProducto;
			string nombreProducto, tipoProducto;

			try
			{
				serialProducto = int.Parse(txtSerialP.Text);
				precioProducto = int.Parse(txtPrecioP.Text);
				nombreProducto = txtNombreProducto.Text;
				tipoProducto = cbxTipoP.Text;
				resultado = prod.ingresarProducto(serialProducto, nombreProducto, precioProducto, tipoProducto);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (resultado > 0)
			{
				informacion();
				MessageBox.Show("Producto registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtSerialP.Text = "";
				txtPrecioP.Text = "";
				txtNombreProducto.Text = "";
			}
			else
			{
				MessageBox.Show("Producto no registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnEliminar_Click(object sender, EventArgs e)
		{
			if (cbxSerialProdDelete.Text.Equals(""))
			{
				MessageBox.Show("Hay espacios vacios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			int serialProducto, resultado;

			try
			{
				serialProducto = Convert.ToInt32(cbxSerialProdDelete.SelectedValue);
				resultado = prod.eliminarProducto(serialProducto);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (resultado > 0)
			{
				informacion();
				MessageBox.Show("Producto eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("Producto no eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
