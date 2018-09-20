using SistemaCsharpNotas.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCsharpNotas.Entidad
{
    class ClsIndicador
    {
        public int Id;
        public int CriterioId;
        public double Calificacion;

        public ClsIndicador(int Criterio)
        {
            Id = ClsNIndicador.ObtenerId();
            CriterioId = Criterio;
            Calificacion = 0;
        }

        public ClsIndicador()
        {

        }
    }
}
