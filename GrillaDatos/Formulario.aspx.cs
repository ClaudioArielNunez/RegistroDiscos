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
        NegocioDisco negocioDisco = new NegocioDisco();
        NegocioEstilo negocioEstilo = new NegocioEstilo();
        NegocioTipo negocioEdicion = new NegocioTipo();
               

        private static int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    id = int.Parse(Request.QueryString["id"].ToString());

                    if(id != 0)
                    {
                        //Disco p/actualizar

                    }
                    else
                    {
                        //Disco nuevo
                        cargarEstilos();
                        cargarTipos();
                    }
                }
                else
                {
                    
                    cargarEstilos();
                    cargarTipos();
                }
            }            
        }

        private void cargarTipos()
        {
            List<TiposEdicion> listaEdicion = new List<TiposEdicion>();
            listaEdicion = negocioEdicion.listarTipos();
            ddlTipo.DataSource = listaEdicion;
            ddlTipo.DataValueField = "Id";
            ddlTipo.DataTextField = "Descripcion";
            ddlTipo.DataBind();
        }

        private void cargarEstilos()
        {
            List<Estilos> listaEstilos = new List<Estilos>();
            listaEstilos = negocioEstilo.listarEstilos();
            ddlEstilo.DataSource = listaEstilos;
            ddlEstilo.DataValueField = "Id";
            ddlEstilo.DataTextField = "Descripcion";
            ddlEstilo.DataBind();
        }

    }
}