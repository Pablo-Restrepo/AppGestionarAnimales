﻿using System;
using System.Windows.Forms;

namespace AppTiendaMascotas.Ventanas
{
    public partial class vtnAcercaDe : Form
    {
        public vtnAcercaDe()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/Pablo736/AppGestionarAnimales");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error. " + ex);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/SebastianTuquerrezG");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error. " + ex);
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/Jojan-Esteban-Serna");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error. " + ex);
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/Pablo736");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error. " + ex);
            }
        }
    }
}