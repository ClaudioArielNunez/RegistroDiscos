using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using System.Collections;
using Negocio;

namespace GrillaDatos
{
    public partial class Inicio : System.Web.UI.Page
    {
        //NegocioDisco negocio = new NegocioDisco();//TENER ESTA LINEA AQUI ME DABA ERROR
        protected void Page_Load(object sender, EventArgs e)
        {
            NegocioDisco negocio = new NegocioDisco();
            List<Disco> Lista = negocio.lista();
            //Session.Add("ListaDiscos", negocio.lista());
            dgvLista.DataSource = Lista;
            dgvLista.DataBind();
            
            
            //lista prueba de gridview
            //List<Auto> Lista = new List<Auto>()
            //{
            //    new Auto()
            //    {
            //        Numero = 1,
            //        Marca = "Ford",
            //        Lanzamiento = new DateTime(2019, 10, 22, 12, 30,55),
            //        Color = "Blanco"
            //    },
            //    new Auto()
            //    {
            //        Numero = 2,
            //        Marca = "Chevrolet",
            //        Lanzamiento = DateTime.Now,
            //        Color = "Negro"
            //    },
            //    new Auto()
            //    {
            //        Numero = 3,
            //        Marca = "Ferrari",
            //        Lanzamiento = DateTime.Today,
            //        Color = "Rojo"
            //    }
            //};


        }

        protected void dgvLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvLista.PageIndex = e.NewPageIndex;
            dgvLista.DataBind();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Formulario.aspx?id=0");
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            NegocioDisco negocio = new NegocioDisco();
            List<Disco> listaDisco = negocio.lista();
            List<Disco> listaFiltrada = listaDisco.FindAll(x => x.Titulo.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvLista.DataSource= listaFiltrada;
            dgvLista.DataBind();
        }
    }
    //public class Auto
    //{
    //    public int Numero { get; set; }
    //    public string Marca { get; set; }
    //    public DateTime Lanzamiento { get; set; }
    //    public string Color { get; set; }
    //}
}