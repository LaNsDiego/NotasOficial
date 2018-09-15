using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCsharpNotas.Entidad
{
    class ClsNota
    {
        private int id;
        private int estudiante_id;
        private int silabo_id;
        private double calificacion;
        private bool estado;

        public int Id { get => id; set => id = value; }
        public int Estudiante_id { get => estudiante_id; set => estudiante_id = value; }
        public int Silabo_id { get => silabo_id; set => silabo_id = value; }
        public double Calificacion { get => calificacion; set => calificacion = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
