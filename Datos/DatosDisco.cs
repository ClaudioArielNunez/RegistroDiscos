using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;

namespace Datos
{
    public class DatosDisco
    {

        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public List<Disco> listaDisco()
        {
            List<Disco> lista = new List<Disco>();
            using (con)
            {
                using (SqlCommand cmd = new SqlCommand("storedListarDiscos", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Disco nuevo = new Disco();
                        nuevo.Id = int.Parse(dr["Id"].ToString());
                        nuevo.Titulo = dr["Titulo"].ToString();
                        nuevo.FechaLanzamiento = (DateTime)dr["FechaLanzamiento"];
                        nuevo.CantidadCanciones = (int)dr["CantidadCanciones"];
                        nuevo.UrlImagenTapa = dr["UrlImagenTapa"].ToString();
                        nuevo.Estado = (bool)dr["Estado"];

                        nuevo.Estilo = new Estilos();
                        nuevo.Estilo.Id = (int)dr["IdEstilo"];
                        nuevo.Estilo.Descripcion = dr["Estilo"].ToString();

                        nuevo.TipoEdicion = new TiposEdicion();
                        nuevo.TipoEdicion.Id = (int)dr["IdTipoEdicion"];
                        nuevo.TipoEdicion.Descripcion = dr["Edicion"].ToString();

                        lista.Add(nuevo);
                    }
                    return lista;
                }
            }


                
        }

        public bool crearDisco(Disco nuevo)
        {
            bool respuesta = false;
            using (con)
            {
                using (SqlCommand cmd = new SqlCommand("storedAltaDisco",con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@titulo",nuevo.Titulo);
                    cmd.Parameters.AddWithValue("@fecha",nuevo.FechaLanzamiento);
                    cmd.Parameters.AddWithValue("@canciones",nuevo.CantidadCanciones);
                    cmd.Parameters.AddWithValue("@imagen",nuevo.UrlImagenTapa);
                    cmd.Parameters.AddWithValue("@estilo", nuevo.Estilo.Id);
                    cmd.Parameters.AddWithValue("@edicion", nuevo.TipoEdicion.Id);

                    con.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if(filasAfectadas > 0)
                    {
                        respuesta = true;
                    }
                    //con.Close();
                    return respuesta;
                
                }
            }
        }

        public List<Disco> Filtrar(string campo, string criterio, string filtro, string estado)
        {
            List<Disco> ListaFiltrada = new List<Disco>();

            
            string consulta = "SELECT D.Id, Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, " +
                              "E.Id, E.Descripcion AS Estilo, T.Id, T.Descripcion as Edicion\r\nfrom " +
                              "DISCOS AS D INNER JOIN ESTILOS AS E\r\nON D.IdEstilo = E.Id\r\nINNER JOIN " +
                              "TIPOSEDICION AS T\r\nON D.IdTipoEdicion = T.Id AND ";
            if (campo == "Canciones")
            {
                switch (criterio)
                {
                    case "Igual a":
                        consulta += " CantidadCanciones = " + 12; //TODO
                        break;
                    case "Mayor a":
                        consulta += " CantidadCanciones > " + filtro;
                        break;
                    default:
                        consulta += " CantidadCanciones < " + filtro;
                        break;
                }
            }

            //if (estado == "Activo")
            //{
            //    consulta += " AND Estado = 1";
            //}
            //else if (estado == "Inactivo")
            //{
            //    consulta += " AND Estado = 0";
            //}
            //else
            //{
            //    consulta += "";
            //}

            using (con)
            {
                using (SqlCommand cmd = new SqlCommand(consulta, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Disco nuevo = new Disco();
                        nuevo.Id = int.Parse(dr["Id"].ToString());
                        nuevo.Titulo = dr["Titulo"].ToString();
                        nuevo.FechaLanzamiento = Convert.ToDateTime(dr["FechaLanzamiento"]);
                        nuevo.CantidadCanciones = int.Parse(dr["CantidadCanciones"].ToString());
                        nuevo.UrlImagenTapa = dr["UrlImagenTapa"].ToString();
                        //nuevo.Estado = bool.Parse(dr["Estado"].ToString());

                        nuevo.Estilo = new Estilos();
                        nuevo.Estilo.Id = int.Parse(dr["Id"].ToString());
                        nuevo.Estilo.Descripcion = dr["Estilo"].ToString();

                        nuevo.TipoEdicion = new TiposEdicion();
                        nuevo.TipoEdicion.Id = int.Parse(dr["Id"].ToString());
                        nuevo.TipoEdicion.Descripcion = dr["Edicion"].ToString();

                        ListaFiltrada.Add(nuevo);
                    }
                    return ListaFiltrada;
                }
            }
        }
    }
}
