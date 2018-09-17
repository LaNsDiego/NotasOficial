using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SistemaCsharpNotas.Negocio
{
    abstract class ClsNFichero
    {
        private static StreamWriter escritor;
        private static StreamReader lector;

        private static StreamWriter ObtenerEscritor(string tabla, bool modo = true)
        {
            return escritor != null ? escritor : new StreamWriter(tabla, modo);
        }

        private static StreamReader ObtenerLector(string tabla)
        {
            return lector != null ? lector : new StreamReader(tabla);
        }

        public static void Agregar(string linea , string tabla)
        {
            StreamWriter escritor = ClsNFichero.ObtenerEscritor(tabla);
            escritor.WriteLine(linea);
            escritor.Close();
        }

        public static bool Editar(string textoABuscar, string nuevoRegistro, string tabla, int columnaParaComparar = 0)
        {
            bool editado = false;
            string linea = string.Empty;
            StreamReader lector = ClsNFichero.ObtenerLector(tabla);
            StreamWriter escritor = ClsNFichero.ObtenerEscritor("tmp" + tabla, false);
            while ((linea = lector.ReadLine()) != null)
            {
                string[] campos = linea.Split(',');
                Console.WriteLine("Comparado : " + campos[columnaParaComparar] + " == " + textoABuscar);
                if (campos[columnaParaComparar] == textoABuscar)
                {
                    escritor.WriteLine(nuevoRegistro);
                    editado = true;
                }
                else
                {
                    escritor.WriteLine(linea);
                }
            }
            lector.Close();
            escritor.Close();
            File.Delete(tabla);
            File.Move("tmp" + tabla, tabla);
            return editado;
        }

        public static string Buscar(string textoABuscar, string tabla, int columnaParaComparar = 0)
        {
            string linea = string.Empty;
            StreamReader lector = ClsNFichero.ObtenerLector(tabla);

            while ((linea = lector.ReadLine()) != null)
            {
                string[] campos = linea.Split(',');
                if (campos[columnaParaComparar] == textoABuscar)
                {
                    lector.Close();
                    return linea;
                }
            }
            lector.Close();
            return linea;
        }

        public static string[] Leer(string tabla)
        {
            StreamReader lector = ClsNFichero.ObtenerLector(tabla);

            string contenido = lector.ReadToEnd();
            string[] filas = contenido.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            lector.Close();
            return filas;
        }
    }
}
