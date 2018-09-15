using SistemaCsharpNotas.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SistemaCsharpNotas.Negocio
{
    class ClsNEstudiante
    {

        public bool Agregar(ClsEstudiante estudiante)
        {
            string lina = estudiante.Id.ToString() + " , " + estudiante.Nombres + " , " + estudiante.Apellidos + " , " + estudiante.Sexo + " , " + estudiante.Correo + estudiante.Estado;

            ClsNFichero.Agregar(lina,"estudiantes.txt");
            return true;
        }

        public static ClsEstudiante Parse(string linea)
        {
            
            string[] campos = new string[7];

            campos = linea.Split(',');
            ClsEstudiante Estudiante = new ClsEstudiante();
            Estudiante.Id = Convert.ToInt32(campos[0]);
            Estudiante.Codigo = campos[1];
            Estudiante.Nombres = campos[2];
            Estudiante.Apellidos = campos[3];
            Estudiante.Sexo = campos[4];
            Estudiante.Correo = campos[5];
            Estudiante.Estado = Convert.ToBoolean(campos[6]);

            return Estudiante;
      
       
        }
        public ArrayList Listar()
        {
            ArrayList Lista = new ArrayList();
            string[] filas = ClsNFichero.Leer("Estudiantes.txt");
            for (int i = 0; i < filas.Length; i++)
            {
                ClsEstudiante Estudiante = ClsNEstudiante.Parse(filas[i]);
                Lista.Add(Estudiante);
            }
            return Lista;
        }

        public bool Modificar(ClsEstudiante estudiante)
        {
            string nuevoregistro = estudiante.Id + "," + estudiante.Codigo + "," + estudiante.Nombres + "," + estudiante.Apellidos + "," + estudiante.Sexo + "," + estudiante.Correo + "," + estudiante.Estado;
            return ClsNFichero.Editar(estudiante.Id.ToString() , nuevoregistro, "Estudiantes.txt");

        }

        public bool Buscar(int Id)
        {
            
           string val =  ClsNFichero.Buscar(Id.ToString(), "Estudiantes.txt");
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
