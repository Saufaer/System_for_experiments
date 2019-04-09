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
            int size = 57;

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

            InfoTable.CurrentCell = InfoTable[0, 0];
            InfoTable.Rows[0].Cells[0].Selected = false;
        }

        private void InfoTable_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if((e.ColumnIndex != -1)&&(e.RowIndex != -1))
            {
                ParNameTextBox.Text = Convert.ToString(InfoTable.Rows[e.RowIndex].Cells[0].Value);
                ValueTextBox.Text = Convert.ToString(InfoTable.Rows[e.RowIndex].Cells[2].Value);
            }
           
        }

        private void InfoTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.ColumnIndex != -1) && (e.RowIndex != -1))
            {
                AddLinkToConf();
            }
        }

        private void ComboBoxProgName_SelectedIndexChanged(object sender, EventArgs e)
        {
            gProgram_name = ComboBoxProgName.SelectedItem.ToString();
        }
        public int i = 0;
        public void Search(MetroFramework.Controls.MetroGrid Table, MetroFramework.Controls.MetroTextBox _TextBoxSearch,MetroFramework.Controls.MetroLabel ResLabel)
        {
                int count = 0;
                for (int k = 0; k < Table.RowCount; k++)
                {
                    for (int j = 0; j < Table.ColumnCount; j++)
                    {
                        if (Table.Rows[k].Cells[j].Value != null)
                        {
                        if(Table.Rows[k].Cells[j].Value.ToString().IndexOf(_TextBoxSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                           // if (InfoTable.Rows[k].Cells[j].Value.ToString().Contains(TextBoxSearch.Text))
                            {
                                count++;
                                break;
                            }
                        }
                    }
                }
                ResLabel.Text = "Найдено соответствий: " + count.ToString();


            for (; i < Table.RowCount ;)
            {
                for (int j = 0; j < Table.ColumnCount; j++)
                {
                    if (Table.Rows[i].Cells[j].Value != null)
                    {
                        if (Table.Rows[i].Cells[j].Value.ToString().IndexOf(_TextBoxSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            Table.CurrentCell = Table[0, i];
                            if (i < Table.RowCount - 2)
                            {
                                i++;
                            }
                            else
                            {
                                i = 0;
                            }
                            return;
                        }
                    }
                }
                i++;
            }
            i = 0;
        }

        public void OpenXML(bool needDialog)
        {
            if (needDialog)
            {
                OpenFileDialog OPF = new OpenFileDialog();
                if (OPF.ShowDialog() == DialogResult.OK)
                {
                    gConfig_path = OPF.FileName;
                }
            }

            if (File.Exists(gConfig_path))
            {
                try
                {
                    TextBoxXML.Lines = File.ReadAllLines(gConfig_path);
                    TextBoxPath.Text = gConfig_path;
                    ConfigTable.Rows.Clear();
                    DataSet ds = new DataSet();
                    ds.ReadXml(gConfig_path);
                    foreach (DataRow item in ds.Tables["exe"].Rows)
                    {
                        int n = -1;
                        foreach (object cell in item.ItemArray)
                        {
                            n++;
                            if (n < (item.ItemArray.Length / 2))
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

        public void Writter(StreamWriter SW)
        {
            string start = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<exe>\n";
            string program_name = " <Prog>" + gProgram_name + "</Prog>\n";
            string body = "";
            string end = "\n</exe>\n<?include somedata?>";

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
            SW.Write(start + program_name + body + end);
            SW.Close();

        }
        public void WriteConfing()
        {
            if (gConfig_path != "")
            {
                try
                {
                    if (File.Exists(gConfig_path))
                    {
                        using (StreamWriter SW = new StreamWriter(gConfig_path))
                        {
                            Writter(SW);
                        }
                        TextBoxXML.Lines = File.ReadAllLines(gConfig_path);
                        TextBoxPath.Text = gConfig_path;
                    }
                    EditorTabControl.SelectedIndex = 0;
                    MessageBox.Show(this, "XML файл успешно изменен.", "Выполнено.");

                }
                catch
                {
                    MetroFramework.MetroMessageBox.Show(this, "Невозможно изменить XML файл.", "Ошибка.");
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Not selected XML file", "Error.");
            }
        }

        public void CreateXML()
        {
            Stream myStream;
            SaveFileDialog SF = new SaveFileDialog();
            SF.Filter = "xml files (*.xml)|*.xml";
            SF.FilterIndex = 2;
            SF.RestoreDirectory = true;

            if (SF.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = SF.OpenFile()) != null)
                {
                    myStream.Close();
                }
                gConfig_path = SF.FileName;
                using (StreamWriter SWriter = new StreamWriter(gConfig_path))
                {
                    string start = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<exe>\n";
                    string program_name = " <Prog>" + gProgram_name + "</Prog>\n";
                    string body = "";
                    string end = "\n</exe>\n<?include somedata?>";
                    SWriter.Write(start + program_name + body + end);
                }
                TextBoxXML.Lines = File.ReadAllLines(gConfig_path);
                TextBoxPath.Text = gConfig_path;
                ConfigTable.Rows.Clear();
            }
        }

        public void CreateXMLDefault()
        {

            String currentPath = Directory.GetCurrentDirectory();

            if (!Directory.Exists(Path.Combine(currentPath, "Configurations")))
            {
                Directory.CreateDirectory(Path.Combine(currentPath, "Configurations"));
            }

            String date = DateTime.Now.ToString("[HH-mm-ss]_dd.MM.yy");
            String OutFileName = "Configure" + date;
            String FinalPath = currentPath + "\\Configurations" + "\\" + OutFileName + ".xml";
            gConfig_path = FinalPath;
            using (StreamWriter file = new StreamWriter(FinalPath))
            {
                string start = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<exe>\n";
                string program_name = " <Prog>" + gProgram_name + "</Prog>\n";
                string body = "";
                string end = "\n</exe>\n<?include somedata?>";
                file.Write(start + program_name + body + end);

                file.Close();
            }
            TextBoxXML.Lines = File.ReadAllLines(FinalPath);
            TextBoxPath.Text = FinalPath;
            ConfigTable.Rows.Clear();
        }

        public void DeleteXML()
        {
            if (gConfig_path != "")
            {
                if (File.Exists(gConfig_path))
                {
                    File.Delete(gConfig_path);
                    TextBoxXML.Text = "";
                    TextBoxPath.Text = "";
                    ConfigTable.Rows.Clear();
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Нет выбранного XML файла", "Ошибка.");
            }
        }

        public void AddLinkToConf()
        {
            String value = ValueTextBox.Text;
            String parameter = ParNameTextBox.Text;
            if ((value != "") && (parameter != ""))
            {
                ConfigTable.Rows.Add(parameter, value);
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Key and parameter must be specified.", "Error.");
            }
        }
        public void SaveAs()
        {
            if (File.Exists(gConfig_path))
            {
                StreamWriter SW;
                SaveFileDialog SF = new SaveFileDialog();
                SF.FileName = gConfig_path;
                SF.FileName = "";
                SF.Filter = "xml files (*.xml)|*.xml";
                if (SF.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (File.Exists(gConfig_path))
                        {
                            using (SW = new StreamWriter(SF.FileName))
                            {
                                gConfig_path = SF.FileName;
                                Writter(SW);
                            }
                        }
                        MessageBox.Show(this, "XML файл успешно сохранен.", "Выполнено.");
                    }
                    catch
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Невозможно сохранить XML файл.", "Ошибка.");
                    }
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Нет выбранного XML файла", "Ошибка.");
            }
        }


    }
}
