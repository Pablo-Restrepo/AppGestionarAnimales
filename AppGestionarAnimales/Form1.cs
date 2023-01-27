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

namespace AppGestionarAnimales
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //crear objeto de la clase animal:
        Residencia res = new Residencia();
        Cliente cli = new Cliente();
        Atiende atiende = new Atiende();
        Aloja aloja = new Aloja();
        Empleado emp = new Empleado();
        HaceCompra comp = new HaceCompra();
        Producto prod = new Producto();
        Mascota ani = new Mascota();
        Venta venta = new Venta();


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //paso 1: capturo en variables lo que el usuario escribio o selecciono de la interfaz
            int codigo, resultado;
            string nombre, genero;

            codigo = int.Parse(txtCodigo.Text);
            nombre = txtNombre.Text;
            genero = cbxGenero.Text;
            //paso 2: envio las variables a la capa de la logica
            resultado = ani.ingresarMascota(codigo,nombre,genero);
            if (resultado>0) 
            {
                MessageBox.Show("Animal registrado", "Mensaje", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else 
            {
                MessageBox.Show("Animal no registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
