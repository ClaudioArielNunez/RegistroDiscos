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
    }
}
