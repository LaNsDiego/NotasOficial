using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using SistemaCsharpNotas.Entidad;


namespace SistemaCsharpNotas.Negocio
{
    class ClsNModulo
    {
        public bool Agregar(ClsModulo modulo)
        {
            string lina = modulo.Id.ToString() + " , " + modulo.Nombre + " , " + modulo.Numero + " , " + modulo.Carrera_id + " , " + modulo.Estado;

            ClsNFichero.Agregar(lina, "modulos.txt");
            return true;
        }

        public static ClsModulo Parse(string linea)
        {

            string[] campos = new string[7];

            campos = linea.Split(',');
            ClsModulo modulo = new ClsModulo();
            modulo.Id = Convert.ToInt32(campos[0]);
            modulo.Nombre = campos[1];
            modulo.Numero = Convert.ToInt32(campos[2]);
            modulo.Carrera_id = Convert.ToInt32(campos[3]);
            modulo.Estado = Convert.ToBoolean(campos[4]);

            return modulo;


        }
        public ArrayList Listar()
        {
            ArrayList Lista = new ArrayList();
            string[] filas = ClsNFichero.Leer("modulos.txt");
            for (int i = 0; i < filas.Length; i++)
            {
                ClsModulo modulo = ClsNModulo.Parse(filas[i]);
                Lista.Add(modulo);
            }
            return Lista;
        }

        public bool Modificar(ClsModulo modulo)
        {
            string nuevoregistro = modulo.Id.ToString() + " , " + modulo.Nombre + " , " + modulo.Numero + " , " + modulo.Carrera_id + " , " + modulo.Estado;
            return ClsNFichero.Editar(modulo.Id.ToString(), nuevoregistro, "modulos.txt");

        }

        public bool Buscar(int Id)
        {

            string val = ClsNFichero.Buscar(Id.ToString(), "modulos.txt");
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
