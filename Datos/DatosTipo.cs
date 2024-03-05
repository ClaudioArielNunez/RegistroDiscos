using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;

namespace Datos
{
    public class DatosTipo
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        List<TiposEdicion> lista = new List<TiposEdicion>();
        public List<TiposEdicion> listar()
        {
            using (con)
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id, Descripcion FROM TiposEdicion", con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        TiposEdicion nuevo = new TiposEdicion();
                        nuevo.Id = (int)dr["Id"];
                        nuevo.Descripcion = (string)dr["Descripcion"];
                        lista.Add(nuevo);
                    }
                    return lista; 
                }
            }
            

            
        }

    }
}
