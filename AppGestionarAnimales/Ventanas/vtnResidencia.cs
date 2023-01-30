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
	public partial class vtnResidencia : Form
	{
		public vtnResidencia()
		{
			InitializeComponent();
			style();
			informacion();
		}

		private Boolean bandera = true;
		private Boolean bandera2 = false;
		private Residencia res = new Residencia();

		private void informacion()
		{
			cbxResElimi.DataSource = res.consultarResidenciaIDs();
			cbxResElimi.DisplayMember = "IDRESIDENCIA";
			cbxResElimi.ValueMember = "IDRESIDENCIA";

			DataSet dsResultado = new DataSet();
			dsResultado = res.consultarResidencia();
			dataGridResidencias.DataSource = dsResultado;
			dataGridResidencias.DataMember = "ResultadoDatos";
		}

		private void style()
		{
			dataGridResidencias.Region = new System.Drawing.Region(CreateRoundedRectangle(dataGridResidencias.Width, dataGridResidencias.Height));

			txtNumResidencia.Anchor = AnchorStyles.Top;
			txtNumResidentes.Anchor = AnchorStyles.Top;
			cbxResElimi.Anchor = AnchorStyles.Top;
			cbxTipoR.Anchor = AnchorStyles.Top;
			btnEliminar.Anchor = AnchorStyles.Top;
			btnGuardar.Anchor = AnchorStyles.Top;
			dataGridResidencias.Anchor = AnchorStyles.Top;
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
				dataGridResidencias.Location = new Point(dataGridResidencias.Location.X + 1, dataGridResidencias.Location.Y);
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
				dataGridResidencias.Location = new Point(dataGridResidencias.Location.X - 2, dataGridResidencias.Location.Y);
			}
		}

		private void vtnResidencia_Resize(object sender, EventArgs e)
		{
			scrollBar();
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			int idResidencia, numResidentes, resultado;
			string tipoResidencia;

			idResidencia = int.Parse(txtNumResidencia.Text);
			numResidentes = int.Parse(txtNumResidentes.Text);
			tipoResidencia = cbxTipoR.Text;
			resultado = res.ingresarResidencia(idResidencia, numResidentes, tipoResidencia);
			if (resultado > 0)
			{
				MessageBox.Show("Residencia registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("Residencia no registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnEliminar_Click(object sender, EventArgs e)
		{
			int numResidencia, resultado;

			numResidencia = int.Parse(cbxResElimi.Text);
			resultado = res.eliminarResidencia(numResidencia);
			if (resultado > 0)
			{
				MessageBox.Show("Residencia eliminada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("Residencia no eliminada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
