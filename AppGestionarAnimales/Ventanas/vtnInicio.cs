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
	public partial class vtnInicio : Form
	{
		public vtnInicio()
		{
			InitializeComponent();
			style();
			informacion();
		}

		private Venta venta = new Venta();
		private Mascota mascota = new Mascota();
		private Producto producto = new Producto();
		private Cliente cliente = new Cliente();
		private Aloja aloja = new Aloja();
		private Boolean bandera = true;
		private Boolean bandera2 = false;

		private void informacion()
		{
			DataSet dsResultado = new DataSet();
			dsResultado = venta.consultarVentasMenu();
			dataGridVentas.DataSource = dsResultado;
			dataGridVentas.DataMember = "ResultadoDatos";

			dsResultado = mascota.consultarMascotasMenu();
			dataGridMascotas.DataSource = dsResultado;
			dataGridMascotas.DataMember = "ResultadoDatos";

			dsResultado = producto.consultarProductoMenu();
			dataGridProductos.DataSource = dsResultado;
			dataGridProductos.DataMember = "ResultadoDatos";

			dsResultado = cliente.consultarClienteMenu();
			dataGridClientes.DataSource = dsResultado;
			dataGridClientes.DataMember = "ResultadoDatos";

			dsResultado = venta.consultarVentaTotal();
			lblVentas.Text = "$" + dsResultado.Tables["ResultadoDatos"].Rows[0]["SUM(VALORVENTA)"].ToString();

			dsResultado = aloja.consultarNumAlojamiento();
			lblMascotasAloj.Text = dsResultado.Tables["ResultadoDatos"].Rows[0]["COUNT(IDALOJA)"].ToString();
		}

		private void style()
		{
			lblVentas.Parent = pbPrincipal;
			lblMascotasAloj.Parent = pbPrincipal;
			dataGridVentas.Region = new System.Drawing.Region(CreateRoundedRectangle(dataGridVentas.Width, dataGridVentas.Height));
			dataGridClientes.Region = new System.Drawing.Region(CreateRoundedRectangle(dataGridClientes.Width, dataGridClientes.Height));
			dataGridMascotas.Region = new System.Drawing.Region(CreateRoundedRectangle(dataGridMascotas.Width, dataGridMascotas.Height));
			dataGridProductos.Region = new System.Drawing.Region(CreateRoundedRectangle(dataGridProductos.Width, dataGridProductos.Height));

			pbPrincipal.Anchor = AnchorStyles.Top;
			lblVentas.Anchor = AnchorStyles.Top;
			lblMascotasAloj.Anchor = AnchorStyles.Top;
			dataGridVentas.Anchor = AnchorStyles.Top;
			dataGridClientes.Anchor = AnchorStyles.Top;
			dataGridMascotas.Anchor = AnchorStyles.Top;
			dataGridProductos.Anchor = AnchorStyles.Top;
			label1.Anchor = AnchorStyles.Top;
			label2.Anchor = AnchorStyles.Top;
			label3.Anchor = AnchorStyles.Top;
			label4.Anchor = AnchorStyles.Top;
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
				pbPrincipal.Location = new Point(pbPrincipal.Location.X + 1, pbPrincipal.Location.Y);
				lblVentas.Location = new Point(lblVentas.Location.X + 1, lblVentas.Location.Y);
				lblMascotasAloj.Location = new Point(lblMascotasAloj.Location.X + 1, lblMascotasAloj.Location.Y);
				label1.Location = new Point(label1.Location.X + 1, label1.Location.Y);
				label2.Location = new Point(label2.Location.X + 1, label2.Location.Y);
				label3.Location = new Point(label3.Location.X + 1, label3.Location.Y);
				label4.Location = new Point(label4.Location.X + 1, label4.Location.Y);
				dataGridVentas.Location = new Point(dataGridVentas.Location.X + 1, dataGridVentas.Location.Y);
				dataGridMascotas.Location = new Point(dataGridMascotas.Location.X + 1, dataGridMascotas.Location.Y);
				dataGridClientes.Location = new Point(dataGridClientes.Location.X + 1, dataGridClientes.Location.Y);
				dataGridProductos.Location = new Point(dataGridProductos.Location.X + 1, dataGridProductos.Location.Y);
			}
			else if (!this.VerticalScroll.Visible && bandera2)
			{
				bandera = true;
				bandera2 = false;
				pbPrincipal.Location = new Point(pbPrincipal.Location.X - 2, pbPrincipal.Location.Y);
				lblVentas.Location = new Point(lblVentas.Location.X - 2, lblVentas.Location.Y);
				lblMascotasAloj.Location = new Point(lblMascotasAloj.Location.X - 2, lblMascotasAloj.Location.Y);
				label1.Location = new Point(label1.Location.X - 2, label1.Location.Y);
				label2.Location = new Point(label2.Location.X - 2, label2.Location.Y);
				label3.Location = new Point(label3.Location.X - 2, label3.Location.Y);
				label4.Location = new Point(label4.Location.X - 2, label4.Location.Y);
				dataGridVentas.Location = new Point(dataGridVentas.Location.X - 2, dataGridVentas.Location.Y);
				dataGridMascotas.Location = new Point(dataGridMascotas.Location.X - 2, dataGridMascotas.Location.Y);
				dataGridClientes.Location = new Point(dataGridClientes.Location.X - 2, dataGridClientes.Location.Y);
				dataGridProductos.Location = new Point(dataGridProductos.Location.X - 2, dataGridProductos.Location.Y);
			}
		}

		private void vtnInicio_Resize(object sender, EventArgs e)
		{
			scrollBar();
		}
	}
}
