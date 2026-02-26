<%@ Page Title="Artículo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ArticuloForm.aspx.cs" Inherits="WebApp_TPNivel3.ArticuloForm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Artículo</h2>
    <hr />

    <asp:Label ID="lblError" runat="server" CssClass="text-danger" />

    <div class="form-group">
        <label>Código</label>
        <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" />
    </div>

    <div class="form-group">
        <label>Nombre</label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
    </div>

    <div class="form-group">
        <label>Descripción</label>
        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
    </div>

    <div class="form-group">
        <label>Marca</label>
        <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-control" />
    </div>

    <div class="form-group">
        <label>Categoría</label>
        <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control" />
    </div>

    <div class="form-group">
        <label>URL Imagen</label>
        <asp:TextBox ID="txtImagenUrl" runat="server" CssClass="form-control" />
    </div>

    <div class="form-group">
        <label>Precio</label>
        <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" />
    </div>

    <br />

    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-default" PostBackUrl="~/AdminArticulos.aspx" />
</asp:Content>