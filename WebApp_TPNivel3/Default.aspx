<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp_TPNivel3._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Catálogo de Productos</h2>
    <hr />

    <div class="row">
        <div class="col-md-4">
            <label>Buscar (nombre o descripción)</label>
            <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" />
        </div>

        <div class="col-md-4">
            <label>Marca</label>
            <asp:DropDownList ID="ddlMarcaFiltro" runat="server" CssClass="form-control" />
        </div>

        <div class="col-md-4">
            <label>Categoría</label>
            <asp:DropDownList ID="ddlCategoriaFiltro" runat="server" CssClass="form-control" />
        </div>
    </div>

    <br />

    <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-primary" OnClick="btnFiltrar_Click" />
    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-default" OnClick="btnLimpiar_Click" />

    <br /><br />

    <asp:GridView ID="gvArticulos" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
        <Columns>
            <asp:TemplateField HeaderText="Imagen">
                <ItemTemplate>
                    <img src='<%# Eval("ImagenUrl") %>' style="width:120px; height:80px; object-fit:cover;" onerror="this.src='/img/no-image.png';" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Acciones">
    <ItemTemplate>
        <a class="btn btn-sm btn-info" href='Detalle.aspx?id=<%# Eval("Id") %>'>Ver</a>
    </ItemTemplate>
</asp:TemplateField>

            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
            <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:N2}" />
        </Columns>
    </asp:GridView>

</asp:Content>