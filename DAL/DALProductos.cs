using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;

namespace DAL
{
 public   class DALProductos
    {
        public static string IngresaProd(Productos p)
        {
            String mensaje;
            try {
                SqlCommand cmd = new SqlCommand();

                string con = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ventas;  Integrated Security = True";
                cmd.Connection = new SqlConnection(con);
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "IngresaProducto";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@codigo", p.Codigo);
                cmd.Parameters.AddWithValue("@descripcion", p.Descripcion);
                cmd.Parameters.AddWithValue("@precio", p.Precio);
                cmd.ExecuteNonQuery();
                mensaje = "ok";
            }
            catch (SqlException e)
            {
                     mensaje =  e.Message.ToString();    
            }

            return mensaje;
        }


        public static string Modificar(Productos p)
        {
            String mensaje;
            try
            {
                SqlCommand cmd = new SqlCommand();

                string con = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ventas;  Integrated Security = True";
                cmd.Connection = new SqlConnection(con);
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MODIFICA_PROD";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@codigo", p.Codigo);
                cmd.Parameters.AddWithValue("@descripcion", p.Descripcion);
                cmd.Parameters.AddWithValue("@precio", p.Precio);
                cmd.ExecuteNonQuery();
                mensaje = "ok";
            }
            catch (SqlException e)
            {
                mensaje = e.Message.ToString();
            }

            return mensaje;
        }


        public static string Eliminar(string codigo)
        {
            String mensaje;
            try
            {
                SqlCommand cmd = new SqlCommand();

                string con = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ventas;  Integrated Security = True";
                cmd.Connection = new SqlConnection(con);
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ELIMINAR_PROD";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@codigo", codigo);

                cmd.ExecuteNonQuery();
                mensaje = "ok";
            }
            catch (SqlException e)
            {
                mensaje = e.Message.ToString();
            }

            return mensaje;
        }

        public static List<Productos> ListarProductos()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();

                string con = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ventas;  Integrated Security = True";
                //string con = "Data Source=DESKTOP-BRM86JT\\SQLEXPRESS;Initial Catalog=ventas;  User Id=sa;Password = 1234";
                cmd.Connection = new SqlConnection(con);
               

                cmd.Connection.Open();
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select codigo,descripcion,precio  from productos";

                SqlDataReader rdr = cmd.ExecuteReader();
                List<Productos> listaProd = new List<Productos>();

                while (rdr.Read())
                {
                    listaProd.Add(new Productos
                    {
                        Codigo = rdr["codigo"].ToString(),
                        Descripcion = rdr["Descripcion"].ToString(),
                        Precio = Int32.Parse(rdr["Precio"].ToString())
                    });
                }

                cmd.Connection.Close();
                cmd.Dispose();
                return listaProd;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
