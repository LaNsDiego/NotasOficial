using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCsharpNotas.Entidad
{
    class ClsModulo
    {
        private int id;
        private string nombre;
        private int numero;
        private int carrera_id;
        private bool estado;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Numero { get => numero; set => numero = value; }
        public int Carrera_id { get => carrera_id; set => carrera_id = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
