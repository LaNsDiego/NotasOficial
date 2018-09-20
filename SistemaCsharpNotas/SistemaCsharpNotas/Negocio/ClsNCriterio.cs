using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using SistemaCsharpNotas.Entidad;
namespace SistemaCsharpNotas.Negocio
{
    class ClsNCriterio
    {
        public bool Agregar(ClsCriterio criterio)
        {
            string lina = criterio.Id.ToString() + " , " + criterio.CapacidadId + " , " + criterio.Nombre + " , " + criterio.Descripcion + " , " + criterio.Calificacion + " , " + criterio.Estado;

            ClsNFichero.Agregar(lina, "criterios.txt");
            return true;
        }

        public static ClsCriterio Parse(string linea)
        {

            string[] campos = new string[7];

            campos = linea.Split(',');
            ClsCriterio criterio = new ClsCriterio();
            criterio.Id = Convert.ToInt32(campos[0]);
            criterio.CapacidadId = Convert.ToInt32(campos[1]);
            criterio.Nombre = campos[2];
            criterio.Descripcion = campos[3];
            criterio.Calificacion = Convert.ToDouble(campos[4]);
            criterio.Estado = Convert.ToBoolean(campos[5]);

            return criterio;


        }
        public ArrayList Listar()
        {
            ArrayList Lista = new ArrayList();
            string[] filas = ClsNFichero.Leer("criterios.txt");
            for (int i = 0; i < filas.Length; i++)
            {
                ClsCriterio criterio = ClsNCriterio.Parse(filas[i]);
                Lista.Add(criterio);
            }
            return Lista;
        }

        public bool Modificar(ClsCriterio criterio)
        {
            string nuevoregistro = criterio.Id.ToString() + " , " + criterio.CapacidadId + " , " + criterio.Nombre + " , " + criterio.Descripcion + " , " + criterio.Calificacion + " , " + criterio.Estado;
            return ClsNFichero.Editar(criterio.Id.ToString(), nuevoregistro, "criterios.txt");

        }

        public ClsCriterio Buscar(int Id)
        {

            string fila = ClsNFichero.Buscar(Id.ToString(), "criterios.txt");
            if (fila != null)
            {
                return ClsNCriterio.Parse(fila);
            }
            else
            {
                return null;
            }
        }

        public ArrayList ObtenerIndicadores(int id)
        {
            ArrayList indicadoresHijos = new ArrayList();
            ArrayList indicadores = Listar();
            foreach (ClsIndicador indicador in indicadores)
            {
                if (indicador.CriterioId == id)
                {
                    indicadoresHijos.Add(indicador);
                }
            }
            return indicadores;
        }


    }
}
