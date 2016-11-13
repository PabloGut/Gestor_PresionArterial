using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace GPA
{
    public class Utilidades
    {
        public static void limpiarLosControles(Control form)
        {
            foreach (Control control in form.Controls)
            {
                if (control.Controls.Count>0)
                {
                    limpiarLosControles(control);
                }

                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = null;
                }
                
                if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    if (comboBox.Items.Count > 0)
                        comboBox.SelectedIndex = 0;
                }

                if (control is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)control;
                    checkBox.Checked = false;
                }

                if (control is ListBox)
                {
                    ListBox listBox = (ListBox)control;
                    listBox.ClearSelected();
                }
            }
        }

        public static void deshabilitarLosControles(Control form)
        {
            foreach (Control control in form.Controls)
            {
                deshabilitarLosControles(control);
                if (control is ContainerControl) { } else { control.Enabled = false; }
            }
        }

        public static string stringAleatorio()
        {
            string strAl = Path.GetRandomFileName();
            strAl = strAl.Replace(".", ""); // Para remover el .
            return strAl;
        }

        public static void cargarCombo<T>(ComboBox combo, List<T> lista, string valueMember, string displayMember)
        {
            combo.ValueMember = valueMember;
            combo.DisplayMember = displayMember;
            combo.DataSource = lista;
        }

        public static void agregarColumnaAntecedentesMorbidos(DataGridView dgv)
        {
            string[] nombreColumnasAntecedenteMorbido = new string[6] { "Fecha de registro","Tipo", "Nombre", "Tratamiento", "Evolución", "Cantidad de tiempo en que ocurrió" };


            for (int i = 0; i < nombreColumnasAntecedenteMorbido.Length; i++)
            {
                DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn();
                columna.HeaderText = nombreColumnasAntecedenteMorbido[i];
                columna.Width = 200;
                dgv.Columns.Add(columna);
            }
        }

        public static void mostrarFilaNoSeEncontraronResultados(DataGridView dgv)
        {
            dgv.DataSource = null;
            dgv.Refresh();

            DataGridViewColumn columna = new DataGridViewTextBoxColumn();
            columna.Width = 500;
            dgv.Columns.Add(columna);

            DataGridViewRow fila = new DataGridViewRow();

            dgv.Rows.Add(fila);

            dgv.Rows[0].Cells[0].Value = "No se encontraron resultados";
        }

        public static void presentarDatosEnDataGridView(DataTable dt, DataGridView dgv)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                if (dgv.Columns.Count > 0)
                {
                    dgv.Columns.Clear();
                }
                dgv.DataSource = dt;
            }
            else
            {
                if (dgv.Columns.Count > 0)
                {
                    dgv.Columns.Clear();
                }
                Utilidades.mostrarFilaNoSeEncontraronResultados(dgv);
            }
        }

        public static void agregarColumnasDataGridView(DataGridView dgv, List<String> nombreColumnas)
        {
            for (int i = 0; i < nombreColumnas.Count ; i++)
            {
                DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn();
                columna.HeaderText = nombreColumnas[i];
                columna.Width = 200;
                dgv.Columns.Add(columna);
            }
        }
    }
}
