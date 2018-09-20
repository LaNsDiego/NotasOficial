using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using SistemaCsharpNotas.Entidad;
namespace SistemaCsharpNotas.Negocio
{
    class ClsNUnidad
    {

        public bool Agregar(ClsUnidad unidad)
        {
            string lina = unidad.Id.ToString() + " , " + unidad.Nombre + " , " + unidad.Codigo + " , " + unidad.Modulo_id + " , " + unidad.Estado;

            ClsNFichero.Agregar(lina, "unidades.txt");
            return true;
        }

        public static ClsUnidad Parse(string linea)
        {

            string[] campos = new string[7];

            campos = linea.Split(',');
            ClsUnidad unidad = new ClsUnidad();
            unidad.Id = Convert.ToInt32(campos[0]);
            unidad.Nombre = campos[1];
            unidad.Codigo = campos[2];
            unidad.Modulo_id = Convert.ToInt32(campos[3]);
            unidad.Estado = Convert.ToBoolean(campos[4]);
            

            return unidad;


        }
        public ArrayList Listar()
        {
            ArrayList Lista = new ArrayList();
            string[] filas = ClsNFichero.Leer("unidades.txt");
            for (int i = 0; i < filas.Length; i++)
            {
                ClsUnidad carrera = ClsNUnidad.Parse(filas[i]);
                Lista.Add(carrera);
            }
            return Lista;
        }

        public bool Modificar(ClsUnidad unidad)
        {
            string nuevoregistro = unidad.Id.ToString() + " , " + unidad.Nombre + " , " + unidad.Codigo + " , " + unidad.Modulo_id  + " , " + unidad.Estado;
            return ClsNFichero.Editar(unidad.Id.ToString(), nuevoregistro, "unidades.txt");

        }

        public bool Buscar(int Id)
        {

            string val = ClsNFichero.Buscar(Id.ToString(), "unidades.txt");
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
