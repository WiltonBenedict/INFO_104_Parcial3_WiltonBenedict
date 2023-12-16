using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INFO_104_Parcial3_WiltonBenedict
{
    //INFO-104. Parcial 3. Wilton Benedict 12/15/2023
    public partial class Reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarReporte();
        }

        protected void LlenarReporte()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("reporteGeneral"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            datagrid1.DataSource = dt;
                            datagrid1.DataBind();  // actualiza el grid view
                        }
                    }
                }
            }
        }
    }
}