<%@ Page Title="" Language="C#" MasterPageFile="~/MenuPrincipal.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="INFO_104_Parcial3_WiltonBenedict.Reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header>
        <h3 align="center">Reporte de encuestas</h3>
    </header>

       <div class="text-center">
          <div class="grow1">
                <a>Encuestas</a>
                <br />
                <br />
                <div class="text-center" align="center">
                <asp:GridView runat="server" ID="datagrid1" PageSize="10" HorizontalAlign="Center"
                    CssClass="mydatagrid"  PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
                    RowStyle-CssClass="rows" AllowPaging="True" />
                </div>
                <br />
                <br />
          </div>
    </div>

    
    <footer>
        <a>INFO-104. Examen Parcial 3. Wilton Benedict. 12/15/23</a>
    </footer>
</asp:Content>
