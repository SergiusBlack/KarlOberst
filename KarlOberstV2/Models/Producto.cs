using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace KarlOberstV2.Models
{
    public class Producto
    {
       
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public Genero Genero { get; set; }
        public int IdGenero { get; set; }
        public string ImgProducto { get; set; }

        
        

    }
}