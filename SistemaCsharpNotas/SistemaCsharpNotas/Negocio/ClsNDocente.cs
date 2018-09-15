using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaCsharpNotas.Entidad;
using System.Collections;
namespace SistemaCsharpNotas.Negocio
{
    class ClsNDocente
    {
        public bool Agregar(ClsDocente docente)
        {
            string lina = docente.Id.ToString() + " , " + docente.Nombres + " , " + docente.Apellidos + " , " + docente.Sexo + " , " + docente.Correo + docente.Estado;

            ClsNFichero.Agregar(lina, "docentes.txt");
            return true;
        }

        public static ClsDocente Parse(string linea)
        {

            string[] campos = new string[7];

            campos = linea.Split(',');
            ClsDocente docente = new ClsDocente();
            docente.Id = Convert.ToInt32(campos[0]);
            docente.Codigo = campos[1];
            docente.Nombres = campos[2];
            docente.Apellidos = campos[3];
            docente.Sexo = campos[4];
            docente.Correo = campos[5];
            docente.Estado = Convert.ToBoolean(campos[6]);

            return docente;


        }
        public ArrayList Listar()
        {
            ArrayList Lista = new ArrayList();
            string[] filas = ClsNFichero.Leer("docentes.txt");
            for (int i = 0; i < filas.Length; i++)
            {
                ClsDocente docente = ClsNDocente.Parse(filas[i]);
                Lista.Add(docente);
            }
            return Lista;
        }

        public bool Modificar(ClsDocente docente)
        {
            string nuevoregistro = docente.Id + "," + docente.Codigo + "," + docente.Nombres + "," + docente.Apellidos + "," + docente.Sexo + "," + docente.Correo + "," + docente.Estado;
            return ClsNFichero.Editar(docente.Id.ToString(), nuevoregistro, "docentes.txt");

        }

        public bool Buscar(int Id)
        {

            string val = ClsNFichero.Buscar(Id.ToString(), "docentes.txt");
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
