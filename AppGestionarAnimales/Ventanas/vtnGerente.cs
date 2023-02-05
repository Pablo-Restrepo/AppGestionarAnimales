using AppTiendaMascotas.logica;
using System;
using System.Data;
using System.Windows.Forms;

namespace AppTiendaMascotas.Ventanas
{
    public partial class vtnGerente : Form

    {
        private Gerente gerente = new Gerente();

        public vtnGerente()
        {
            InitializeComponent();
            style();
        }

        private void btnConsultarIngXEmpleado_Click(object sender, EventArgs e)
        {
            int codEmpleado = int.Parse(txtCedulaCliente.Text);
            this.lblResultadoPrimerFuncion.Text = gerente.ConsultarIngXEmpleado(codEmpleado, timeFechaInicioPrimerFuncion.Value, timeFechaFinPrimerFuncion.Value).ToString();
        }

        private void btnConsultarAlojXResidencia_Click(object sender, EventArgs e)
        {
            DataSet dsResultado = new DataSet();
            dsResultado = gerente.ConsultarResidenciasXAlojamiento(cbxTipoResidencia.Text);
            dgvConsultaProcedimiento2.DataSource = dsResultado;
            dgvConsultaProcedimiento2.DataMember = "ResultadoDatos";
        }

        private void btnConsultarEmpleadosIngresados_Click(object sender, EventArgs e)
        {
            DataSet dsResultado = new DataSet();
            dsResultado = gerente.ConsultarListarEmpleados(timeFechaInicioTercerProcedimiento.Value, timeFechaFinTercerProcedimiento.Value);
            dgvEmpleadosIngresados.DataSource = dsResultado;
            dgvEmpleadosIngresados.DataMember = "ResultadoDatos";
        }

        private void style()
        {
            dgvConsultaProcedimiento2.Region = new System.Drawing.Region(CreateRoundedRectangle(dgvConsultaProcedimiento2.Width, dgvConsultaProcedimiento2.Height));

            dgvEmpleadosIngresados.Region = new System.Drawing.Region(CreateRoundedRectangle(dgvEmpleadosIngresados.Width, dgvEmpleadosIngresados.Height));
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
    }
}