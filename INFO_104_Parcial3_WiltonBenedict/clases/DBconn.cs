using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace INFO_104_Parcial3_WiltonBenedict.clases
{

    //INFO-104. Parcial 3. Wilton Benedict 12/15/2023
    public class DBconn
    {
        public static SqlConnection ObtenerConexion()
        {
            string s = System.Configuration.ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            return conexion;
        }
    }
}