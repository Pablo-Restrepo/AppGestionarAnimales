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
		private Cliente cliente = new Cliente();

		private void informacion()
		{
			cbxEmpledoElim.DataSource = cliente.consultarClienteIDs();
			cbxEmpledoElim.DisplayMember = "NOMBREDUENIO";
			cbxEmpledoElim.ValueMember = "CEDULADUENIO";

			DataSet dsResultado = new DataSet();
			dsResultado = cliente.consultarCliente();
			dgvConsultaEmp.DataSource = dsResultado;
			dgvConsultaEmp.DataMember = "ResultadoDatos";
		}

		private void style()
		{
			dgvConsultaEmp.Region = new System.Drawing.Region(CreateRoundedRectangle(dgvConsultaEmp.Width, dgvConsultaEmp.Height));

			txtApellidoEmpleado.Anchor = AnchorStyles.Top;
			cbxEmpledoElim.Anchor = AnchorStyles.Top;
			cbxCargoEmp.Anchor = AnchorStyles.Top;
			btnEliminarEmpleado.Anchor = AnchorStyles.Top;
			btnGuardarEmp.Anchor = AnchorStyles.Top;
			dgvConsultaEmp.Anchor = AnchorStyles.Top;
			pictureBox3.Anchor = AnchorStyles.Top;
			timeFechaIngreso.Anchor = AnchorStyles.Top;
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
				dgvConsultaEmp.Location = new Point(dgvConsultaEmp.Location.X - 2, dgvConsultaEmp.Location.Y);
			}
		}

		private void vtnResidencia_Resize(object sender, EventArgs e)
		{
			scrollBar();
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{

		}

		private void btnEliminar_Click(object sender, EventArgs e)
		{
			int idCliente, resultado;

			idCliente = int.Parse(cbxEmpledoElim.Text);
			resultado = cliente.eliminarCliente(idCliente);
			if (resultado > 0)
			{
				MessageBox.Show("Cliente eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("Cliente no eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
