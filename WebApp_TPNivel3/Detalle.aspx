<%@ Page Title="Detalle" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="WebApp_TPNivel3.Detalle" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="pnlOk" runat="server" Visible="false">
        <h2><asp:Label ID="lblNombre" runat="server" /></h2>
        <hr />

        <div class="row">
            <div class="col-md-5">
                <img id="imgArticulo" runat="server" class="img-responsive img-thumbnail" style="max-height:350px; object-fit:cover;"
                     onerror="this.src='/img/no-image.png';" />
            </div>

            <div class="col-md-7">
                <p><strong>Código:</strong> <asp:Label ID="lblCodigo" runat="server" /></p>
                <p><strong>Descripción:</strong> <asp:Label ID="lblDescripcion" runat="server" /></p>
                <p><strong>Marca:</strong> <asp:Label ID="lblMarca" runat="server" /></p>
                <p><strong>Categoría:</strong> <asp:Label ID="lblCategoria" runat="server" /></p>
                <p><strong>Precio:</strong> <asp:Label ID="lblPrecio" runat="server" /></p>

                <a href="Default.aspx" class="btn btn-default">Volver</a>
            </div>
        </div>
    </asp:Panel>

    <asp:Panel ID="pnlError" runat="server" Visible="false">
        <div class="alert alert-danger">
            <asp:Label ID="lblError" runat="server" />
        </div>
        <a href="Default.aspx" class="btn btn-default">Volver</a>
    </asp:Panel>

</asp:Content>