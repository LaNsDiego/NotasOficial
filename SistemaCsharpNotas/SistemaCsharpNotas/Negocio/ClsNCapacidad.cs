using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using SistemaCsharpNotas.Entidad;

namespace SistemaCsharpNotas.Negocio
{
    class ClsNCapacidad
    {
        public bool Agregar(ClsCapacidad capacidad)
        {
            string lina = capacidad.Id.ToString() + " , " + capacidad.NotaId + " , " + capacidad.Numero + " , " + capacidad.Nombre + " , " + capacidad.Calificacion + capacidad.Estado;

            ClsNFichero.Agregar(lina, "capacidades.txt");
            return true;
        }

        public static ClsCapacidad Parse(string linea)
        {

            string[] campos = new string[7];

            campos = linea.Split(',');
            ClsCapacidad capacidad = new ClsCapacidad();
            capacidad.Id = Convert.ToInt32(campos[0]);
            capacidad.NotaId = Convert.ToInt32(campos[1]);
            capacidad.Numero = Convert.ToInt32(campos[2]);
            capacidad.Nombre = campos[3];
            capacidad.Calificacion = Convert.ToDouble(campos[4]);
            capacidad.Estado = Convert.ToBoolean(campos[5]);

            return capacidad;


        }
        public ArrayList Listar()
        {
            ArrayList Lista = new ArrayList();
            string[] filas = ClsNFichero.Leer("capacidades.txt");
            for (int i = 0; i < filas.Length; i++)
            {
                ClsCapacidad capacidad = ClsNCapacidad.Parse(filas[i]);
                Lista.Add(capacidad);
            }
            return Lista;
        }

        public bool Modificar(ClsCapacidad capacidad)
        {
            string nuevoregistro = capacidad.Id.ToString() + " , " + capacidad.NotaId + " , " + capacidad.Numero + " , " + capacidad.Nombre + " , " + capacidad.Calificacion + capacidad.Estado;
            return ClsNFichero.Editar(capacidad.Id.ToString(), nuevoregistro, "capacidades.txt");

        }

        public ClsCapacidad Buscar(int Id)
        {

            string fila = ClsNFichero.Buscar(Id.ToString(), "capacidades.txt");
            if (fila != null)
            {
                return ClsNCapacidad.Parse(fila);
            }
            else
            {
                return null;
            }
        }

        public ArrayList ObtenerCriterios(int id)
        {
            ArrayList criteriosHijos = new ArrayList();
            ArrayList criterios = Listar();
            foreach (ClsCriterio criterio in criterios)
            {
                if (criterio.CapacidadId == id)
                {
                    criteriosHijos.Add(criterio);
                }
            }
            return criterios;
        }
    }
}
