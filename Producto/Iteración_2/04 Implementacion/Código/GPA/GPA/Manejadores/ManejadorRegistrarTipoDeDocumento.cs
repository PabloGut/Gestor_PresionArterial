using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;
using System.Data;

namespace GPA.Manejadores
{
    public class ManejadorRegistrarTipoDeDocumento
    {
        private RegistrarTipoDeDocumento pantalla;
        private List<TipoDocumento> tiposDocumento;

        public void registrarTipoDeDocumento(RegistrarTipoDeDocumento pantallaRtd)
        {
            pantalla = pantallaRtd;
            mostrarTiposDocumento();
        }

        public void mostrarTiposDocumento()
        {
            tiposDocumento=TipoDocumentoDAO.BuscarTiposDoc();
            pantalla.presentarTiposDocumento(tiposDocumento);
        }

        public void nombreYDescripcionIngresados(int id, string nombre, string descripcion)
        {
            if (id == 0) 
            { 
                crearTipoDocumento(nombre, descripcion);
            }
            else
            {
                modificarTipoDocumento(id, nombre, descripcion);
            }
        }

        public void crearTipoDocumento(string nombre, string descripcion)
        {
            TipoDocumentoDAO.insertarTipoDoc(nombre, descripcion);
            finCU("Tipo de Documento agregado correctamente");
        }

        public void modificarTipoDocumento(int id, string nombre, string descripcion)
        {
            TipoDocumentoDAO.actualizarTipoDoc(id, nombre, descripcion);
            finCU("Tipo de Documento modificado correctamente");
        }

        public void borrarTipoDocumento(int id)
        {
            TipoDocumentoDAO.eliminarTipoDoc(id);
            finCU("Tipo de Documento borrado correctamente");
        }

        public void finCU(string mensaje)
        {
            pantalla.informarUsuarioFinCU(mensaje);
        }
    }

}
