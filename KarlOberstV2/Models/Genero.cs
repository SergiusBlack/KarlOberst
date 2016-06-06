﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KarlOberstV2.Models
{
    public class Genero
    {
        public int IdGenero { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<Producto> Productos { get; set; }
        public string img { get; set; }
    }
}