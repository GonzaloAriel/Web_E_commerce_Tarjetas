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
    public partial class PersonajesWeb : System.Web.UI.Page
    {
        List<Personajes> ListaDePersonajes { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            PersonajesNegocio negocio = new PersonajesNegocio();
            ListaDePersonajes = negocio.Listar();

            RepPersonajes.DataSource = ListaDePersonajes;
            RepPersonajes.DataBind();

        }
    }

}