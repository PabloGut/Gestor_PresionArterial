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

        public static string stringAleatorio()
        {
            string strAl = Path.GetRandomFileName();
            strAl = strAl.Replace(".", ""); // Para remover el .
            return strAl;
        }
    }
}
