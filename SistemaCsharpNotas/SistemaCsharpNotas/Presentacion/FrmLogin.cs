using SistemaCsharpNotas.Entidad;
using SistemaCsharpNotas.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCsharpNotas.Presentacion
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool acceso;
            ClsNUsuario obj = new ClsNUsuario();
            acceso = obj.Login(TxtUsuario.Text, TxtContraseña.Text);
            if (acceso == true)
            {
                FrmPrincipal frm = new FrmPrincipal();
                this.Hide();
                frm.Visible = true;
                frm.Show();
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrecto");
            }
        }
    }
}
