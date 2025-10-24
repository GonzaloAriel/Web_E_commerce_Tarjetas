<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebHunter.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-5">
        <div class="row justify-content-center">


            <div class="col-md-5">
                <div class="card shadow-lg p-4 rounded-4">
                    <h3 class="text-center mb-4">Iniciar Sesión</h3>
                    <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>

                    <div class="form-group mb-3">
                        <label>Usuario</label>
                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" />
                    </div>

                    <div class="form-group mb-3">
                        <label>Contraseña</label>
                        <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password" CssClass="form-control" />
                    </div>

                    <asp:Button ID="btnLogin" runat="server" Text="Ingresar" CssClass="btn btn-primary w-100" OnClick="btnLogin_Click" />
                </div>
            </div>


            <div class="col-md-5">
                <div class="card shadow-lg p-4 rounded-4">
                    <h3 class="text-center mb-4">Registrate!</h3>

                    <asp:Label ID="lblRegisterMsg" runat="server" CssClass="text-danger mb-3 d-block"></asp:Label>

                    <div class="mb-3">
                        <label for="txUsuario" class="form-label">Usuario</label>
                        <asp:TextBox ID="txtUsuarioRegistro" runat="server" CssClass="form-control" />
                    </div>

                    <div class="mb-3">
                        <label for="txtEmail" class="form-label">Correo electrónico</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" />
                    </div>

                    <div class="mb-3">
                        <label for="txtPassword" class="form-label">Contraseña</label>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
                    </div>

                    <div class="mb-3">
                        <label for="txtConfirmPassword" class="form-label">Confirmar contraseña</label>
                        <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" />
                    </div>

                    <asp:Button ID="btnRegistrar" runat="server" Text="Crear cuenta" CssClass="btn btn-success w-100" OnClick="btnRegistrar_Click" />
                </div>
            </div>


        </div>
    </div>

</asp:Content>
