using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaCsharpNotas.Entidad;
using System.Collections;
using System.Threading.Tasks;

namespace SistemaCsharpNotas.Negocio
{
    class ClsNNota
    {
        public bool Agregar(ClsNota notas)
        {
            string linea = notas.Id.ToString() + " , " + notas.Estudiante_id.ToString() + " , " + notas.Silabo_id.ToString() + " , " + notas.Calificacion + " , " + notas.Estado;
            ClsNFichero.Agregar(linea, "notas.txt");
            return true;
        }
        public static ClsNota Parse(string linea)
        {
            string[] campos = new string[5];
            campos = linea.Split(',');
            ClsNota notas = new ClsNota();
            notas.Id = Convert.ToInt32(campos[0]);
            notas.Estudiante_id = Convert.ToInt32(campos[1]);
            notas.Silabo_id = Convert.ToInt32(campos[2]);
            notas.Calificacion = Convert.ToInt32(campos[3]);
            notas.Estado = Convert.ToBoolean(campos[4]);
            return notas;
        }
        public ArrayList Listar()
        {
            ArrayList Lista = new ArrayList();
            string[] filas = ClsNFichero.Leer("notas.txt");
            for (int i = 0; i < filas.Length; i++)
            {
               ClsNota notas = ClsNNota.Parse(filas[i]);
               Lista.Add(notas);
            }
            return Lista;
        }
        public bool Modificar(ClsNota nota)
        {
            string nuevoregistro = nota.Id.ToString() + " , " + nota.Estudiante_id + " , " + nota.Silabo_id + " , " + nota.Calificacion + " , " + nota.Estado; 
            return ClsNFichero.Editar(nota.Id.ToString(), nuevoregistro, "notas.txt");
        }
        public ClsNota Buscar(int Id)
        {

            string fila = ClsNFichero.Buscar(Id.ToString(), "notas.txt");
            if (fila != null)
            {
                return ClsNNota.Parse(fila);
            }
            else
            {
                return null;
            }
        }

        public ArrayList ObtenerCapacidades(int id)
        {
            ArrayList capacidadesHijos = new ArrayList();
            ArrayList capacidades = Listar();
            foreach (ClsCapacidad capacidad in capacidades)
            {
                if (capacidad.NotaId == id)
                {
                    capacidadesHijos.Add(capacidad);
                }
            }
            return capacidades;
        }

    }

}
