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
	public partial class vtnAlojamiento : Form
	{
		public vtnAlojamiento()
		{
			InitializeComponent();
			style();
			informacion();
		}

		private Boolean bandera = true;
		private Boolean bandera2 = false;
		private Aloja aloja = new Aloja();
		private Mascota ani = new Mascota();
		private Residencia resi = new Residencia();

		private void informacion()
		{
			cbxAlojamientoDelete.DataSource = aloja.consultarAlojamientoIDs();
			cbxAlojamientoDelete.DisplayMember = "IDALOJA";
			cbxAlojamientoDelete.ValueMember = "IDALOJA";

			cbxResidencia.DataSource = resi.consultarResidenciaIDs();
			cbxResidencia.DisplayMember = "IDRESIDENCIA";
			cbxResidencia.ValueMember = "IDRESIDENCIA";

			cbxMascota.DataSource = ani.consultarMascotaIDs();
			cbxMascota.DisplayMember = "NOMBREMASCOTA"; 
			cbxMascota.ValueMember = "IDMASCOTA";

			DataSet dsResultado = new DataSet();
			dsResultado = aloja.consultarAlojamiento();
			dgvConsultaAlojamiento.DataSource = dsResultado;
			dgvConsultaAlojamiento.DataMember = "ResultadoDatos";
		}

		private void style()
		{
			dgvConsultaAlojamiento.Region = new System.Drawing.Region(CreateRoundedRectangle(dgvConsultaAlojamiento.Width, dgvConsultaAlojamiento.Height));

			cbxResidencia.Anchor = AnchorStyles.Top;
			cbxMascota.Anchor = AnchorStyles.Top;
			cbxAlojamientoDelete.Anchor = AnchorStyles.Top;
			btnEliminarAlojamiento.Anchor = AnchorStyles.Top;
			btnGuardarAlojamiento.Anchor = AnchorStyles.Top;
			dgvConsultaAlojamiento.Anchor = AnchorStyles.Top;
			timeFechaInicioAloj.Anchor = AnchorStyles.Top;
			label1.Anchor = AnchorStyles.Top;
			label2.Anchor = AnchorStyles.Top;
			label3.Anchor = AnchorStyles.Top;
			label4.Anchor = AnchorStyles.Top;
			label5.Anchor = AnchorStyles.Top;
			label6.Anchor = AnchorStyles.Top;
			label7.Anchor = AnchorStyles.Top;
			label8.Anchor = AnchorStyles.Top;
			timeFechaFinAloj.Anchor = AnchorStyles.Top;
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
				dgvConsultaAlojamiento.Location = new Point(dgvConsultaAlojamiento.Location.X + 1, dgvConsultaAlojamiento.Location.Y);
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
				dgvConsultaAlojamiento.Location = new Point(dgvConsultaAlojamiento.Location.X - 2, dgvConsultaAlojamiento.Location.Y);
			}
		}

		private void vtnResidencia_Resize(object sender, EventArgs e)
		{
			scrollBar();
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			if (cbxResidencia.Text.Equals("") || cbxMascota.Text.Equals("") || timeFechaInicioAloj.Text.Equals("") || timeFechaFinAloj.Text.Equals(""))
			{
				MessageBox.Show("Hay espacios vacios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			int idResidencia, idMascota, resultado;
			DateTime fechaInicio = timeFechaInicioAloj.Value;
			DateTime fechaFin = timeFechaFinAloj.Value;

			try
			{
				string fechaInicioAlojamiento, fechaFinAlojamiento;
				fechaInicioAlojamiento = fechaInicio.ToString("dd'/'MM'/'yyyy HH:mm:ss");
				fechaFinAlojamiento = fechaFin.ToString("dd'/'MM'/'yyyy HH:mm:ss");
				idResidencia = Convert.ToInt32(cbxResidencia.SelectedValue);
				idMascota = Convert.ToInt32(cbxMascota.SelectedValue);
				resultado = aloja.ingresarAlojamiento(idResidencia, idMascota, fechaInicioAlojamiento, fechaFinAlojamiento);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (resultado > 0)
			{
				informacion();
				MessageBox.Show("Alojamiento registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("Alojamiento no registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnEliminar_Click(object sender, EventArgs e)
		{
			if (cbxAlojamientoDelete.Text.Equals(""))
			{
				MessageBox.Show("Hay espacios vacios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			int idAlojamiento, resultado;

			try
			{
				idAlojamiento = int.Parse(cbxAlojamientoDelete.Text);
				resultado = aloja.eliminarAlojamiento(idAlojamiento);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (resultado > 0)
			{
				informacion();
				MessageBox.Show("Alojamiento eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("Alojamiento no eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
