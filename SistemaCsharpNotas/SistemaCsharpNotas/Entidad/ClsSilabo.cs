using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCsharpNotas.Entidad
{
    class ClsSilabo
    {
        private int id;
        private string anio;
        private string turno;
        private int unidad_id;
        private int docente_id;
        private bool estado;

        public int Id { get => id; set => id = value; }
        public string Anio { get => anio; set => anio = value; }
        public string Turno { get => turno; set => turno = value; }
        public int Unidad_id { get => unidad_id; set => unidad_id = value; }
        public int Docente_id { get => docente_id; set => docente_id = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
