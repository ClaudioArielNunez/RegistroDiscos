using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace GrillaDatos
{
    public partial class Presentacion : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public List<Disco> lista = new List<Disco>();
        NegocioDisco negocioDisco = new NegocioDisco();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            lista = negocioDisco.lista();
            
            
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio.aspx");
        }
    }
}