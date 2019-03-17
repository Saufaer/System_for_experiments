using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bridge
{
    public partial class CreateLink : MetroFramework.Forms.MetroForm
    {
        public CreateLink()
        {
            InitializeComponent();
        }
        string parameter;
        string value;
        string[] strArr = new string[3] {
            "Число точек испытания, порождаемых методом за одну итерацию. Допустимые значения >0.",
            "Надежность метода. Допустимые значения >1.",
            "Значение Epsilon для каждого из уровней дерева процессов. Допустимые значения >0." };
        System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["Form1"];

        //ComboBox
        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = metroComboBox1.SelectedIndex;
            //metroToolTip1.SetToolTip(metroComboBox1, strArr[i]);
            metroTextBox2.Text = strArr[i];
            parameter = metroComboBox1.Text;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            value = metroTextBox1.Text;
           
            ((Form1)f).metroGrid1.Rows.Add(parameter, value);

        }

    }
}
