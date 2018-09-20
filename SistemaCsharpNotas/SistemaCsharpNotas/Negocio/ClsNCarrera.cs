using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using SistemaCsharpNotas.Entidad;

namespace SistemaCsharpNotas.Negocio
{
    class ClsNCarrera
    {
        public bool Agregar(ClsCarrera carrera)
        {
            string lina = carrera.Id.ToString() + " , " + carrera.Nombre + " , " + carrera.Sigla + " , " + carrera.Turno + " , " + carrera.Estado;

            ClsNFichero.Agregar(lina, "carreras.txt");
            return true;
        }

        public static ClsCarrera Parse(string linea)
        {

            string[] campos = new string[7];

            campos = linea.Split(',');
            ClsCarrera carrera = new ClsCarrera();
            carrera.Id = Convert.ToInt32(campos[0]);
            carrera.Nombre = campos[1];
            carrera.Sigla = campos[2];
            carrera.Turno = Convert.ToInt32(campos[3]);
            carrera.Estado = Convert.ToBoolean(campos[4]);

            return carrera;


        }
        public ArrayList Listar()
        {
            ArrayList Lista = new ArrayList();
            string[] filas = ClsNFichero.Leer("carreras.txt");
            for (int i = 0; i < filas.Length; i++)
            {
                ClsCarrera carrera = ClsNCarrera.Parse(filas[i]);
                Lista.Add(carrera);
            }
            return Lista;
        }

        public bool Modificar(ClsCarrera carrera)
        {
            string nuevoregistro = carrera.Id.ToString() + " , " + carrera.Nombre + " , " + carrera.Sigla + " , " + carrera.Turno + " , " + carrera.Estado;
            return ClsNFichero.Editar(carrera.Id.ToString(), nuevoregistro, "carreras.txt");

        }

        public bool Buscar(int Id,int columnaParaComparar = 0)
        {

            string val = ClsNFichero.Buscar(Id.ToString(), "carreras.txt",columnaParaComparar);
            if (val != null)
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
