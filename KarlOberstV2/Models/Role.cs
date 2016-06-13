using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KarlOberstV2.Models
{
    public class Role
    {
        public enum Tipo
        {
            Admin = 1,
            Empleado =2,
            Usuario = 3
        }

        public Tipo tipoRole { get; set;}
    }
}