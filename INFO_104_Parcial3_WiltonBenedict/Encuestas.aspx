<%@ Page Title="" Language="C#" MasterPageFile="~/MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="Encuestas.aspx.cs" Inherits="INFO_104_Parcial3_WiltonBenedict.Encuestas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 50%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center"> Encuesta</h2>
    <div>
        <br />
        <br />
        <br />
        <table align="center" class="auto-style1">
            <tr>
                <td>Nombre completo:</td>
                <td><asp:TextBox ID="tNombre" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Correo Electronico:</td>
                <td><asp:TextBox ID="tCorreo" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Edad:</td>
                <td><asp:TextBox ID="tEdad" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Partido Político: </td>
                <td>
                    <asp:DropDownList ID="dropPartido" runat="server" DataSourceID="SQLpartido" DataTextField="nombre" DataValueField="nombre"></asp:DropDownList>

                    <asp:SqlDataSource ID="SQLpartido" runat="server" ConnectionString="<%$ ConnectionStrings:Conexion %>" ProviderName="<%$ ConnectionStrings:Conexion.ProviderName %>" SelectCommand="SELECT [nombre] FROM [partido]"></asp:SqlDataSource>

                </td>
            </tr>
        </table>
    </div>

    <div>
        <table align="center" class="auto-style1">
            <tr  align="center">
                 <td ><asp:Button ID="BttFin" runat="server" Text="Finalizar Encuesta" CssClass="button button1" OnClick="BttFin_Click"/></td>
            </tr>
        </table>
    </div>


    <footer>
        <a>INFO-104. Examen Parcial 3. Wilton Benedict. 12/15/23</a>
    </footer>

</asp:Content>
