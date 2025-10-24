using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebHunter
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Ocultar todo por defecto
                navPerfil.Visible = false;
                navAdmin.Visible = false;
                navLogout.Visible = false;
                navLogin.Visible = true;

                if (Session["usuario"] != null)
                {
                    Usuario usuario = (Usuario)Session["Usuario"];
                    string rol = usuario.Rol;

                    // Mostrar secciones comunes a todos los logueados
                    navPerfil.Visible = true;
                    navLogout.Visible = true;
                    navLogin.Visible = false;

                    // Mostrar secciones exclusivas de admin
                    if (rol == "Admin")
                        navAdmin.Visible = true;
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}