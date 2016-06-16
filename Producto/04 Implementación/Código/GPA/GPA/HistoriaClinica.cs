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
    public partial class HistoriaClinica : Form
    {
        public HistoriaClinica()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El paciente posee una historia clínica. \nNo es posible continuar con el registro de una nueva historia clínica.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se cancela el registro de la nueva historia clínica.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            MessageBox.Show("Se registró la creación de la historia clínica correctamente!!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("Desea cancelar el registro de la historia clínica?", "Atención", MessageBoxButtons.OKCancel, MessageBoxIcon.Information); 

        }
    }
}
