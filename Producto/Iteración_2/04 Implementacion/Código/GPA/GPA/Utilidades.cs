using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
            combo.DataSource = lista;
            combo.ValueMember = valueMember;
            combo.DisplayMember = displayMember;
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
    }
}
