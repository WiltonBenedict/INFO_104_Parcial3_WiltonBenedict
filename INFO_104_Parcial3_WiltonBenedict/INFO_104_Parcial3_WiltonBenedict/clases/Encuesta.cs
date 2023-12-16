using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Security.Claims;

namespace INFO_104_Parcial3_WiltonBenedict.clases
{
    //INFO-104. Parcial 3. Wilton Benedict 12/15/2023
    public class Encuesta
    {
        public int EncuestaID { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int Edad {  get; set; }
        public static int PartidoID { get; set; }

        public Encuesta(string nombre, string correo, int edad, int partidoID)
        {
            Nombre = nombre;
            Correo = correo;
            Edad = edad;
            PartidoID = partidoID;
        }

        public Encuesta() { }

        public static int Agregar(string Nombre, string Correo, int Edad, int PartidoID)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("agregarEncuesta", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@nombre", Nombre));
                    cmd.Parameters.Add(new SqlParameter("@correo", Correo));
                    cmd.Parameters.Add(new SqlParameter("@edad", Edad));
                    cmd.Parameters.Add(new SqlParameter("@partidoID", PartidoID));

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
    
    
        public static int ConfirmarPartido(string nombre)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("confirmarPartido", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@nombre", nombre));

                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader lectura = cmd.ExecuteReader())
                    {
                        if (lectura.Read())
                        {
                            retorno = 1;
                            string temporal = lectura[0].ToString();
                            PartidoID = int.Parse(temporal);
                        }
                        else
                        {
                            retorno = -1;
                        }

                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return retorno;
        }
    }
}