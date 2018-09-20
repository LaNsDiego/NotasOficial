using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaCsharpNotas.Entidad;
using System.Collections;
using System.Threading.Tasks;

namespace SistemaCsharpNotas.Negocio
{
    class ClsNSemestre
    {
        public bool Agregar(ClsSemestre semestre)
        {
            string lina = semestre.Id.ToString() + " , " + semestre.Nombre + " , " + semestre.Estado;
            ClsNFichero.Agregar(lina, "semestres.txt");
            return true;
        }
        public static ClsSemestre Parse(string linea)
        {
            string[] campos = new string[3];
            campos = linea.Split(',');
            ClsSemestre semestre = new ClsSemestre();
            semestre.Id = Convert.ToInt32(campos[0]);
            semestre.Nombre = campos[1];
            semestre.Estado = Convert.ToBoolean(campos[2]);

            return semestre;
        }
        public ArrayList Listar()
        {
            ArrayList Lista = new ArrayList();
            string[] filas = ClsNFichero.Leer("semestres.txt");
            for (int i = 0; i < filas.Length; i++)
            {
                ClsSemestre semestre = ClsNSemestre.Parse(filas[i]);
                Lista.Add(semestre);
            }
            return Lista;
        }
        public bool Modificar(ClsSemestre semestre)
        {
            string nuevoregistro = semestre.Id.ToString() + " , " + semestre.Nombre + " , " + semestre.Estado;
            return ClsNFichero.Editar(semestre.Id.ToString(), nuevoregistro, "semestres.txt");
        }
        public bool Buscar(int Id)
        {
            string val = ClsNFichero.Buscar(Id.ToString(), "semestres.txt");
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