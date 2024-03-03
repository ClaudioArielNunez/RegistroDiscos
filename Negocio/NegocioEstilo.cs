using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using Datos;
using System.Data.SqlClient;
using System.Configuration;

namespace Negocio
{
    public class NegocioEstilo
    {
        DatosEstilo datos = new DatosEstilo();

        public List<Estilos> listarEstilos()
        {
            try
            {
                return datos.listaEstilos();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
