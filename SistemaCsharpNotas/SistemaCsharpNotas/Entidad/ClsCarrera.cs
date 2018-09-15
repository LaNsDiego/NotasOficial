using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCsharpNotas.Entidad
{
    class ClsCarrera
    {
        private int id;
        private string nombre;
        private string sigla;
        private int turno;
        private bool estado;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Sigla { get => sigla; set => sigla = value; }
        public int Turno { get => turno; set => turno = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
