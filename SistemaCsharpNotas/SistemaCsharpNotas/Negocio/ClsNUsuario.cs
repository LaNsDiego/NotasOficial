using SistemaCsharpNotas.Entidad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCsharpNotas.Negocio
{
    class ClsNUsuario
    {
        public bool Agregar(ClsUsuario obj)
        {
            string linea = obj.Id.ToString() + "," + obj.Codigo + "," + obj.Clave + "," + obj.Nivel + "," + obj.Estado;

            ClsNFichero.Agregar(linea, "usuarios.txt");
            return true;
        }

        public static ClsUsuario Parse(string linea)
        {

            string[] campos = new string[5];

            campos = linea.Split(',');
            ClsUsuario obj = new ClsUsuario();
            obj.Id = Convert.ToInt32(campos[0]);
            obj.Codigo = campos[1];
            obj.Clave = campos[2];
            obj.Nivel = Convert.ToInt32(campos[3]);
            obj.Estado = Convert.ToBoolean(campos[4]);

            return obj;
        }
        public ArrayList Listar()
        {
            ArrayList Lista = new ArrayList();
            string[] filas = ClsNFichero.Leer("usuarios.txt");
            for (int i = 0; i < filas.Length; i++)
            {
                ClsUsuario obj = Parse(filas[i]);
                Lista.Add(obj);
            }
            return Lista;
        }

        public bool Modificar(ClsUsuario obj)
        {
            string nuevoregistro = obj.Id.ToString() + "," + obj.Codigo + "," + obj.Clave + "," + obj.Nivel + "," + obj.Estado;
            return ClsNFichero.Editar(obj.Codigo.ToString(), nuevoregistro, "usuarios.txt");
        }

        public bool Buscar(int Id)
        {
            string val = ClsNFichero.Buscar(Id.ToString(), "usuarios.txt");
            return val != "" ? true : false;
        }

        public bool Login(string codigo, string clave)
        {
            bool acceso = false;
            foreach(ClsUsuario item in Listar())
            {
                if(item.Codigo == codigo && item.Codigo == clave) acceso = true;
            }
            return acceso;
        }
    }
}
