<%@ Page Title="Personajes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PersonajesWeb.aspx.cs" Inherits="WebHunter.PersonajesWeb" %>

 <%--Link para Css personalizado por pagina--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<%= ResolveUrl("~/Style/Content/personajes.css") %>" rel="stylesheet" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2 class="text-center mb-4">Personajes de Hunter x Hunter</h2>

        
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater ID="RepPersonajes" runat="server">
                <ItemTemplate>
                    <div class="col">
                        <div class="card h-25">
                            <!-- Imagen opcional -->
                            <img src='<%# Eval("ImagenUrl") %>' class="card-img-top img-fluid" alt='<%# Eval("Nombre") %>' onerror="this.src='https://via.placeholder.com/300x200?text=Sin+imagen'"/>

                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                <h6 class="text-muted">Código: <%# Eval("Codigo") %></h6>
                                <p class="card-text"><%# Eval("Descripcion") %></p>
                            </div>

                            <div class="card-footer bg-white">
                                <small class="text-muted">
                                    <strong>Rol:</strong> <%# Eval("Rol.Descripcion") %> <br />
                                    <strong>Nen:</strong> <%# Eval("Habilidad.Descripcion") %>
                                </small>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
