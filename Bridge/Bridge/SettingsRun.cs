using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace Bridge
{
    public partial class SettingsRun : MetroFramework.Forms.MetroForm
    {
        public DataGridViewCellEventArgs eSet = null;
        public string ConfigFullName = "";
        public SettingsRun(DataGridViewCellEventArgs _e, string _ConfigFullName)
        {
            InitializeComponent();
            eSet = _e;
            ConfigFullName = _ConfigFullName;
            CreateSettingsTable(SettingsConfigTable,ConfigFullName);
        }
        System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["MainClass"];
        public void CreateSettingsTable(MetroFramework.Controls.MetroGrid Table ,string _ConfigFullName)
        {
            

                 if (File.Exists(_ConfigFullName))
            {
                try
                {

                    Table.Rows.Clear();
                    DataSet ds = new DataSet();
                    ds.ReadXml(_ConfigFullName);
                    foreach (DataRow item in ds.Tables["exe"].Rows)
                    {
                        int n = -1;
                        foreach (object cell in item.ItemArray)
                        {
                            n++;
                            if (n < (item.ItemArray.Length / 2))
                            {
                                Table.Rows.Add();
                                Table.Rows[n].Cells[0].Value = item["key" + n];
                                Table.Rows[n].Cells[1].Value = item["par" + n];
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
            
        }
        public List<string[]> WordsList = new List<string[]>();
        
 public void ReadStrValues()
        {
            string str = "";
           
            for(int j=0;j< SettingsConfigTable.Rows.Count-1;j++)
            {
                str = SettingsConfigTable.Rows[j].Cells[1].Value.ToString();

                string[] words = str.Split(';');
                WordsList.Add(words);
          
            }
        }

        public void SerialWritter(string _SerialConfigPath,int k, List<bool> _StopFlag)
        {
            string start = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<exe>\n";
            string program_name = " <Prog>" + ((MainClass)f).gProgram_name + "</Prog>\n";
            string body = "";
            string end = "\n</exe>\n<?include somedata?>";
            
            for (int i = 0; i < SettingsConfigTable.Rows.Count - 1; i++)
            {
                string tagParSt = "\n  <key" + i + ">";

                string parameter_name = SettingsConfigTable[0, i].Value.ToString();

                string tagParFin = "</key" + i + ">\n";

                string tagValSt = "   <par" + i + ">";
                string value = "";
                if (_StopFlag[i])
                {
                     value = WordsList[i][k];//SettingsConfigTable[1, i].Value.ToString();
                }
                else
                {
                    value = WordsList[i][0];
                }


                string tagValFin = "</par" + i + ">\n";

                body += tagParSt + parameter_name + tagParFin + tagValSt + value + tagValFin;
            }
            System.IO.File.AppendAllText(_SerialConfigPath, start + program_name + body + end);


        }

        public string CreateSeriesettingConf()
        {
            string ShortConfFilename = System.IO.Path.GetFileNameWithoutExtension(@ConfigFullName);
            ReadStrValues();
            List<string[]> bigSubstr = new List<string[]>();
            
            List<bool> IsSerFlag = new List<bool>();//все расширения
            List<bool> StopFlag = new List<bool>();//текущее для одной серии
            for (int i = 0; i < WordsList.Count; i++)
            {
                if (WordsList[i].Length > 1)
                {
                    bigSubstr.Add(WordsList[i]);
                    IsSerFlag.Add(true);
                }
                else
                {
                    IsSerFlag.Add(false);
                }
            }
          
            if (Directory.Exists(Path.Combine(Directory.GetCurrentDirectory() + "\\Configurations\\Series", ShortConfFilename)))
            {
                Directory.Delete(Path.Combine(Directory.GetCurrentDirectory() + "\\Configurations\\Series", ShortConfFilename), true);
            }
            if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory() + "\\Configurations\\Series", ShortConfFilename)))
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory() + "\\Configurations\\Series", ShortConfFilename));
            }
            for (int i = 0; i < bigSubstr.Count; i++)
            {
                StopFlag.Clear();
                for (int k = 0; k < WordsList.Count; k++)
                {
                    StopFlag.Add(false);
                }
                for (int l = 0; l < WordsList.Count; l++)
                {
                    if (IsSerFlag[l])
                    {
                        StopFlag[l] = true;
                        IsSerFlag[l] = false;
                        break;
                    }
                }
              

                if (Directory.Exists(Path.Combine(Directory.GetCurrentDirectory() + "\\Configurations\\Series", ShortConfFilename + "\\" + ShortConfFilename + "_" + i)))
                {
                    Directory.Delete(Path.Combine(Directory.GetCurrentDirectory() + "\\Configurations\\Series", ShortConfFilename + "\\" + ShortConfFilename + "_" + i), true);
                }
                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory() + "\\Configurations\\Series", ShortConfFilename + "\\" + ShortConfFilename + "_" + i)))
                {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory() + "\\Configurations\\Series", ShortConfFilename + "\\" + ShortConfFilename + "_" + i));
                }
                    for (int j = 0; j < bigSubstr[i].Length; j++)
                    {
                        string SerialConfigPath = Directory.GetCurrentDirectory() + "\\Configurations\\Series\\" + ShortConfFilename + "\\" + ShortConfFilename + "_" + i + "\\[gen]_" + ShortConfFilename+"_" + i + "_" + j + ".xml";
                        SerialWritter(SerialConfigPath, j, StopFlag);
                    }
            }
            bigSubstr.Clear();
            StopFlag.Clear();
            IsSerFlag.Clear();
            WordsList.Clear();
            return ShortConfFilename;
        }
       
        
   
        public DataGridViewCellEventArgs cell_e = null;
        private void SettingConfigList_CellClick(object sender, DataGridViewCellEventArgs _e)
        {
            if ((_e.ColumnIndex != -1) && (_e.RowIndex != -1))
            {
                cell_e = _e;

                if ((cell_e.ColumnIndex == 2) || (cell_e.ColumnIndex == 3))
                {
                    if (Convert.ToInt32(SettingConfigList.CurrentRow.Cells[cell_e.ColumnIndex].Value) == 0)
                        SettingConfigList.CurrentRow.Cells[cell_e.ColumnIndex].Value = 1;
                    else
                        SettingConfigList.CurrentRow.Cells[cell_e.ColumnIndex].Value = 0;
                }
                if (cell_e.ColumnIndex == 4)
                {

                    CreateSettingsTable(metroGrid1, SettingConfigList.CurrentRow.Cells[1].Value.ToString());
                   
                }
            }
        }
      
        private void AddSerToRun()
        {
            
            ((MainClass)f).ReadConfsInDir(((MainClass)f).TextBoxChosenDirXML.Text);
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\Configurations\\Series"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Configurations\\Series");
            }
            string _ShortConfFilename = CreateSeriesettingConf();
            SettingConfigList.Rows.Clear();
            DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\Configurations\\Series\\" + _ShortConfFilename);
            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo file in dirs)
            {

                string[] fileName = System.IO.Directory.GetFiles(file.FullName, "*.xml");
                for (int i = 0; i < fileName.Length; i++)
                {
                    if (File.Exists(fileName[i]))
                    {

                        string Shortname = System.IO.Path.GetFileNameWithoutExtension(@fileName[i]);
                       
                        DataGridViewRow rowToAdd = (DataGridViewRow)((MainClass)f).ConfigList.Rows[0].Clone();
                      
                        rowToAdd.Cells[0].Value = Shortname + ".xml";//short name
                        rowToAdd.Cells[1].Value = fileName[i];//full name
                        rowToAdd.Cells[2].Value = 1;//use
                        rowToAdd.Cells[3].Value = 0;//mpi
                        SettingConfigList.Rows.Add(rowToAdd);

                    }
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddSerToRun();
        }

        
        private void AddFinalActiveConfs()
        {
            ((MainClass)f).GenConfsGrid.Rows.Clear();
            for (int i = 0; i < SettingConfigList.RowCount; i++)
            {
                if (Convert.ToInt32(SettingConfigList.Rows[i].Cells[2].Value) == 1)
                {
                    DataGridViewRow rowToAdd = (DataGridViewRow)((MainClass)f).ConfigList.Rows[eSet.RowIndex].Clone();
                    rowToAdd.Cells[0].Value = SettingConfigList.Rows[i].Cells[0].Value.ToString();//short name
                    rowToAdd.Cells[1].Value = SettingConfigList.Rows[i].Cells[1].Value.ToString();//full name
                    rowToAdd.Cells[2].Value = SettingConfigList.Rows[i].Cells[2].Value;//use
                    rowToAdd.Cells[3].Value = 0;//mpi

                    ((MainClass)f).GenConfsGrid.Rows.Add(rowToAdd);

                }
               

            }
            ((MainClass)f).ConfigList.Rows[eSet.RowIndex].Cells[2].Value = 1;
        }
        private void metroButton1_Click_1(object sender, EventArgs e)
        {
           

            if (checkBox1.Checked)
            {
                AddFinalActiveConfs();
            }
            else 
            {
                if (SettingConfigList.RowCount != 0)
                {
                    DialogResult m = MessageBox.Show("Применить выбранные конфигурации?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (m == DialogResult.Yes)
                    {
                        AddFinalActiveConfs();
                        this.Close();
                    }
                    else if (m == DialogResult.No)
                    {
                        this.Close();
                    }
                }
            }
         
            this.Close();
        }

        private void SettingConfigList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
           
                if (e.RowIndex < 0)
                    return;

             
                if (e.ColumnIndex == 4)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    var w = Properties.Resources.strelkaRight.Width;
                    var h = Properties.Resources.strelkaRight.Height;
                    var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                    var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                    e.Graphics.DrawImage(Properties.Resources.strelkaRight, new Rectangle(x, y, w, h));
                    e.Handled = true;
                }
            
        }
    }
}
