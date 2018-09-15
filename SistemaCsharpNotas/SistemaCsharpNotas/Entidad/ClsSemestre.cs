using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCsharpNotas.Entidad
{
    class ClsSemestre
    {
        private int id;
        private string nombre;
        private bool estado;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
