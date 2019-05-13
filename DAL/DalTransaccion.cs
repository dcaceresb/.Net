using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Utils.Extensions.Xml;

using BOL;

namespace DAL
{
  public  class DalTransaccion
    {
        public static string IngresaTran(Transaccion tra,List<Venta> list)
        {
            String mensaje;
            try
            {
    



                var xmlperson = Auxiliar.ObjectToXMLGeneric<List<Venta>>(list);
                //string xml = "<Ventas>";

                //foreach (Venta v in list)
                //{
                //    xml = xml + "<Venta>";
                //    xml = xml + "<Codigo>" + v.Codigo.ToString() + "</Codigo>";
                //    xml = xml + "<Cantidad>" + v.Cantidad.ToString() + "</Cantidad>";

                //    xml = xml + "</Venta>";
                //}
                //xml = xml + "</Ventas>";


               SqlCommand cmd = new SqlCommand();

                string con = Conexion.CadenConexion();
                cmd.Connection = new SqlConnection(con);
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Transaccion";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@MONTO", tra.Monto);
                cmd.Parameters.AddWithValue("@FECHA", tra.Fecha);
                cmd.Parameters.AddWithValue("@VENTA", xmlperson);
                cmd.ExecuteNonQuery();
                mensaje = "ok";
            }
            catch (SqlException e)
            {
                mensaje = e.Message.ToString();
            }

            return mensaje;
        }

    }
}
