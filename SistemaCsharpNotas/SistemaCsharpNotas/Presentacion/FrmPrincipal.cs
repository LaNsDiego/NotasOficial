﻿using SistemaCsharpNotas.Negocio;
using SistemaCsharpNotas.Presentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCsharpNotas
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();            
        }

        private void AbrirFormHijo(object frmHijo)
        {
            PnlContenedor.Controls.Clear();
            Form frm = frmHijo as Form;
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            if(PnlContenedor.Controls.Count > 0){ PnlContenedor.Controls.RemoveAt(0); }
            PnlContenedor.Controls.Add(frm);
            frm.Show();
        }

        private void BtnEstudiante_Click(object sender, EventArgs e)
        {
            FrmEstudiante frm = new FrmEstudiante();
            AbrirFormHijo(frm);
        }

        private void BtnNotas_Click(object sender, EventArgs e)
        {

            
        }

        private void BtnDocente_Click(object sender, EventArgs e)
        {
            FrmDocente frm = new FrmDocente();
            AbrirFormHijo(frm);
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            
        }

        private void BtnUsuarios_Click(object sender, EventArgs e)
        {
            FrmUsuario frm = new FrmUsuario();
            AbrirFormHijo(frm);
        }
    }
}
