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
    public partial class frmAddEditParams : MetroFramework.Forms.MetroForm
    {
        public frmAddEditParams()
        {
            InitializeComponent();
        }
        string parameter;
        string value;
        System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["Form1"];

        //ComboBox
        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            parameter = metroComboBox1.Text;
        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            value = metroComboBox2.Text;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

            ((Form1)f).metroGrid1.Rows.Add(parameter, value);

        }
    }
}
