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
    public partial class FrmCarreras : Form
    {
        ClsNCarrera controlador = new ClsNCarrera();
        public FrmCarreras()
        {
            InitializeComponent();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (ClsNRequerido.AlfabeticoValido(TxtNombre.Text) &&
                controlador.Buscar(Convert.ToInt32(TxtNombre.Text),1)
                )
            {
                Console.WriteLine("Valido Carrera Guardar");
            }
        }
    }
}
