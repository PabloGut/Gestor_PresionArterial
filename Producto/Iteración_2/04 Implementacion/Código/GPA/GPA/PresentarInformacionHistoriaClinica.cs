using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPA
{
    public partial class frmInformacionHistoriaClinica : Form
    {
        public frmInformacionHistoriaClinica(string cadena)
        {
            InitializeComponent();
            txtInfoHc.Text = cadena;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
