<%@ Page Title="Catálogo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp_TPNivel3._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-8">
            <h2 style="margin-top:0;">Catálogo</h2>
            <p class="text-muted">Buscá por nombre/descrición y filtrá por marca y categoría.</p>
        </div>
    </div>

    <div class="panel panel-default">
        <div class="panel-body">
            <div class="row">
                <div class="col-md-4">
                    <label>Buscar</label>
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
        </div>
    </div>

    <asp:Label ID="lblInfo" runat="server" CssClass="text-muted" />

    <br />

    <div class="row">
        <asp:Repeater ID="rptArticulos" runat="server">
            <ItemTemplate>
                <div class="col-sm-6 col-md-4" style="margin-bottom:20px;">
                    <div class="panel panel-default" style="height:100%;">
                        <div class="panel-body">
                            <div style="height:180px; overflow:hidden; border-radius:4px;">
                                <img src='<%# Eval("ImagenUrl") %>' style="width:100%; height:180px; object-fit:cover;"
                                     onerror="this.src='/img/no-image.png';" />
                            </div>

                            <h4 style="margin-top:12px;"><%# Eval("Nombre") %></h4>
                            <p class="text-muted" style="min-height:40px;"><%# Eval("Descripcion") %></p>

                            <div class="clearfix" style="margin-top:10px;">
                                <strong class="pull-left">$ <%# string.Format("{0:N2}", Eval("Precio")) %></strong>
                                <a class="btn btn-xs btn-info pull-right" href='Detalle.aspx?id=<%# Eval("Id") %>'>Ver</a>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>