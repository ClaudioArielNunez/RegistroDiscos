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
        NegocioTipo negocioEdicion = new NegocioTipo();
        List<Estilos> listaEstilos = new List<Estilos>();
        List<TiposEdicion> listaEdicion = new List<TiposEdicion>();
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarEstilos();
            cargarTipos();
        }

        private void cargarTipos()
        {
            listaEdicion = negocioEdicion.listarTipos();
            ddlTipo.DataSource = listaEdicion;
            ddlTipo.DataValueField = "Id";
            ddlTipo.DataTextField = "Descripcion";
            ddlTipo.DataBind();
        }

        private void cargarEstilos()
        {
            listaEstilos = negocioEstilo.listarEstilos();
            ddlEstilo.DataSource = listaEstilos;
            ddlEstilo.DataValueField = "Id";
            ddlEstilo.DataTextField = "Descripcion";
            ddlEstilo.DataBind();
        }

    }
}