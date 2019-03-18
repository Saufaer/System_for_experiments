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
        int size = 9;
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
                InfoTable.Rows.Add(ParameterArr[i], ValidValuesArr[i], DefaultValuesArr[i], DescriptionArr[i]); }
        }
        string parameter;
        string value;


        string[] ParameterArr = new string[9]
        {
"-NumPoints",
"-StepPrintMessages",
"-TypeMethod",
"-TypeCalculation",
"-TypeProcess",
"-NumThread",
"-SizeInBlock",
"-IsPrintFile",
"-Dimension"
        };
        string[] ValidValuesArr = new string[9]
        {
">0                                                      ",
">0                                                      ",
"перечисление ETypeMethod \r\n или число от 0 до 8       ",
"перечисление ETypeCalculation \r\n или число от 0 до 2  ",
"перечисление ETypeProcess \r\n или значение от 0 до 2   ",
">0                                                      ",
">0                                                      ",
"0|1 или false|true                                      ",
">0                                                      "
        };
        string[] DefaultValuesArr = new string[9] {
"1",
"1000",
"StandartMethod",
"OMP",
"SynchronousProces",
"1",
"32",
"false",
"берется из задачи"
        };
        string[] DescriptionArr = new string[9] {
   " число точек испытания, порождаемых \r\n методом за одну итерацию                          ",
   " через сколько итераций печатать \r\n в консоли сообщение о текущем количестве итераций    ",
   " тип используемого метода                                                                  ",
   " тип вычислительного ресурса,\r\n используемого для проведения испытаний                   ",
   " тип процесса                                                                              ",
   " число используемых потоков                                                                ",
   " размер CUDA блока                                                                         ",
   " печатать отчет в файл                                                                     ",
   " размерность исходной задачи                                                               "
   };
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
            DescriptTextBox.Text = Convert.ToString(InfoTable.Rows[e.RowIndex].Cells[3].Value);
        }
    }
}
