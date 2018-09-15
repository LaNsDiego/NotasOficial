using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCsharpNotas.Entidad
{
    class ClsUsuario
    {
        private int id;
        private string codigo;
        private string clave;
        private int nivel;
        private bool estado;

        public int Id { get => id; set => id = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Clave { get => clave; set => clave = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
