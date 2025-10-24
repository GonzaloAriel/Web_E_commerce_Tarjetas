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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario user;

            if (negocio.Login(txtUsuario.Text, txtContrasena.Text, out user))
            {
                Session["Usuario"] = user;
                if (user.Rol == "Admin")
                    Response.Redirect("GestionImagenes.aspx");
                else
                    Response.Redirect("Default.aspx");
            }
            else
            {
                lblError.Text = "Usuario o contraseña incorrectos.";
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    lblRegisterMsg.Text = "Las contraseñas no coinciden.";
                    return;
                }

                UsuarioNegocio negocio = new UsuarioNegocio();
                negocio.Registrar(txtUsuarioRegistro.Text.Trim(), txtPassword.Text.Trim(), "Usuario", txtEmail.Text.Trim());

                lblRegisterMsg.CssClass = "text-success mb-2 d-block";
                lblRegisterMsg.Text = "Cuenta creada exitosamente. Ya puedes iniciar sesión.";
            }
            catch (Exception ex)
            {
                lblRegisterMsg.Text = "Error al registrar: " + ex.Message;
            }

        }
    }
}