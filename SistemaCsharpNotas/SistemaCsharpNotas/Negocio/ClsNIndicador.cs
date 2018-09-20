using SistemaCsharpNotas.Entidad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCsharpNotas.Negocio
{
    class ClsNIndicador
    {
        public bool Agregar(ClsIndicador indicador)
        {
            string fila = indicador.Id.ToString() + " , " + indicador.CriterioId + " , " + indicador.Calificacion;

            ClsNFichero.Agregar(fila, "indicadores.txt");
            return true;
        }

        public static ClsIndicador Parse(string linea)
        {

            string[] campos = new string[3];

            campos = linea.Split(',');
            ClsIndicador indicador = new ClsIndicador();
            indicador.Id = Convert.ToInt32(campos[0]);
            indicador.CriterioId = Convert.ToInt32(campos[1]);
            indicador.Calificacion = Convert.ToDouble(campos[2]);

            return indicador;


        }
        public ArrayList Listar()
        {
            ArrayList Lista = new ArrayList();
            string[] filas = ClsNFichero.Leer("indicadores.txt");
            for (int i = 0; i < filas.Length; i++)
            {
                ClsIndicador indicador = ClsNIndicador.Parse(filas[i]);
                Lista.Add(indicador);
            }
            return Lista;
        }

        public bool Modificar(ClsIndicador indicador)
        {
            string nuevoregistro = indicador.Id.ToString() + " , " + indicador.CriterioId + " , " + indicador.Calificacion;
            return ClsNFichero.Editar(indicador.Id.ToString(), nuevoregistro, "indicadores.txt");

        }

        public ClsIndicador Buscar(int Id)
        {

            string fila = ClsNFichero.Buscar(Id.ToString(), "indicadores.txt");
            if (fila != null)
            {
                return ClsNIndicador.Parse(fila);
            }
            else
            {
                return null;
            }
        }

        public static int ObtenerId()
        {
            string[] filas = ClsNFichero.Leer("indicadores.txt");
            int mayorId = 0;
            foreach (string fila in filas)
            {
                ClsIndicador indicador = ClsNIndicador.Parse(fila);
                if (mayorId < indicador.Id)
                {
                    mayorId = indicador.Id;
                }
            }
            return mayorId;
        }

        public bool Calificar(ClsIndicador indicadorActual)
        {
            double promedioIndicadores = 0;
            double promedioCriterios = 0;
            double promedioCapacidades = 0;
            double promedioNotas = 0;
            bool modificoNotaFinal = false, modifocCapacidad = false,
                 modificoCriterio = false, modificoIndicador = false;
            //Actualizar nota indicador
            modificoIndicador = Modificar(indicadorActual);
            //Promediar Indicadores Hermanos
            ClsNCriterio ControladorCriterio = new ClsNCriterio();
            ClsCriterio criterioPadre = ControladorCriterio.Buscar(indicadorActual.CriterioId);
            ArrayList listaIndicadores = ControladorCriterio.ObtenerIndicadores(criterioPadre.Id);
            foreach (ClsIndicador indicador in listaIndicadores )
            {
                promedioIndicadores += indicador.Calificacion;
            }
            //Actualizar Criterio Padre de los indicador
            criterioPadre.Calificacion = promedioIndicadores / listaIndicadores.Count;
            modificoCriterio = ControladorCriterio.Modificar(criterioPadre);
            //Promediar Criterios Hermanos   
            ClsNCapacidad ControladorCapacidad = new ClsNCapacidad();
            ClsCapacidad capacidadPadre = ControladorCapacidad.Buscar(criterioPadre.CapacidadId);
            ArrayList listaCriterios = ControladorCapacidad.ObtenerCriterios(capacidadPadre.Id);
            foreach (ClsIndicador criterio in listaCriterios)
            {
                promedioCriterios += criterio.Calificacion;
            }
            //Actualizar Capacidad Padre de los Criterios
            capacidadPadre.Calificacion = promedioCriterios/listaCriterios.Count;
            modifocCapacidad = ControladorCapacidad.Modificar(capacidadPadre);
            //Promediar Capacidades Hermanas
            ClsNNota ControladorNota = new ClsNNota();
            ClsNota NotaPadre = ControladorNota.Buscar(capacidadPadre.NotaId);
            ArrayList listaCapacidades = ControladorNota.ObtenerCapacidades(NotaPadre.Id);
            foreach (ClsIndicador nota in listaCapacidades)
            {
                promedioNotas += nota.Calificacion;
            }

            //Actualizar Nota Final
            NotaPadre.Calificacion = promedioCapacidades / listaCapacidades.Count;
            modificoNotaFinal = ControladorNota.Modificar(NotaPadre);

            return modificoIndicador && modificoCriterio && modifocCapacidad && modificoNotaFinal;
        }
    }
}
