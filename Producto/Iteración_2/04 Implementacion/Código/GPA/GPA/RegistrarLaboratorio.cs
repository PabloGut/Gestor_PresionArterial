using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using Entidades.Clases;
using GPA.Manejadores;
namespace GPA
{
    public partial class RegistrarLaboratorio : Form
    {
        ManejadorRegistrarLaboratorio manejadorRegistrarLaboratorio;
        public RegistrarLaboratorio()
        {
            InitializeComponent();
        }

        private void btnAgregarInstitucion_Click(object sender, EventArgs e)
        {
            RegistrarInstitucion ri = new RegistrarInstitucion();
            ri.ShowDialog();
            cargarComboInstituciones();
        }
        public void cargarComboInstituciones()
        {
            cboInstitucion.DataSource = InstitucionDAO.buscarInstituciones();
            cboInstitucion.ValueMember = "id_institucion";
            cboInstitucion.DisplayMember = "nombre";
        }
        private void RegistrarLaboratorio_Load(object sender, EventArgs e)
        {
            manejadorRegistrarLaboratorio = new ManejadorRegistrarLaboratorio();
            cargarComboInstituciones();
            cargarComboMetodosAnalisisLaboratorio();
        }
        private void btnAgregarMetodoAnalisisLaboratorio_Click(object sender, EventArgs e)
        {
            ActualizarMetodoAnalisisLaboratorio am = new ActualizarMetodoAnalisisLaboratorio();
            am.ShowDialog();
            cargarComboMetodosAnalisisLaboratorio();
        }
        public void cargarComboMetodosAnalisisLaboratorio()
        {
            List<MetodoAnalisisLaboratorio> metodos = manejadorRegistrarLaboratorio.obtenerMetodosAnalisisLaboratorio();
            Utilidades.cargarCombo(cboMetodoAnalisisLaboratorio, metodos, "id_metodo", "nombre");
        }
    }
}
