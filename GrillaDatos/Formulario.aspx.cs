using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GrillaDatos
{
    public partial class Formulario : System.Web.UI.Page
    {
        NegocioEstilo negocioEstilo = new NegocioEstilo();
        List<Estilos> lista = new List<Estilos>();
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarEstilos();
        }

        private void cargarEstilos()
        {
            lista = negocioEstilo.listarEstilos();
            ddlEstilo.DataSource = lista;
            ddlEstilo.DataValueField = "Id";
            ddlEstilo.DataTextField = "Descripcion";
            ddlEstilo.DataBind();
        }
    }
}