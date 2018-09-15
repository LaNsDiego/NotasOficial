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
            string lina = capacidad.Id.ToString() + " , " + capacidad.Nota_id + " , " + capacidad.Numero + " , " + capacidad.Nombre + " , " + capacidad.Calificacion + capacidad.Estado;

            ClsNFichero.Agregar(lina, "capacidads.txt");
            return true;
        }

        public static ClsCapacidad Parse(string linea)
        {

            string[] campos = new string[7];

            campos = linea.Split(',');
            ClsCapacidad capacidad = new ClsCapacidad();
            capacidad.Id = Convert.ToInt32(campos[0]);
            capacidad.Nota_id = Convert.ToInt32(campos[1]);
            capacidad.Numero = Convert.ToInt32(campos[2]);
            capacidad.Nombre = campos[3];
            capacidad.Calificacion = Convert.ToDouble(campos[4]);
            capacidad.Estado = Convert.ToBoolean(campos[5]);

            return capacidad;


        }
        public ArrayList Listar()
        {
            ArrayList Lista = new ArrayList();
            string[] filas = ClsNFichero.Leer("capacidads.txt");
            for (int i = 0; i < filas.Length; i++)
            {
                ClsCapacidad capacidad = ClsNCapacidad.Parse(filas[i]);
                Lista.Add(capacidad);
            }
            return Lista;
        }

        public bool Modificar(ClsCapacidad capacidad)
        {
            string nuevoregistro = capacidad.Id.ToString() + " , " + capacidad.Nota_id + " , " + capacidad.Numero + " , " + capacidad.Nombre + " , " + capacidad.Calificacion + capacidad.Estado;
            return ClsNFichero.Editar(capacidad.Id.ToString(), nuevoregistro, "capacidads.txt");

        }

        public bool Buscar(int Id)
        {

            string val = ClsNFichero.Buscar(Id.ToString(), "capacidads.txt");
            if (val != "")
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}
