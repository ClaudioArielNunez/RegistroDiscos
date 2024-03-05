using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class NegocioTipo
    {
        DatosTipo datos = new DatosTipo();
        List<TiposEdicion > listaEdicion = new List<TiposEdicion> ();

        public List<TiposEdicion> listarTipos()
        {
            try
            {
                return datos.listar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
