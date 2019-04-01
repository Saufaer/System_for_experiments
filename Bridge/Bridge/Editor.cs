using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
namespace Bridge
{
    public partial class MainClass : MetroFramework.Forms.MetroForm
    {
        public void InitTable()
        {
            int size = 55;

            InfoTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            for (int k = 0; k < 4; k++)
            {
                InfoTable.Columns[k].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }

            for (int i = 0; i < size; i++)
            {
                InfoTable.Rows.Add(InfoData.ParameterArr[i], InfoData.ValidValuesArr[i], InfoData.DefaultValuesArr[i], InfoData.DescriptionArr[i]);
            }
            EditorTabControl.SelectedIndex = 0;
        }

        private void InfoTable_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ParNameTextBox.Text = Convert.ToString(InfoTable.Rows[e.RowIndex].Cells[0].Value);
            ValueTextBox.Text = Convert.ToString(InfoTable.Rows[e.RowIndex].Cells[2].Value);
            LabelDecription.Text = Convert.ToString(InfoTable.Rows[e.RowIndex].Cells[3].Value);
        }


        public void Search()
        {
            for (int i = 0; i < InfoTable.RowCount; i++)
            {

                InfoTable.Rows[i].Selected = false;
                for (int j = 0; j < InfoTable.ColumnCount; j++)
                {

                    if (InfoTable.Rows[i].Cells[j].Value != null)
                    {
                        if (InfoTable.Rows[i].Cells[j].Value.ToString().Contains(TextBoxSearch.Text))
                        {
                            InfoTable.Rows[i].Selected = true;
                            break;

                        }
                    }
                }

            }
        }

        public void OpenXML()
        {
            OpenFileDialog OPF = new OpenFileDialog();
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                Config_path = OPF.FileName;
            }


            if (File.Exists(Config_path))
            {
                try
                {
                    TextBoxXML.Lines = File.ReadAllLines(Config_path);
                    TextBoxPath.Text = Config_path;
                    ConfigTable.Rows.Clear();
                    DataSet ds = new DataSet();
                    ds.ReadXml(Config_path);
                    foreach (DataRow item in ds.Tables["exe"].Rows)
                    {
                        int n = -1;
                        foreach (object cell in item.ItemArray)
                        {
                            n++;
                            if (n < item.ItemArray.Length / 2)
                            {
                                ConfigTable.Rows.Add();
                                ConfigTable.Rows[n].Cells[0].Value = item["key" + n];
                                ConfigTable.Rows[n].Cells[1].Value = item["par" + n];
                            }
                        }

                    }
                }
                catch
                {
                    MessageBox.Show("Bad XML file", "Error.");
                }
            }
            else
            {
                MessageBox.Show("XML file not found.", "Error.");
            }
        }
        public void WriteConfing()
        {
            if (Config_path != "")
            {
                try
                {
                    if (File.Exists(Config_path))
                    {
                        using (StreamWriter SWriter = new StreamWriter(Config_path))
                        {
                            string start = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<exe>\n";
                            string program_name = " <Prog>" + Program_name + "</Prog>\n";
                            string body = "";
                            string end = "</exe>\n<?include somedata?>";

                            for (int i = 0; i < ConfigTable.Rows.Count - 1; i++)
                            {
                                string tagParSt = "\n  <key" + i + ">";

                                string parameter_name = ConfigTable[0, i].Value.ToString();

                                string tagParFin = "</key" + i + ">\n";

                                string tagValSt = "   <par" + i + ">";

                                string value = ConfigTable[1, i].Value.ToString();

                                string tagValFin = "</par" + i + ">\n";

                                body += tagParSt + parameter_name + tagParFin + tagValSt + value + tagValFin;
                            }
                            SWriter.Write(start + program_name + body + end);
                        }
                        TextBoxXML.Lines = File.ReadAllLines(Config_path);
                        TextBoxPath.Text = Config_path;
                    }
                    EditorTabControl.SelectedIndex = 0;
                    MessageBox.Show("XML файл успешно изменен.", "Выполнено.");
                }
                catch
                {
                    MessageBox.Show("Невозможно изменить XML файл.", "Ошибка.");
                }
            }
            else { MessageBox.Show("Not selected XML file", "Error."); }
        }

        public void CreateXML()
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|xml files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    myStream.Close();
                }

                Config_path = saveFileDialog1.FileName;
                using (StreamWriter SWriter = new StreamWriter(Config_path))
                {
                    string start = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<exe>\n";
                    string program_name = " <Prog>" + Program_name + "</Prog>\n";
                    string body = "";
                    string end = "</exe>\n<?include somedata?>";
                    SWriter.Write(start + program_name + body + end);
                }
                TextBoxXML.Lines = File.ReadAllLines(Config_path);
                TextBoxPath.Text = Config_path;
                ConfigTable.Rows.Clear();
            }
        }

        public void DeleteXML()
        {
            if (Config_path != "")
            {
                if (File.Exists(Config_path))
                {
                    File.Delete(Config_path);
                    TextBoxXML.Text = "";
                    TextBoxPath.Text = "";
                    ConfigTable.Rows.Clear();
                }
            }
            else { MessageBox.Show("Not selected XML file", "Error."); }
        }

        public void AddLinkToConf()
        {
            String value = ValueTextBox.Text;
            String parameter = ParNameTextBox.Text;

            if ((value != "") && (parameter != ""))
            {
                ConfigTable.Rows.Add(parameter, value);
            }
            else { MessageBox.Show("Key and parameter must be specified.", "Error."); }
        }

    }
}
