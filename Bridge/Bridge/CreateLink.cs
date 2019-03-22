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
        int size = 55;
        Info InfoData = new Info();
        public CreateLink()
        {
            InitializeComponent();
            InfoTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            for (int k = 0;k<4;k++)
            {
                InfoTable.Columns[k].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }

            for (int i=0;i < size;i++)
            {
                InfoTable.Rows.Add(InfoData.ParameterArr[i], InfoData.ValidValuesArr[i], InfoData.DefaultValuesArr[i], InfoData.DescriptionArr[i]); }
        }
        string parameter;
        string value;

        System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["Form1"];

        
        private void metroButton1_Click(object sender, EventArgs e)
        {
            value = ValueTextBox.Text;
            parameter = ParNameTextBox.Text;

            if ((value!="")&&(parameter!=""))
                    {
                ((Form1)f).ConfigTable.Rows.Add(parameter, value);
            }
            else { MessageBox.Show("Key and parameter must be specified.", "Error."); }
        }



        private void InfoTable_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ParNameTextBox.Text = Convert.ToString(InfoTable.Rows[e.RowIndex].Cells[0].Value);
            ValueTextBox.Text = Convert.ToString(InfoTable.Rows[e.RowIndex].Cells[2].Value);
            //DescriptTextBox.Text = Convert.ToString(InfoTable.Rows[e.RowIndex].Cells[3].Value);
            metroLabel5.Text = Convert.ToString(InfoTable.Rows[e.RowIndex].Cells[3].Value);
        }
    }
}
