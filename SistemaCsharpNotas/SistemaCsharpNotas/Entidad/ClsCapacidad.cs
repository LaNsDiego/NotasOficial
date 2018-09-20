using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCsharpNotas.Entidad
{
    class ClsCapacidad
    {
        private int id;
        private int nota_id;
        private int numero;
        private string nombre;
        private double calificacion;
        private bool estado;

        public int Id { get => id; set => id = value; }
        public int NotaId { get => nota_id; set => nota_id = value; }
        public int Numero { get => numero; set => numero = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public double Calificacion { get => calificacion; set => calificacion = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
