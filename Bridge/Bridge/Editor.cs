﻿using System;
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
        public void InitTable(MetroFramework.Controls.MetroGrid _InfoTable, Tuple<String, String, String, String>[] Array)
        {
            int size = 57;
         
            size = Array.Length;
            _InfoTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            for (int k = 0; k < 4; k++)
            {
                _InfoTable.Columns[k].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }

            for (int i = 0; i < size; i++)
            {

                // InfoTable.Rows.Add(InfoData.ParameterArr[i], InfoData.ValidValuesArr[i], InfoData.DefaultValuesArr[i], InfoData.DescriptionArr[i]);
                _InfoTable.Rows.Add(Array[i].Item1, Array[i].Item2, Array[i].Item3, Array[i].Item4);
            }
            EditorTabControl.SelectedIndex = 0;
            _InfoTable.CurrentCell = _InfoTable[0, 0];
            _InfoTable.Rows[0].Cells[0].Selected = false;
        }

        private void metroGrid3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.ColumnIndex != -1) && (e.RowIndex != -1))
            {
                ParNameTextBox.Text = Convert.ToString(metroGrid3.Rows[e.RowIndex].Cells[0].Value);
                ValueTextBox.Text = Convert.ToString(metroGrid3.Rows[e.RowIndex].Cells[2].Value);
            }
        }

        private void metroGrid3_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.ColumnIndex != -1) && (e.RowIndex != -1))
            {
                AddLinkToConf();
              
            }
        }

        private void metroGrid1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.ColumnIndex != -1) && (e.RowIndex != -1))
            {
                ParNameTextBox.Text = Convert.ToString(metroGrid1.Rows[e.RowIndex].Cells[0].Value);
                ValueTextBox.Text = Convert.ToString(metroGrid1.Rows[e.RowIndex].Cells[2].Value);
            }
        }

        private void metroGrid1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.ColumnIndex != -1) && (e.RowIndex != -1))
            {
                AddLinkToConf();
            }
        }

        private void metroGrid2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.ColumnIndex != -1) && (e.RowIndex != -1))
            {
                ParNameTextBox.Text = Convert.ToString(metroGrid2.Rows[e.RowIndex].Cells[0].Value);
                ValueTextBox.Text = Convert.ToString(metroGrid2.Rows[e.RowIndex].Cells[2].Value);
            }
        }

        private void metroGrid2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.ColumnIndex != -1) && (e.RowIndex != -1))
            {
                AddLinkToConf();
            }
        }

       

        private void InfoTable_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if((e.ColumnIndex != -1)&&(e.RowIndex != -1))
            {
                ParNameTextBox.Text = Convert.ToString(InfoTable.Rows[e.RowIndex].Cells[0].Value);
                ValueTextBox.Text = Convert.ToString(InfoTable.Rows[e.RowIndex].Cells[2].Value);

                if ((ParNameTextBox.Text == "-libPath") || (ParNameTextBox.Text == "-libConfigPath") || (ParNameTextBox.Text == "-FirstPointFilePath"))
                {
                    metroButton3.Enabled = true;
                }
                else
                {
                    metroButton3.Enabled = false;
                }
            }
           
        }

        private void InfoTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.ColumnIndex != -1) && (e.RowIndex != -1))
            {
                AddLinkToConf();
               
            }
        }

        private void metroGrid4_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.ColumnIndex != -1) && (e.RowIndex != -1))
            {
                ParNameTextBox.Text = Convert.ToString(metroGrid4.Rows[e.RowIndex].Cells[0].Value);
                ValueTextBox.Text = Convert.ToString(metroGrid4.Rows[e.RowIndex].Cells[2].Value);
            }
        }

        private void metroGrid4_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.ColumnIndex != -1) && (e.RowIndex != -1))
            {
                AddLinkToConf();
            }
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

        public void ChoseFile()
        {
            string path = "";
            string PathDir = "";
            OpenFileDialog OPF = new OpenFileDialog();
            
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                path = OPF.FileName;
                PathDir = Path.GetDirectoryName(path);
                if ((Directory.GetCurrentDirectory() == PathDir))
                {
                    ValueTextBox.Text = System.IO.Path.GetFileName(@path);
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Файл должен лежть в одной директории с examin.exe", "Оповещение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
           
            
           
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
                            if (n < (item.ItemArray.Length / 2 ))
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
                    MetroFramework.MetroMessageBox.Show(this, "Некорректный XML файл.", "Оповещение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "XML файл не найден.", "Оповещение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (TextBoxPath.Text != "")
            {
                WriteConf.Enabled = true;
                AddLink.Enabled = true;
            }
        }

        public void Writter(String _gConfig_path)
        {
            
            string start = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<exe>\n";
            string program_name = " <Prog>" + gProgram_name + "</Prog>\n";
            string body = "";
            string end = "\n</exe>\n<?include somedata?>";

            for (int i = 0; i < ConfigTable.Rows.Count -1; i++)
            {
                string tagParSt = "\n  <key" + i + ">";

                string parameter_name = ConfigTable[0, i].Value.ToString();

                string tagParFin = "</key" + i + ">\n";

                string tagValSt = "   <par" + i + ">";

                string value = ConfigTable[1, i].Value.ToString();

                string tagValFin = "</par" + i + ">\n";

                if ((parameter_name == "-Separator") && ((value == ";") || (value == ".")))
                {
                    MetroFramework.MetroMessageBox.Show(this, "Недоступное значение Separator \"" + value + "\"", "Оповещение.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    value = "_";
                }
                
                
                    body += tagParSt + parameter_name + tagParFin + tagValSt + value + tagValFin;
                

               
            }
            System.IO.File.AppendAllText(_gConfig_path, start + program_name + body + end);
      

        }
        public void WriteConfing()
        {
            if (gConfig_path != "")
            {
                try
                {
                    if (File.Exists(gConfig_path))
                    {
                     System.IO.File.WriteAllText(@gConfig_path, string.Empty);
                     Writter(gConfig_path);
                     TextBoxXML.Lines = File.ReadAllLines(gConfig_path);
                     TextBoxPath.Text = gConfig_path;
                    }
                    EditorTabControl.SelectedIndex = 0;
                    if (ConfigTable.Rows.Count > 1)
                    {
                        MessageBox.Show(this, "XML файл успешно изменен.", "Выполнено.");
                    }

                }
                catch
                {
                    MetroFramework.MetroMessageBox.Show(this, "Невозможно изменить XML файл.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "XML файл не выбран", "Оповещение.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (TextBoxPath.Text != "")
            {
                WriteConf.Enabled = true;
                AddLink.Enabled = true;
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
     
                    string start = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<exe>\n";
                    string program_name = " <Prog>" + gProgram_name + "</Prog>\n";
                    string body = "";
                    string end = "\n</exe>\n<?include somedata?>";
                    System.IO.File.AppendAllText(gConfig_path, start + program_name + body + end);
            
                TextBoxXML.Lines = File.ReadAllLines(gConfig_path);
                TextBoxPath.Text = gConfig_path;
                ConfigTable.Rows.Clear();
            }
            if (TextBoxPath.Text != "")
            {
                WriteConf.Enabled = true;
                AddLink.Enabled = true;
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

                string start = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<exe>\n";
                string program_name = " <Prog>" + gProgram_name + "</Prog>\n";
                string body = "";
                string end = "\n</exe>\n<?include somedata?>";

                System.IO.File.AppendAllText(FinalPath, start + program_name + body + end);

            
            TextBoxXML.Lines = File.ReadAllLines(FinalPath);
            TextBoxPath.Text = FinalPath;
            ConfigTable.Rows.Clear();

            if (TextBoxPath.Text != "")
            {
                WriteConf.Enabled = true;
                AddLink.Enabled = true;
            }
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
                MetroFramework.MetroMessageBox.Show(this, "Нет выбранного XML файла", "Оповещение.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (TextBoxPath.Text == "")
            {
                WriteConf.Enabled = false;
                AddLink.Enabled = false;
            }
        }

        public void AddLinkToConf()
        {
            String value = ValueTextBox.Text;
            String parameter = ParNameTextBox.Text;
            if ((parameter == "-Separator") && ((value == ";")||(value == ".")))
            {
                MetroFramework.MetroMessageBox.Show(this, "Недоступное значение Separator \""+value+"\"", "Оповещение.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                value = "_";
                ValueTextBox.Text = "_";
            }
            if ((value != "") && (parameter != ""))
            {
                ConfigTable.Rows.Add(parameter, value);
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Параметр и его значение должны быть указаны.", "Оповещение.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ConfSaveAs()
        {
            if (File.Exists(gConfig_path))
            {
              
                SaveFileDialog SF = new SaveFileDialog();

                
                SF.FileName = "";
                SF.Filter = "xml files (*.xml)|*.xml";
                if (SF.ShowDialog() == DialogResult.OK)
                {
                    if (SF.FileName != "")
                    {
                        File.Delete(SF.FileName);
                    }
                        try
                        {
                            if (File.Exists(gConfig_path))
                            {

                                gConfig_path = SF.FileName;

                                Writter(gConfig_path);

                            }
                            MessageBox.Show(this, "XML файл успешно сохранен.", "Выполнено.");
                        }
                        catch
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Невозможно сохранить XML файл.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    
                
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Нет выбранного XML файла", "Оповещение.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}
