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
	public partial class vtnCliente : Form
	{
		public vtnCliente()
		{
			InitializeComponent();
			style();
			informacion();
		}

		private Boolean bandera = true;
		private Boolean bandera2 = false;
		private Cliente cliente = new Cliente();

		private void informacion()
		{
			cbxIdClienteDelete.DataSource = cliente.consultarClienteIDs();
			cbxIdClienteDelete.DisplayMember = "NOMBREDUENIO";
			cbxIdClienteDelete.ValueMember = "CEDULADUENIO";

			DataSet dsResultado = new DataSet();
			dsResultado = cliente.consultarCliente();
			dgvConsultaClientes.DataSource = dsResultado;
			dgvConsultaClientes.DataMember = "ResultadoDatos";
		}

		private void style()
		{
			dgvConsultaClientes.Region = new System.Drawing.Region(CreateRoundedRectangle(dgvConsultaClientes.Width, dgvConsultaClientes.Height));

			txtCedulaCliente.Anchor = AnchorStyles.Top;
			txtNumTele.Anchor = AnchorStyles.Top;
			txtNombreC.Anchor = AnchorStyles.Top;
			cbxIdClienteDelete.Anchor = AnchorStyles.Top;
			pictureBox1.Anchor = AnchorStyles.Top;
			btnEliminarCliente.Anchor = AnchorStyles.Top;
			btnGuardarC.Anchor = AnchorStyles.Top;
			dgvConsultaClientes.Anchor = AnchorStyles.Top;
			pictureBox2.Anchor = AnchorStyles.Top;
			pictureBox3.Anchor = AnchorStyles.Top;
			label1.Anchor = AnchorStyles.Top;
			label2.Anchor = AnchorStyles.Top;
			label3.Anchor = AnchorStyles.Top;
			label4.Anchor = AnchorStyles.Top;
			label5.Anchor = AnchorStyles.Top;
			label6.Anchor = AnchorStyles.Top;
			label7.Anchor = AnchorStyles.Top;
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
				dgvConsultaClientes.Location = new Point(dgvConsultaClientes.Location.X + 1, dgvConsultaClientes.Location.Y);
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
				dgvConsultaClientes.Location = new Point(dgvConsultaClientes.Location.X - 2, dgvConsultaClientes.Location.Y);
			}
		}

		private void vtnResidencia_Resize(object sender, EventArgs e)
		{
			scrollBar();
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			if (txtCedulaCliente.Text.Equals("") || txtNumTele.Text.Equals("") || txtNombreC.Text.Equals(""))
			{
				MessageBox.Show("Hay espacios vacios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			int resultado;
			long numTelefono, cedulaCliente;
			string nombreCliente;

			try
			{
				cedulaCliente = long.Parse(txtCedulaCliente.Text);
				numTelefono = long.Parse(txtNumTele.Text);
				nombreCliente = txtNombreC.Text;
				resultado = cliente.ingresarCliente(cedulaCliente, nombreCliente, numTelefono);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (resultado > 0)
			{
				informacion();
				MessageBox.Show("Cliente registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCedulaCliente.Text = "";
				txtNumTele.Text = "";
				txtNombreC.Text = "";
			}
			else
			{
				MessageBox.Show("Cliente no registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnEliminar_Click(object sender, EventArgs e)
		{
			if (cbxIdClienteDelete.Text.Equals(""))
			{
				MessageBox.Show("Hay espacios vacios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			int idCliente, resultado;

			try
			{
				idCliente = Convert.ToInt32(cbxIdClienteDelete.SelectedValue);
				resultado = cliente.eliminarCliente(idCliente);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (resultado > 0)
			{
				informacion();
				MessageBox.Show("Cliente eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("Cliente no eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
