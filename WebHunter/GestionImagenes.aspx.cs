using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebHunter
{
    public partial class GestionImagenes : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
           /* if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Usuario usuario = (Usuario)Session["Usuario"];
                if (usuario.Rol != "Admin")
                {
                    Response.Redirect("AccesoDenegado.aspx");
                }
            }*/

            if (!IsPostBack)
            {
                cargarPersonajesDrop();
            }

            ImagenNegocio negocio = new ImagenNegocio();
            dgvImagenes.DataSource = negocio.listar();
            dgvImagenes.DataBind();

            dgvImagenes.CssClass = "table table-striped table-info";
        }

        private void cargarPersonajesDrop()
        {
            PersonajesNegocio negocio = new PersonajesNegocio();
            List<Personajes> lista = negocio.Listar();

            ddlPersonaje.DataSource = lista;
            ddlPersonaje.DataTextField = "Nombre";
            ddlPersonaje.DataValueField = "Id";
            ddlPersonaje.DataBind();

            ddlPersonaje.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Seleccione un personaje --", "0"));
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Imagen imagen = new Imagen
                {
                    UrlImagen = txtUrl.Text,
                    Descripcion = txtDescripcion.Text,
                    IdPersonaje = int.Parse(ddlPersonaje.SelectedValue)
                };

                ImagenNegocio negocio = new ImagenNegocio();
                negocio.agregarImagen(imagen);

                lblMensaje.CssClass = "text-success fw-bold text-center";
                lblMensaje.Text = "✅ Imagen guardada correctamente.";

                // Limpiar formulario
                txtUrl.Text = "";
                txtDescripcion.Text = "";
                ddlPersonaje.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                lblMensaje.CssClass = "text-danger fw-bold text-center";
                lblMensaje.Text = "❌ Error al guardar: " + ex.Message;
            }
        }

        protected void btnImgEliminar_Click(object sender, EventArgs e)
        {
            ImagenNegocio negocio = new ImagenNegocio();
            int id = int.Parse(txtIdImagen.Text);
            negocio.Eliminar(id);

            lbEliminado.CssClass = "text-success fw-bold text-center";
            lbEliminado.Text = "👍 Imagen eliminada correctamente";
            txtIdImagen.Text = "";
        }

        protected void dgvImagenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var seleccion = dgvImagenes.SelectedRow.Cells[0].Text;
            var id = dgvImagenes.SelectedDataKey.Value.ToString();

            ImagenNegocio negocio = new ImagenNegocio();

            if (!string.IsNullOrEmpty(id))
            {
                int IdImg = int.Parse(id);
                var listaTemporal = negocio.listar();
                Imagen img = listaTemporal.Find(x => x.IdImagen == IdImg);

                if (img != null)
                {
                    ddlPersonaje.SelectedValue = img.IdPersonaje.ToString();
                    txtDescripcion.Text = img.Descripcion;
                    txtUrl.Text = img.UrlImagen;
                }
                else
                {
                    lblMensaje.Text = "No se encontró la imagen seleccionada.";
                    // Limpiar formulario
                    txtUrl.Text = "";
                    txtDescripcion.Text = "";
                    ddlPersonaje.SelectedIndex = 0;
                }
            }
            
        }

        protected void ddlPersonaje_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPersonaje.SelectedValue == "0")
            {
                txtUrl.Text = "";
                txtDescripcion.Text = "";
            }
        }
    }
}