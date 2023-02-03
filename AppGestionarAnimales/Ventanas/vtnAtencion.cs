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
	public partial class vtnAtencion : Form
	{
		public vtnAtencion()
		{
			InitializeComponent();
			style();
			informacion();
		}

		private Boolean bandera = true;
		private Boolean bandera2 = false;
		private Empleado emp = new Empleado();
		private Mascota ani = new Mascota();
		private Atiende atie = new Atiende();

		private void informacion()
		{
			cbxEmpleado.DataSource = emp.consultarEmpleadoIDs();
			cbxEmpleado.DisplayMember = "NOMBREEMPLEADO";
			cbxEmpleado.ValueMember = "CODEMPLEADO";

			cbxMascota.DataSource = ani.consultarMascotaIDs();
			cbxMascota.DisplayMember = "NOMBREMASCOTA";
			cbxMascota.ValueMember = "IDMASCOTA";

			cbxAtencionElimi.DataSource = atie.consultarAtencionesIDs();
			cbxAtencionElimi.DisplayMember = "IDATENCION";
			cbxAtencionElimi.ValueMember = "IDATENCION";

			DataSet dsResultado = new DataSet();
			dsResultado = atie.consultarAtenciones();
			dgvConsultaAtencion.DataSource = dsResultado;
			dgvConsultaAtencion.DataMember = "ResultadoDatos";
		}

		private void style()
		{
			dgvConsultaAtencion.Region = new System.Drawing.Region(CreateRoundedRectangle(dgvConsultaAtencion.Width, dgvConsultaAtencion.Height));

			txtDescAtencion.Anchor = AnchorStyles.Top;
			cbxAtencionElimi.Anchor = AnchorStyles.Top;
			cbxTipoAtencion.Anchor = AnchorStyles.Top;
			cbxEmpleado.Anchor = AnchorStyles.Top;
			cbxMascota.Anchor = AnchorStyles.Top;
			btnEliminar.Anchor = AnchorStyles.Top;
			btnGuardar.Anchor = AnchorStyles.Top;
			dgvConsultaAtencion.Anchor = AnchorStyles.Top;
			pictureBox3.Anchor = AnchorStyles.Top;
			pictureBox5.Anchor = AnchorStyles.Top;
			txtCostoAtencion.Anchor = AnchorStyles.Top;
			timeFechaAtencion.Anchor = AnchorStyles.Top;
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
				dgvConsultaAtencion.Location = new Point(dgvConsultaAtencion.Location.X + 1, dgvConsultaAtencion.Location.Y);
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
				dgvConsultaAtencion.Location = new Point(dgvConsultaAtencion.Location.X - 2, dgvConsultaAtencion.Location.Y);
			}
		}

		private void vtnResidencia_Resize(object sender, EventArgs e)
		{
			scrollBar();
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			if (cbxEmpleado.Text.Equals("") || cbxMascota.Text.Equals("") || cbxTipoAtencion.Text.Equals("") || txtDescAtencion.Text.Equals(""))
			{
				MessageBox.Show("Hay espacios vacios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			int codEmpleado, idMascota, costoAtencion, resultado;
			string tipoAtencion, descripcion;

			try
			{
				codEmpleado = Convert.ToInt32(cbxEmpleado.SelectedValue);
				idMascota = Convert.ToInt32(cbxMascota.SelectedValue);
				costoAtencion = int.Parse(txtCostoAtencion.Text);
				tipoAtencion = cbxTipoAtencion.Text;
				descripcion = txtDescAtencion.Text;
				resultado = atie.ingresarAtencion(codEmpleado, idMascota, tipoAtencion, descripcion, costoAtencion);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			if (resultado > 0)
			{
				informacion();
				MessageBox.Show("Atencion registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtCostoAtencion.Text = "";
				txtDescAtencion.Text = "";
			}
			else
			{
				MessageBox.Show("Atencion no registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnEliminar_Click(object sender, EventArgs e)
		{
			if (cbxAtencionElimi.Text.Equals(""))
			{
				MessageBox.Show("Hay espacios vacios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			int idAtencion, resultado;

			try
			{
				idAtencion = Convert.ToInt32(cbxAtencionElimi.SelectedValue);
				resultado = atie.eliminarAtencion(idAtencion);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (resultado > 0)
			{
				informacion();
				MessageBox.Show("Atencion eliminada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("Atencion no eliminada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
