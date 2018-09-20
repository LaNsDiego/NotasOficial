using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaCsharpNotas.Entidad;
using System.Collections;
namespace SistemaCsharpNotas.Negocio
{
    class ClsNSilabo
    {

        public bool Agregar(ClsSilabo silabo)
        {
            string lina = silabo.Id.ToString() + " , " + silabo.Anio + " , " + silabo.Turno + " , " + silabo.Unidad_id + " , " + silabo.Docente_id + " , " + silabo.Estado;

            ClsNFichero.Agregar(lina, "silabos.txt");
            return true;
        }

        public static ClsSilabo Parse(string linea)
        {

            string[] campos = new string[7];

            campos = linea.Split(',');
            ClsSilabo silabo = new ClsSilabo();
            silabo.Id = Convert.ToInt32(campos[0]);
            silabo.Anio = campos[1];
            silabo.Turno = campos[2];
            silabo.Unidad_id = Convert.ToInt32(campos[3]);
            silabo.Docente_id = Convert.ToInt32(campos[4]);
            silabo.Estado = Convert.ToBoolean(campos[5]);

            return silabo;


        }
        public ArrayList Listar()
        {
            ArrayList Lista = new ArrayList();
            string[] filas = ClsNFichero.Leer("silabos.txt");
            for (int i = 0; i < filas.Length; i++)
            {
                ClsSilabo carrera = ClsNSilabo.Parse(filas[i]);
                Lista.Add(carrera);
            }
            return Lista;
        }

        public bool Modificar(ClsSilabo silabo)
        {
            string nuevoregistro = silabo.Id.ToString() + " , " + silabo.Anio + " , " + silabo.Turno + " , " + silabo.Unidad_id + " , " + silabo.Docente_id + " , " + silabo.Estado;
            return ClsNFichero.Editar(silabo.Id.ToString(), nuevoregistro, "silabo.txt");

        }

        public bool Buscar(int Id)
        {

            string val = ClsNFichero.Buscar(Id.ToString(), "silabos.txt");
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
