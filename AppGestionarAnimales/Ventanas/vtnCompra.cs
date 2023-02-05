using AppTiendaMascotas.logica;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AppTiendaMascotas.Ventanas
{
    public partial class vtnCompra : Form
    {
        public vtnCompra()
        {
            InitializeComponent();
            style();
            informacion();
        }

        private Boolean bandera = true;
        private Boolean bandera2 = false;
        private HaceCompra comp = new HaceCompra();
        private Venta ven = new Venta();
        private Cliente cli = new Cliente();

        private void informacion()
        {
            cbxVenta.DataSource = ven.consultarVentaIDs();
            cbxVenta.DisplayMember = "IDVENTA";
            cbxVenta.ValueMember = "IDVENTA";

            cbxCliente.DataSource = cli.consultarClienteIDs();
            cbxCliente.DisplayMember = "NOMBREDUENIO";
            cbxCliente.ValueMember = "CEDULADUENIO";

            DataSet dsResultado = new DataSet();
            dsResultado = comp.consultarCompras();
            dgvCompras.DataSource = dsResultado;
            dgvCompras.DataMember = "ResultadoDatos";
        }

        private void style()
        {
            dgvCompras.Region = new System.Drawing.Region(CreateRoundedRectangle(dgvCompras.Width, dgvCompras.Height));
            btnGuardar.Anchor = AnchorStyles.Top;
            dgvCompras.Anchor = AnchorStyles.Top;
            label1.Anchor = AnchorStyles.Top;
            label3.Anchor = AnchorStyles.Top;
            label4.Anchor = AnchorStyles.Top;
            label7.Anchor = AnchorStyles.Top;
            cbxVenta.Anchor = AnchorStyles.Top;
            cbxCliente.Anchor = AnchorStyles.Top;
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
                label3.Location = new Point(label3.Location.X + 1, label3.Location.Y);
                label4.Location = new Point(label4.Location.X + 1, label4.Location.Y);
                label7.Location = new Point(label7.Location.X + 1, label7.Location.Y);
                dgvCompras.Location = new Point(dgvCompras.Location.X + 1, dgvCompras.Location.Y);
            }
            else if (!this.VerticalScroll.Visible && bandera2)
            {
                bandera = true;
                bandera2 = false;
                label1.Location = new Point(label1.Location.X - 2, label1.Location.Y);
                label3.Location = new Point(label3.Location.X - 2, label3.Location.Y);
                label4.Location = new Point(label4.Location.X - 2, label4.Location.Y);
                label7.Location = new Point(label7.Location.X - 2, label7.Location.Y);
                dgvCompras.Location = new Point(dgvCompras.Location.X - 2, dgvCompras.Location.Y);
            }
        }

        private void vtnResidencia_Resize(object sender, EventArgs e)
        {
            scrollBar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cbxVenta.Text.Equals("") || cbxCliente.Text.Equals(""))
            {
                MessageBox.Show("Hay espacios vacios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int codVenta, codCliente, resultado;

            try
            {
                codVenta = Convert.ToInt32(cbxVenta.SelectedValue);
                codCliente = Convert.ToInt32(cbxCliente.SelectedValue);
                resultado = comp.ingresarCompra(codCliente, codVenta);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (resultado > 0)
            {
                informacion();
                MessageBox.Show("Compra registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Compra no registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}