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
        public vtnGerente()
        {
            InitializeComponent();
        }

        private void btnConsultarIngXEmpleado_Click(object sender, EventArgs e)
        {
            
        }

        private void btnConsultarAlojXResidencia_Click(object sender, EventArgs e)
        {

        }

        private void btnConsultarEmpleadosIngresados_Click(object sender, EventArgs e)
        {
            DataSet dsResultado = new DataSet();
            dsResultado = aloja.consultarAlojamiento();
            dgvConsultaAlojamiento.DataSource = dsResultado;
            dgvConsultaAlojamiento.DataMember = "ResultadoDatos";
        }
    }
}
