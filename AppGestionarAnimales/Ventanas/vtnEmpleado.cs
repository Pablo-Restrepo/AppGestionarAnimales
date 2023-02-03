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
	public partial class vtnEmpleado : Form
	{
		public vtnEmpleado()
		{
			InitializeComponent();
			style();
			informacion();
		}

		private Boolean bandera = true;
		private Boolean bandera2 = false;
		private Empleado emp = new Empleado();

		private void informacion()
		{
			cbxEmpledoElim.DataSource = emp.consultarEmpleadoIDs();
			cbxEmpledoElim.DisplayMember = "NOMBREEMPLEADO";
			cbxEmpledoElim.ValueMember = "CODEMPLEADO";

			DataSet dsResultado = new DataSet();
			dsResultado = emp.consultarEmpleado();
			dgvConsultaEmp.DataSource = dsResultado;
			dgvConsultaEmp.DataMember = "ResultadoDatos";
		}

		private void style()
		{
			dgvConsultaEmp.Region = new System.Drawing.Region(CreateRoundedRectangle(dgvConsultaEmp.Width, dgvConsultaEmp.Height));

			txtCodEmpleado.Anchor = AnchorStyles.Top;
			txtApellidoEmpleado.Anchor = AnchorStyles.Top;
			txtNombreEmpleado.Anchor = AnchorStyles.Top;
			cbxEmpledoElim.Anchor = AnchorStyles.Top;
			cbxCargoEmp.Anchor = AnchorStyles.Top;
			pictureBox1.Anchor = AnchorStyles.Top;
			btnEliminarEmpleado.Anchor = AnchorStyles.Top;
			btnGuardarEmp.Anchor = AnchorStyles.Top;
			dgvConsultaEmp.Anchor = AnchorStyles.Top;
			pictureBox2.Anchor = AnchorStyles.Top;
			pictureBox3.Anchor = AnchorStyles.Top;
			pictureBox5.Anchor = AnchorStyles.Top;
			txtSalarioEmp.Anchor = AnchorStyles.Top;
			timeFechaIngreso.Anchor = AnchorStyles.Top;
			label1.Anchor = AnchorStyles.Top;
			label2.Anchor = AnchorStyles.Top;
			label3.Anchor = AnchorStyles.Top;
			label4.Anchor = AnchorStyles.Top;
			label5.Anchor = AnchorStyles.Top;
			label6.Anchor = AnchorStyles.Top;
			label7.Anchor = AnchorStyles.Top;
			label8.Anchor = AnchorStyles.Top;
			label9.Anchor = AnchorStyles.Top;
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
				label9.Location = new Point(label9.Location.X + 1, label9.Location.Y);
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
				label9.Location = new Point(label9.Location.X - 2, label9.Location.Y);
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
			if (txtCodEmpleado.Text.Equals("") || txtSalarioEmp.Text.Equals("") || txtNombreEmpleado.Text.Equals("") || txtApellidoEmpleado.Text.Equals("") || cbxCargoEmp.Text.Equals(""))
			{
				MessageBox.Show("Hay espacios vacios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			int codEmpleado, resultado;
			long salarioEmpleado;
			string nombreEmpleado, apellidoEmpleado, cargoEmpleado;

			try
			{
				codEmpleado = int.Parse(txtCodEmpleado.Text);
				salarioEmpleado = int.Parse(txtSalarioEmp.Text);
				nombreEmpleado = txtNombreEmpleado.Text;
				apellidoEmpleado = txtApellidoEmpleado.Text;
				cargoEmpleado = cbxCargoEmp.Text;
				resultado = emp.ingresarEmpleado(codEmpleado, nombreEmpleado, apellidoEmpleado, cargoEmpleado, salarioEmpleado);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (resultado > 0)
			{
				informacion();
				MessageBox.Show("Empleado registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
				timeFechaIngreso.Text = "";
				txtCodEmpleado.Text = "";
				txtNombreEmpleado.Text = "";
				txtSalarioEmp.Text = "";
				txtApellidoEmpleado.Text = "";
			}
			else
			{
				MessageBox.Show("Empleado no registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnEliminar_Click(object sender, EventArgs e)
		{
			if (cbxEmpledoElim.Text.Equals(""))
			{
				MessageBox.Show("Hay espacios vacios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			int idCliente, resultado;

			try
			{
				idCliente = Convert.ToInt32(cbxEmpledoElim.SelectedValue);
				resultado = emp.eliminarEmpleado(idCliente);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			if (resultado > 0)
			{
				informacion();
				MessageBox.Show("Empleado eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("Empleado no eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
