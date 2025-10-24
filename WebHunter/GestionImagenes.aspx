<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionImagenes.aspx.cs" Inherits="WebHunter.GestionImagenes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-container {
            max-width: 600px;
            margin: 40px auto;
            background-color: #ffffff;
            padding: 30px;
            border-radius: 12px;
            box-shadow: 0 4px 10px rgba(0,0,0,0.1);
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4 row">
        <h2 class="text-center mb-4">Gestión de Imágenes</h2>

        <div class="form-container">
            <asp:Panel ID="PanelForm" runat="server">
                <div class="mb-3">
                    <label for="ddlPersonaje" class="form-label">Personaje</label>
                    <asp:DropDownList 
                        ID="ddlPersonaje" runat="server" 
                        CssClass="form-select" 
                        OnSelectedIndexChanged="ddlPersonaje_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>
                </div>

                <div class="mb-3">
                    <label for="txtUrl" class="form-label">URL de la imagen</label>
                    <asp:TextBox ID="txtUrl" runat="server" CssClass="form-control" placeholder="https://..."></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label for="txtDescripcion" class="form-label">Descripción</label>
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" placeholder="Descripción opcional..."></asp:TextBox>
                </div>

                <div class="d-grid gap-2">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar Imagen" CssClass="btn btn-success" OnClick="btnGuardar_Click" />
                </div>
            </asp:Panel>
            <hr />
            <asp:Label ID="lblMensaje" runat="server" CssClass="text-center d-block mt-3 fw-bold"></asp:Label>
        </div>


        <div class="form-container">
            <asp:Panel ID="Panel1" runat="server">
                <div class="mb-3">
                    <label for="txtUrl" class="form-label">Id Imagen</label>
                    <asp:TextBox ID="txtIdImagen" runat="server" CssClass="form-control" placeholder="ID Imagen"></asp:TextBox>
                </div>

                <div class="d-grid gap-2">
                    <asp:Button ID="btnImgEliminar" runat="server" Text="Eliminar Imagen" CssClass="btn btn-success" OnClick="btnImgEliminar_Click" />
                </div>
            </asp:Panel>
            <hr />
            <asp:Label ID="lbEliminado" runat="server" CssClass="text-center d-block mt-3 fw-bold"></asp:Label>
        </div>


         <asp:GridView ID="dgvImagenes" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvImagenes_SelectedIndexChanged" DataKeyNames="IdImagen" >
             <Columns>
                 <asp:BoundField HeaderText="IdImagen" DataField="IdImagen" />
                 <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                 <asp:BoundField HeaderText="IdPersonaje" DataField="IdPersonaje" />
                 <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Accion" />
             </Columns>
         </asp:GridView>
    </div>


</asp:Content>
