using SistemaCsharpNotas.Entidad;
using SistemaCsharpNotas.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCsharpNotas.Presentacion
{
    public partial class FrmUsuario : Form
    {
        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            BtnGuardar.Enabled = false;
            Niveles();
            Listar();
        }
        private void Niveles()
        {
            Dictionary<int, string> Niveles = new Dictionary<int, string>()
            {
                { 1, "Administrador" },
                { 2, "Docente" },
                { 3, "Estudiante" }
            };
            CmbNivel.DataSource = new BindingSource(Niveles, null);
            CmbNivel.DisplayMember = "Value";
            CmbNivel.ValueMember = "Key";
        }
        private void Listar()
        {
            DgvUsuario.Rows.Clear();
            ClsNUsuario bo = new ClsNUsuario();
            foreach(ClsUsuario rows in bo.Listar())
            {
                string[] row = new string[] { rows.Codigo, rows.Clave, Nivel(rows.Nivel), rows.Estado == true ? "Activo" : "Inactivo"  };
                DgvUsuario.Rows.Add(row);
            }
        }
        private string Nivel(int level)
        {
            string nivel;
            switch (level)
            {
                case 1: nivel = "Administrador"; break;
                case 2: nivel = "Docente"; break;
                case 3: nivel = "Estudiante"; break;
                default: nivel = ""; break;
            };
            return nivel;
        }
        private int Level(string nivel)
        {
            int level;
            switch (nivel)
            {
                case "Administrador": level = 1; break;
                case "Docente": level = 2; break;
                case "Estudiante": level = 3; break;
                default: level = 1; break;
            };
            return level;
        }
        private void Limpiar()
        {
            TxtCodigo.Text = "";
            TxtClave.Text = "";
            CmbNivel.SelectedValue = 1;
            RdbActivo.Checked = true;
            RdbInactivo.Checked = false;
            TxtCodigo.Focus();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if(TxtCodigo.Text != "" && TxtClave.Text != "")
            {
                ClsUsuario be = new ClsUsuario()
                {
                    Id = 1,
                    Codigo = TxtCodigo.Text,
                    Clave = TxtClave.Text,
                    Nivel = Convert.ToInt32(CmbNivel.SelectedValue),
                    Estado = RdbActivo.Checked ? true : false
                };
                ClsNUsuario bo = new ClsNUsuario();
                bo.Agregar(be);
                Listar();
                BtnGuardar.Enabled = false;
            }
            else
            {
                MessageBox.Show("Los campos no pueden estar vacios");
            }
        }

        private void DgvUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvUsuario.SelectedRows.Count > 0)
            {
                if(DgvUsuario.CurrentRow.Index != -1)
                {
                    try
                    {
                        TxtCodigo.Text = DgvUsuario.CurrentRow.Cells[0].Value.ToString();
                        TxtClave.Text = DgvUsuario.CurrentRow.Cells[1].Value.ToString();
                        CmbNivel.SelectedValue = Level(DgvUsuario.CurrentRow.Cells[2].Value.ToString());
                        if (DgvUsuario.CurrentRow.Cells[3].Value.ToString() == "Activo")
                        {
                            
                            RdbActivo.Checked = true;
                        }
                        else
                        {
                            RdbInactivo.Checked = true;
                        }
                        MessageBox.Show(DgvUsuario.CurrentRow.Cells[0].Value.ToString());
                    }
                    catch
                    {
                        //message
                    }
                }
            }
            else
            {
                //MessageBox.Show("Seleccione un registro");
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            BtnGuardar.Enabled = true;
            Limpiar();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (DgvUsuario.SelectedRows.Count > 0)
            {
                if (DgvUsuario.CurrentRow.Index != -1)
                {
                    try
                    {
                        ClsUsuario be = new ClsUsuario()
                        {
                            Codigo = TxtCodigo.Text,
                            Clave = TxtClave.Text,
                            Nivel = Convert.ToInt32(CmbNivel.SelectedValue),
                            Estado = RdbActivo.Checked ? true : false
                        };
                        ClsNUsuario bo = new ClsNUsuario();
                        bo.Modificar(be);
                        Listar();
                    }
                    catch
                    {
                        //
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }
    }
}
