using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCsharpNotas.Entidad
{
    class ClsUnidad
    {
        private int id;
        private string nombre;
        private string codigo;
        private int modulo_id;
        private bool estado;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public int Modulo_id { get => modulo_id; set => modulo_id = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
