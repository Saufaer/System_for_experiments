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
            CreateSettingsTable();
        }
        System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["MainClass"];
        public void CreateSettingsTable()
        {
            

                 if (File.Exists(ConfigFullName))
            {
                try
                {

                    SettingsConfigTable.Rows.Clear();
                    DataSet ds = new DataSet();
                    ds.ReadXml(ConfigFullName);
                    foreach (DataRow item in ds.Tables["exe"].Rows)
                    {
                        int n = -1;
                        foreach (object cell in item.ItemArray)
                        {
                            n++;
                            if (n < (item.ItemArray.Length / 2))
                            {
                                SettingsConfigTable.Rows.Add();
                                SettingsConfigTable.Rows[n].Cells[0].Value = item["key" + n];
                                SettingsConfigTable.Rows[n].Cells[1].Value = item["par" + n];
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

        public void CreateSerialSettingConf()
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
                if (Directory.Exists(Path.Combine(Directory.GetCurrentDirectory() + "\\Configurations\\Serials", ShortConfFilename + "_" + i)))
                {
                    Directory.Delete(Path.Combine(Directory.GetCurrentDirectory() + "\\Configurations\\Serials", ShortConfFilename + "_" + i), true);
                }
                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory() + "\\Configurations\\Serials", ShortConfFilename + "_" + i)))
                {
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory() + "\\Configurations\\Serials", ShortConfFilename + "_" + i));
                }
                    for (int j = 0; j < bigSubstr[i].Length; j++)
                    {
                        string SerialConfigPath = Directory.GetCurrentDirectory() + "\\Configurations\\Serials\\" + ShortConfFilename + "_" + i + "\\" + ShortConfFilename+"_" + i + "_" + j + ".xml";
                        SerialWritter(SerialConfigPath, j, StopFlag);
                    }
            }
            bigSubstr.Clear();
            StopFlag.Clear();
            IsSerFlag.Clear();
            WordsList.Clear();
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\Configurations\\Serials"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Configurations\\Serials");
            }
            CreateSerialSettingConf();

            DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\Configurations\\Serials");
            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo file in dirs)
            {
                string[] fileName = System.IO.Directory.GetFiles(file.FullName, "*.xml");
                for (int i = 0; i < fileName.Length; i++)
                {
                    if (File.Exists(fileName[i]))
                    {
                        string Shortname = System.IO.Path.GetFileNameWithoutExtension(@fileName[i]);
                      //  MetroFramework.MetroMessageBox.Show(this, fileName[i], "Оповещение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        DataGridViewRow rowToAdd = (DataGridViewRow)((MainClass)f).ConfigList.Rows[0].Clone();
                        //  rowToAdd.Visible = false;
                        rowToAdd.Cells[0].Value = Shortname+".xml";
                        rowToAdd.Cells[1].Value = fileName[i];
                        rowToAdd.Cells[2].Value = 1;
                        rowToAdd.Cells[3].Value = 0;
                        ((MainClass)f).ConfigList.Rows.Add(rowToAdd);

                     // ((MainClass)f).ConfigList.Rows.Insert(0, rowToAdd);
                      //  ((MainClass)f).ConfigList.Rows[((MainClass)f).ConfigList.Rows.Count-1].Visible = false;
                        
                    }
                }

            }

            




            


        }
    }
}
