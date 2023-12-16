using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INFO_104_Parcial3_WiltonBenedict
{
    //INFO-104. Parcial 3. Wilton Benedict 12/15/2023
    public partial class Encuestas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void Alerta(String texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
        public void Limpiar()
        {
            tNombre.Text = string.Empty;
            tCorreo.Text = string.Empty;
            tEdad.Text = string.Empty;
        }


        public static bool ValidarCorreo(string correo)
        {
            try
            {
                // Normalize the domain
                correo = Regex.Replace(correo, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(correo,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        protected void BttFin_Click(object sender, EventArgs e)
        {
            if(tNombre.Text.Length == 0 || tCorreo.Text.Length == 0 || tEdad.Text.Length == 0)
            {
                Alerta("Faltan campos");
            }
            else if (int.TryParse(tEdad.Text, out int result) == false)
            {
                Alerta("Error. Edad invalida");
            }
            else if (int.Parse(tEdad.Text) < 18 || int.Parse(tEdad.Text) > 50)//Validar si edad entrada es valida
            {
                Alerta("No es posible completar la encuesta. Requerimientos: edad mayor a 18 pero menor a 50.");
            }

            else if(ValidarCorreo(tCorreo.Text) == false)
            {
                Alerta("Error. Correo invalido");
            }
            else if (dropPartido.Text.Length != 0)
            {
                if(clases.Encuesta.ConfirmarPartido(dropPartido.Text) > 0)
                {
                    if(clases.Encuesta.Agregar(tNombre.Text, tCorreo.Text, int.Parse(tEdad.Text), clases.Encuesta.PartidoID) > 0)
                    {
                        Alerta("Encuesta Enviada");
                    }
                    else
                    {
                        Alerta("Error al agregar encuesta");
                    }
                }
                else
                {
                    Alerta("Error al validar partido seleccionado");
                }
            }
            else
            {
                Alerta("Error al ingresar encuesta");
            }
        }
    }
}