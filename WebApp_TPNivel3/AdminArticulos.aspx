<%@ Page Title="Administración" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AdminArticulos.aspx.cs" Inherits="WebApp_TPNivel3.AdminArticulos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Administración de Artículos</h2>
    <hr />

    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo Artículo" CssClass="btn btn-success"
        PostBackUrl="~/ArticuloForm.aspx" />

    <br /><br />

    <asp:GridView ID="gvAdmin" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered"
        DataKeyNames="Id" OnRowCommand="gvAdmin_RowCommand">
        <Columns>
            <asp:BoundField DataField="Codigo" HeaderText="Código" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:N2}" />

            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:LinkButton ID="btnEditar" runat="server" CssClass="btn btn-primary btn-sm"
                        CommandName="Editar" CommandArgument='<%# Eval("Id") %>' Text="Editar" />
                    <asp:LinkButton ID="btnEliminar" runat="server" CssClass="btn btn-danger btn-sm"
                        CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' Text="Eliminar"
                        OnClientClick="return confirm('¿Seguro que querés eliminar este artículo?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>