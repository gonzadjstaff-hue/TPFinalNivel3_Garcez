<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApp_TPNivel3.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Login</h2>

    <asp:Label ID="lblError" runat="server" CssClass="text-danger" />

    <div class="form-group">
        <label>Email</label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
    </div>

    <div class="form-group">
        <label>Password</label>
        <asp:TextBox ID="txtPass" runat="server" TextMode="Password" CssClass="form-control" />
    </div>

    <asp:Button ID="btnLogin" runat="server" Text="Ingresar" OnClick="btnLogin_Click" />

</asp:Content>