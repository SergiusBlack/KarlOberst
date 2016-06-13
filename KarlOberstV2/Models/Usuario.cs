using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using KarlOberstV2.DB;

namespace KarlOberstV2.Models
{
    public class Usuario
    {
        [Required]
        [Display(Name = "Nombre de usuario")]
        public string NombreUsuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Recordar cuenta")]
        public bool Recordar { get; set; }

        public bool EsValido(string nombreUsuario, string password)
        {
            var ret = new Conexiones();

            return ret.ValidaUsuarioPorNombre(nombreUsuario, password);
        }

    }
}