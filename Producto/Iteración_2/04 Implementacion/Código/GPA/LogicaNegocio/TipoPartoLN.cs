using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAO;
using Entidades.Clases;

namespace LogicaNegocio
{
    public class TipoPartoLN
    {
        public static List<TipoParto> mostrarTiposDeParto()
        {
            return TipoPartoDAO.mostrarTiposDeParto();
        }
    }
}
