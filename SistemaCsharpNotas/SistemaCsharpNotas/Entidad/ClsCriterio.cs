using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCsharpNotas.Entidad
{
    class ClsCriterio
    {
        private int id;
        private int capacidad_id;
        private string nombre;
        private string descripcion;
        private double calificacion;
        private bool estado;

        public int Id { get => id; set => id = value; }
        public int Capacidad_id { get => capacidad_id; set => capacidad_id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public double Calificacion { get => calificacion; set => calificacion = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
