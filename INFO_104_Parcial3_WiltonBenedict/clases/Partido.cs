using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace INFO_104_Parcial3_WiltonBenedict.clases
{
    //INFO-104. Parcial 3. Wilton Benedict 12/15/2023
    public class Partido
    {
        public int PartidoID { get; set; }
        public string nombre { get; set; }

        public Partido(string nombre)
        {
            this.nombre = nombre;
        }

        public Partido() { }

        public static int Agregar(string Nombre)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("agregarPartido", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@nombre", Nombre));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }
    }
}