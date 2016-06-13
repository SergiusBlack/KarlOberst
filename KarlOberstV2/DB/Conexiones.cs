using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using KarlOberstV2.Models;


namespace KarlOberstV2.DB
{
    public class Conexiones
    {
        
        //--------------------------OBTENER-------------------------------
        public DataTable GetGeneros()
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;database=karl_oberst;uid=root;password= ;");
            conn.Open();
            var query = "select * from genero";
            MySqlDataAdapter mySDA = new MySqlDataAdapter(query, conn);
            MySqlCommandBuilder mySCB = new MySqlCommandBuilder(mySDA);

            var ret = new DataTable();
            mySDA.Fill(ret);
            conn.Close();
            return ret;
        }

        public Genero GetGenByName(string name)
        {
            Genero ret ;
            MySqlConnection conn = new MySqlConnection("server=localhost;database=karl_oberst;uid=root;password= ;");
            conn.Open();
           
            var query = string.Format( "select * from genero where nombre = '{0}'",name);

            var prods = GetProductsByGen(name);

            MySqlDataAdapter mySDA = new MySqlDataAdapter(query, conn);
            MySqlCommandBuilder mySCB = new MySqlCommandBuilder(mySDA);
            var data = new DataTable();
            mySDA.Fill(data);
            conn.Close();
            ret = new Genero { IdGenero = int.Parse( data.Rows[0]["id_genero"].ToString()), Nombre = name,
                Descripcion = data.Rows[0]["descripcion"].ToString() ,Productos=prods, img= data.Rows[0]["img"].ToString()
            };


            return ret;
        }

        public List<Producto> GetProductsByGen(string name)
        {
            List<Producto> ret=new List<Producto>();
            MySqlConnection conn = new MySqlConnection("server=localhost;database=karl_oberst;uid=root;password= ;");
            conn.Open();

            var query = string.Format("select * from producto where id_genero = (select id_genero from genero where nombre = '{0}')", name);

            MySqlDataAdapter mySDA = new MySqlDataAdapter(query, conn);
            MySqlCommandBuilder mySCB = new MySqlCommandBuilder(mySDA);
            var data = new DataTable();
            mySDA.Fill(data);

            conn.Close();

            for (var i = 0; i < data.Rows.Count; i++)
            {
                ret.Add(new Producto
                {
                    Nombre = data.Rows[i]["name"].ToString(),
                    IdGenero = int.Parse(data.Rows[i]["id_genero"].ToString()),
                    ImgProducto = data.Rows[i]["url"].ToString(),
                    Descripcion = data.Rows[i]["description"].ToString()

                });
            }


            return ret;
        }

        //Login
        public bool ValidaUsuarioPorNombre(string usuario, string password)
        {
            List<Producto> ret = new List<Producto>();
            MySqlConnection conn = new MySqlConnection("server=localhost;database=karl_oberst;uid=root;password= ;");
            conn.Open();

            var query = string.Format("SELECT * FROM karl_oberst.usuario where nombre = '{0}' and password = '{1}'", usuario, password);

            MySqlDataAdapter mySDA = new MySqlDataAdapter(query, conn);
            MySqlCommandBuilder mySCB = new MySqlCommandBuilder(mySDA);
            var data = new DataTable();
            mySDA.Fill(data);

            conn.Close();

            return data.Rows.Count == 1;
        }

        public Role ObtenerRole(string usuario)
        {
            Role ret;
            ret = new Role();
            ret.tipoRole = Role.Tipo.Admin;

            return ret;
        }


        //-------------------------------------------------------------------

        //INSERTAR



    }
}