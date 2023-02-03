using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using AppTiendaMascotas.logica;
using AppTiendaMascotas.Ventanas;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AppTiendaMascotas
{
    public partial class Tienda : Form
    {
        public Tienda()
        {
            InitializeComponent();
        }

		private Form fH;
		private Producto producto = new Producto();
		private System.Windows.Forms.DataGridView dataGridBuscar;
		private Boolean bandera = true;

		private void Tienda_Load(object sender, EventArgs e)
		{
			style();
			textoMenu();
			cambiarTexto();
			abrirFormHija(new vtnInicio());
		}

		private void style()
		{
			btnInicio.Region = new System.Drawing.Region(CreateRoundedRectangle(btnInicio.Width, btnInicio.Height));
			btnResidencia.Region = new System.Drawing.Region(CreateRoundedRectangle(btnResidencia.Width, btnResidencia.Height));
			btnCliente.Region = new System.Drawing.Region(CreateRoundedRectangle(btnCliente.Width, btnCliente.Height));
			btnEmplado.Region = new System.Drawing.Region(CreateRoundedRectangle(btnEmplado.Width, btnEmplado.Height));
			btnProducto.Region = new System.Drawing.Region(CreateRoundedRectangle(btnProducto.Width, btnProducto.Height));
			btnMascota.Region = new System.Drawing.Region(CreateRoundedRectangle(btnMascota.Width, btnMascota.Height));
			btnAlojamiento.Region = new System.Drawing.Region(CreateRoundedRectangle(btnAlojamiento.Width, btnAlojamiento.Height));
			btnAtencion.Region = new System.Drawing.Region(CreateRoundedRectangle(btnAtencion.Width, btnAtencion.Height));
			btnVenta.Region = new System.Drawing.Region(CreateRoundedRectangle(btnVenta.Width, btnVenta.Height));
			btnCompra.Region = new System.Drawing.Region(CreateRoundedRectangle(btnCompra.Width, btnCompra.Height));
			btnAcercaDe.Region = new System.Drawing.Region(CreateRoundedRectangle(btnAcercaDe.Width, btnAcercaDe.Height));
			btnModoGerente.Region = new System.Drawing.Region(CreateRoundedRectangle(btnModoGerente.Width, btnModoGerente.Height));
		}

		private void textoMenu()
		{
			DateTime now = DateTime.Now;

			if (now.Hour >= 6 && now.Hour < 12)
			{
				lblHora.Text = "Buenos días " + Environment.MachineName;
			}
			else if (now.Hour >= 12 && now.Hour < 18)
			{
				lblHora.Text = "Buenas tardes " + Environment.MachineName;
			}
			else if (now.Hour >= 18 || now.Hour < 6)
			{
				lblHora.Text = "Buenas noches " + Environment.MachineName;
			}
		}

		private void cambiarTexto()
		{
			var timer = new System.Timers.Timer(TimeSpan.FromMinutes(6000).TotalMinutes);
			timer.Elapsed += Timer1_Elapsed;
			timer.Start();
		}

		private void Timer1_Elapsed(object sender, ElapsedEventArgs e)
		{
			try
			{
				lblHora.Invoke((MethodInvoker)delegate
				{
					DateTime now = DateTime.Now;
					lblHora.Text = now.ToString("dd 'de' MMMM 'del' yyyy");
				});
			}
			catch (Exception)
			{

				throw;
			}
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

		private void txtBuscar_Click(object sender, EventArgs e)
		{
			this.panelCentral.Controls.Clear();
			buscar();
			txtBuscar.Text = "";
			txtBuscar.ForeColor = System.Drawing.Color.White;


		}

		private void txtBuscar_TextChanged(object sender, EventArgs e)
		{
			if (bandera)
			{
				DataSet dsResultado = new DataSet();
				dsResultado = producto.buscar(txtBuscar.Text);
				dataGridBuscar.DataSource = dsResultado;
				dataGridBuscar.DataMember = "ResultadoDatos";
			}
		}

		private void buscar()
		{
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dataGridBuscar = new System.Windows.Forms.DataGridView();
			this.dataGridBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.dataGridBuscar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridBuscar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(29)))));
			this.dataGridBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGridBuscar.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.dataGridBuscar.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(29)))));
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Inter", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3);
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridBuscar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridBuscar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Inter Medium", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridBuscar.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridBuscar.EnableHeadersVisualStyles = false;
			this.dataGridBuscar.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dataGridBuscar.Location = new System.Drawing.Point(pictureBox2.Location.X, 15);
			this.dataGridBuscar.Name = "dataGridBuscar";
			this.dataGridBuscar.ReadOnly = true;
			this.dataGridBuscar.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Inter Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridBuscar.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridBuscar.RowHeadersVisible = false;
			this.dataGridBuscar.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(27)))), ((int)(((byte)(29)))));
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Inter", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
			this.dataGridBuscar.RowsDefaultCellStyle = dataGridViewCellStyle4;
			this.dataGridBuscar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridBuscar.Size = new System.Drawing.Size(696, 528);
			this.dataGridBuscar.TabIndex = 20;
			this.panelCentral.Controls.Add(this.dataGridBuscar);

			DataSet dsResultado = new DataSet();
			dsResultado = producto.buscar(txtBuscar.Text);
			dataGridBuscar.DataSource = dsResultado;
			dataGridBuscar.DataMember = "ResultadoDatos";

			dataGridBuscar.Region = new System.Drawing.Region(CreateRoundedRectangle(dataGridBuscar.Width, dataGridBuscar.Height));
		}

		public void abrirFormHija(object formHija)
		{
			if (this.panelCentral.Controls.Count > 0)
			{
				this.panelCentral.Controls.Clear();
			}
			if (fH != null)
			{
				fH.Dispose();
			}
			fH = formHija as Form;
			fH.TopLevel = false;
			fH.Dock = DockStyle.Fill;
			this.panelCentral.Controls.Add(fH);
			this.panelCentral.Tag = fH;
			fH.Show();
		}

		private void metodoBuscar()
		{
			bandera = false;
			txtBuscar.Text = "Buscar";
			bandera = true;
			txtBuscar.ForeColor = System.Drawing.Color.DarkGray;
		}

		private void btnInicio_Click(object sender, EventArgs e)
		{
			abrirFormHija(new vtnInicio());
			btnInicio.BackColor = Color.FromArgb(25, 25, 25);
			btnAlojamiento.BackColor = Color.FromArgb(46, 48, 51);
			btnAtencion.BackColor = Color.FromArgb(46, 48, 51);
			btnCliente.BackColor = Color.FromArgb(46, 48, 51);
			btnCompra.BackColor = Color.FromArgb(46, 48, 51);
			btnAcercaDe.BackColor = Color.FromArgb(46, 48, 51);
			btnEmplado.BackColor = Color.FromArgb(46, 48, 51);
			btnMascota.BackColor = Color.FromArgb(46, 48, 51);
			btnProducto.BackColor = Color.FromArgb(46, 48, 51);
			btnResidencia.BackColor = Color.FromArgb(46, 48, 51);
			btnModoGerente.BackColor = Color.FromArgb(46, 48, 51);
			btnVenta.BackColor = Color.FromArgb(46, 48, 51);
			btnModoGerente.BackColor = Color.FromArgb(46, 48, 51);
			metodoBuscar();
		}

		private void btnResidencia_Click(object sender, EventArgs e)
		{
			abrirFormHija(new vtnResidencia());
			btnInicio.BackColor = Color.FromArgb(46, 48, 51);
			btnAlojamiento.BackColor = Color.FromArgb(46, 48, 51);
			btnAtencion.BackColor = Color.FromArgb(46, 48, 51);
			btnCliente.BackColor = Color.FromArgb(46, 48, 51);
			btnCompra.BackColor = Color.FromArgb(46, 48, 51);
			btnAcercaDe.BackColor = Color.FromArgb(46, 48, 51);
			btnEmplado.BackColor = Color.FromArgb(46, 48, 51);
			btnMascota.BackColor = Color.FromArgb(46, 48, 51);
			btnProducto.BackColor = Color.FromArgb(46, 48, 51);
			btnVenta.BackColor = Color.FromArgb(46, 48, 51);
			btnModoGerente.BackColor = Color.FromArgb(46, 48, 51);
			btnResidencia.BackColor = Color.FromArgb(25, 25, 25);
			btnModoGerente.BackColor = Color.FromArgb(46, 48, 51);
			metodoBuscar();
		}

		private void btnCliente_Click(object sender, EventArgs e)
		{
			abrirFormHija(new vtnCliente());
			btnInicio.BackColor = Color.FromArgb(46, 48, 51);
			btnAlojamiento.BackColor = Color.FromArgb(46, 48, 51);
			btnAtencion.BackColor = Color.FromArgb(46, 48, 51);
			btnCliente.BackColor = Color.FromArgb(25, 25, 25);
			btnCompra.BackColor = Color.FromArgb(46, 48, 51);
			btnAcercaDe.BackColor = Color.FromArgb(46, 48, 51);
			btnEmplado.BackColor = Color.FromArgb(46, 48, 51);
			btnMascota.BackColor = Color.FromArgb(46, 48, 51);
			btnProducto.BackColor = Color.FromArgb(46, 48, 51);
			btnVenta.BackColor = Color.FromArgb(46, 48, 51);
			btnResidencia.BackColor = Color.FromArgb(46, 48, 51);
			btnModoGerente.BackColor = Color.FromArgb(46, 48, 51);
			metodoBuscar();
		}

		private void btnEmplado_Click(object sender, EventArgs e)
		{	
			abrirFormHija(new vtnEmpleado());
			btnInicio.BackColor = Color.FromArgb(46, 48, 51);
			btnAlojamiento.BackColor = Color.FromArgb(46, 48, 51);
			btnAtencion.BackColor = Color.FromArgb(46, 48, 51);
			btnCliente.BackColor = Color.FromArgb(46, 48, 51);
			btnCompra.BackColor = Color.FromArgb(46, 48, 51);
			btnAcercaDe.BackColor = Color.FromArgb(46, 48, 51);
			btnEmplado.BackColor = Color.FromArgb(25, 25, 25);
			btnMascota.BackColor = Color.FromArgb(46, 48, 51);
			btnProducto.BackColor = Color.FromArgb(46, 48, 51);
			btnVenta.BackColor = Color.FromArgb(46, 48, 51);
			btnResidencia.BackColor = Color.FromArgb(46, 48, 51);
			btnModoGerente.BackColor = Color.FromArgb(46, 48, 51);
			metodoBuscar();
		}

		private void btnProducto_Click(object sender, EventArgs e)
		{
			abrirFormHija(new vtnProducto());
			btnInicio.BackColor = Color.FromArgb(46, 48, 51);
			btnAlojamiento.BackColor = Color.FromArgb(46, 48, 51);
			btnAtencion.BackColor = Color.FromArgb(46, 48, 51);
			btnCliente.BackColor = Color.FromArgb(46, 48, 51);
			btnCompra.BackColor = Color.FromArgb(46, 48, 51);
			btnAcercaDe.BackColor = Color.FromArgb(46, 48, 51);
			btnEmplado.BackColor = Color.FromArgb(46, 48, 51);
			btnMascota.BackColor = Color.FromArgb(46, 48, 51);
			btnProducto.BackColor = Color.FromArgb(25, 25, 25);
			btnVenta.BackColor = Color.FromArgb(46, 48, 51);
			btnResidencia.BackColor = Color.FromArgb(46, 48, 51);
			btnModoGerente.BackColor = Color.FromArgb(46, 48, 51);
			metodoBuscar();
		}

		private void btnMascota_Click(object sender, EventArgs e)
		{
			abrirFormHija(new vtnMascota());
			btnInicio.BackColor = Color.FromArgb(46, 48, 51);
			btnAlojamiento.BackColor = Color.FromArgb(46, 48, 51);
			btnAtencion.BackColor = Color.FromArgb(46, 48, 51);
			btnCliente.BackColor = Color.FromArgb(46, 48, 51);
			btnCompra.BackColor = Color.FromArgb(46, 48, 51);
			btnAcercaDe.BackColor = Color.FromArgb(46, 48, 51);
			btnEmplado.BackColor = Color.FromArgb(46, 48, 51);
			btnMascota.BackColor = Color.FromArgb(25, 25, 25);
			btnProducto.BackColor = Color.FromArgb(46, 48, 51);
			btnVenta.BackColor = Color.FromArgb(46, 48, 51);
			btnModoGerente.BackColor = Color.FromArgb(46, 48, 51);
			btnResidencia.BackColor = Color.FromArgb(46, 48, 51);
			btnModoGerente.BackColor = Color.FromArgb(46, 48, 51);
			metodoBuscar();
		}

		private void btnAlojamiento_Click(object sender, EventArgs e)
		{
			abrirFormHija(new vtnAlojamiento());
			btnInicio.BackColor = Color.FromArgb(46, 48, 51);
			btnAlojamiento.BackColor = Color.FromArgb(25, 25, 25);
			btnAtencion.BackColor = Color.FromArgb(46, 48, 51);
			btnCliente.BackColor = Color.FromArgb(46, 48, 51);
			btnCompra.BackColor = Color.FromArgb(46, 48, 51);
			btnAcercaDe.BackColor = Color.FromArgb(46, 48, 51);
			btnEmplado.BackColor = Color.FromArgb(46, 48, 51);
			btnMascota.BackColor = Color.FromArgb(46, 48, 51);
			btnProducto.BackColor = Color.FromArgb(46, 48, 51);
			btnVenta.BackColor = Color.FromArgb(46, 48, 51);
			btnResidencia.BackColor = Color.FromArgb(46, 48, 51);
			btnModoGerente.BackColor = Color.FromArgb(46, 48, 51);
			metodoBuscar();
		}

		private void btnAtencion_Click(object sender, EventArgs e)
		{
			abrirFormHija(new vtnAtencion());
			btnInicio.BackColor = Color.FromArgb(46, 48, 51);
			btnAlojamiento.BackColor = Color.FromArgb(46, 48, 51);
			btnAtencion.BackColor = Color.FromArgb(25, 25, 25);
			btnCliente.BackColor = Color.FromArgb(46, 48, 51);
			btnCompra.BackColor = Color.FromArgb(46, 48, 51);
			btnAcercaDe.BackColor = Color.FromArgb(46, 48, 51);
			btnEmplado.BackColor = Color.FromArgb(46, 48, 51);
			btnMascota.BackColor = Color.FromArgb(46, 48, 51);
			btnProducto.BackColor = Color.FromArgb(46, 48, 51);
			btnVenta.BackColor = Color.FromArgb(46, 48, 51);
			btnResidencia.BackColor = Color.FromArgb(46, 48, 51);
			btnModoGerente.BackColor = Color.FromArgb(46, 48, 51);
			metodoBuscar();
		}

		private void btnVenta_Click(object sender, EventArgs e)
		{
			abrirFormHija(new vtnVenta());
			btnInicio.BackColor = Color.FromArgb(46, 48, 51);
			btnAlojamiento.BackColor = Color.FromArgb(46, 48, 51);
			btnAtencion.BackColor = Color.FromArgb(46, 48, 51);
			btnCliente.BackColor = Color.FromArgb(46, 48, 51);
			btnCompra.BackColor = Color.FromArgb(46, 48, 51);
			btnAcercaDe.BackColor = Color.FromArgb(46, 48, 51);
			btnEmplado.BackColor = Color.FromArgb(46, 48, 51);
			btnMascota.BackColor = Color.FromArgb(46, 48, 51);
			btnProducto.BackColor = Color.FromArgb(46, 48, 51);
			btnVenta.BackColor = Color.FromArgb(25, 25, 25);
			btnResidencia.BackColor = Color.FromArgb(46, 48, 51);
			btnModoGerente.BackColor = Color.FromArgb(46, 48, 51);
			metodoBuscar();
		}

		private void btnCompra_Click(object sender, EventArgs e)
		{
			abrirFormHija(new vtnCompra());
			btnInicio.BackColor = Color.FromArgb(46, 48, 51);
			btnAlojamiento.BackColor = Color.FromArgb(46, 48, 51);
			btnAtencion.BackColor = Color.FromArgb(46, 48, 51);
			btnCliente.BackColor = Color.FromArgb(46, 48, 51);
			btnCompra.BackColor = Color.FromArgb(25, 25, 25);
			btnAcercaDe.BackColor = Color.FromArgb(46, 48, 51);
			btnEmplado.BackColor = Color.FromArgb(46, 48, 51);
			btnMascota.BackColor = Color.FromArgb(46, 48, 51);
			btnProducto.BackColor = Color.FromArgb(46, 48, 51);
			btnVenta.BackColor = Color.FromArgb(46, 48, 51);
			btnResidencia.BackColor = Color.FromArgb(46, 48, 51);
			btnModoGerente.BackColor = Color.FromArgb(46, 48, 51);
			metodoBuscar();
		}

		private void btnConsultas_Click(object sender, EventArgs e)
		{
			abrirFormHija(new vtnAcercaDe());
			btnInicio.BackColor = Color.FromArgb(46, 48, 51);
			btnAlojamiento.BackColor = Color.FromArgb(46, 48, 51);
			btnAtencion.BackColor = Color.FromArgb(46, 48, 51);
			btnCliente.BackColor = Color.FromArgb(46, 48, 51);
			btnCompra.BackColor = Color.FromArgb(46, 48, 51);
			btnAcercaDe.BackColor = Color.FromArgb(25, 25, 25);
			btnEmplado.BackColor = Color.FromArgb(46, 48, 51);
			btnMascota.BackColor = Color.FromArgb(46, 48, 51);
			btnProducto.BackColor = Color.FromArgb(46, 48, 51);
			btnVenta.BackColor = Color.FromArgb(46, 48, 51);
			btnResidencia.BackColor = Color.FromArgb(46, 48, 51);
			btnModoGerente.BackColor = Color.FromArgb(46, 48, 51);
			metodoBuscar();
		}

        private void btnModoGerente_Click(object sender, EventArgs e)
        {
			abrirFormHija(new vtnGerente());
			btnInicio.BackColor = Color.FromArgb(46, 48, 51);
			btnAlojamiento.BackColor = Color.FromArgb(46, 48, 51);
			btnAtencion.BackColor = Color.FromArgb(46, 48, 51);
			btnCliente.BackColor = Color.FromArgb(46, 48, 51);
			btnCompra.BackColor = Color.FromArgb(46, 48, 51);
			btnAcercaDe.BackColor = Color.FromArgb(46, 48, 51);
			btnEmplado.BackColor = Color.FromArgb(46, 48, 51);
			btnMascota.BackColor = Color.FromArgb(46, 48, 51);
			btnProducto.BackColor = Color.FromArgb(46, 48, 51);
			btnVenta.BackColor = Color.FromArgb(46, 48, 51);
			btnResidencia.BackColor = Color.FromArgb(46, 48, 51);
			btnModoGerente.BackColor = Color.FromArgb(25, 25, 25);
			metodoBuscar();
		}
    }
}
