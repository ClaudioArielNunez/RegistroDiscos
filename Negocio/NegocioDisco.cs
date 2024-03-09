using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
using System.Data.SqlClient;

namespace Negocio
{
    public class NegocioDisco
    {
        DatosDisco disco = new DatosDisco();

        public List<Disco> lista()
        {
            try
            {
                return disco.listaDisco();
            }
            catch (Exception ex)
            {

                throw ex; 
            }
        }

        public bool altaDisco(Disco nuevo)
        {
            try
            {
                return disco.crearDisco(nuevo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Disco> listaFiltrada(string campo, string criterio, string estado, string filtro = "")
        {
            try
            {
                return disco.Filtrar(campo,criterio,filtro,estado);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
