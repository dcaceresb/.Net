using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Conexion
    { 
        public static string CadenConexion()
        {
            string con = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ventas;  Integrated Security = True";

            return con;
        }
    }
}
