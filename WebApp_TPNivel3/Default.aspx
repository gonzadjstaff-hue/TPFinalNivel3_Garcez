<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp_TPNivel3._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Catálogo de Productos</h2>
    <hr />

  <asp:GridView ID="gvArticulos" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
    <Columns>

        <asp:TemplateField HeaderText="Imagen">
            <ItemTemplate>
                <img src='<%# Eval("ImagenUrl") %>' style="width:120px; height:80px; object-fit:cover;"
                     onerror="this.src='/img/no-image.png';" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
        <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:N2}" />

    </Columns>
</asp:GridView>

</asp:Content>