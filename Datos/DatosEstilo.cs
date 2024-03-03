using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class DatosEstilo
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public List<Estilos> listaEstilos()
        {
            List<Estilos> lista = new List<Estilos>();

            using (con)
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id, Descripcion FROM ESTILOS", con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Estilos nuevo = new Estilos();
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
