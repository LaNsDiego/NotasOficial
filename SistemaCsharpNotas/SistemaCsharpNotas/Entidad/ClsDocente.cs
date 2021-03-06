﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCsharpNotas.Entidad
{
    class ClsDocente
    {
        private int id;
        private string codigo;
        private string nombres;
        private string apellidos;
        private string sexo;
        private string correo;
        private bool estado;

        public int Id { get => id; set => id = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public string Correo { get => correo; set => correo = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
