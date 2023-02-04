using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppTiendaMascotas.logica;

namespace AppTiendaMascotas.Ventanas
{
    public partial class vtnGerente : Form

    {
        Gerente gerente = new Gerente();
        public vtnGerente()
        {
            InitializeComponent();
        }

        private void btnConsultarIngXEmpleado_Click(object sender, EventArgs e)
        {
            long codEmpleado = long.Parse(txtCedulaCliente.Text);
            this.lblResultadoPrimerFuncion.Text = gerente.ConsultarIngXEmpleado(codEmpleado,timeFechaInicioPrimerFuncion.Value, timeFechaFinPrimerFuncion.Value).ToString();
        }

        private void btnConsultarAlojXResidencia_Click(object sender, EventArgs e)
        {

        }

        private void btnConsultarEmpleadosIngresados_Click(object sender, EventArgs e)
        {
            DataSet dsResultado = new DataSet();
            dsResultado = gerente.ConsultarListarEmpleados(timeFechaInicioTercerProcedimiento.Value, timeFechaFinTercerProcedimiento.Value);
            dgvEmpleadosIngresados.DataSource = dsResultado;
            dgvEmpleadosIngresados.DataMember = "ResultadoDatos";
        }
    }
}
