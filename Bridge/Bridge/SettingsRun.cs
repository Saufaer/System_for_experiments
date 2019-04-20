﻿using System;
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

        public void SerialWritter(StreamWriter SW,int k)
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

                string value = WordsList[i][k];//SettingsConfigTable[1, i].Value.ToString();

                string tagValFin = "</par" + i + ">\n";

                body += tagParSt + parameter_name + tagParFin + tagValSt + value + tagValFin;
            }
            SW.Write(start + program_name + body + end);
            SW.Close();

        }

        public void CreateSerialSettingConf()
        {
            
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
           
            ReadStrValues();

            metroLabel1.Text = "";
            for (int i = 0; i < WordsList.Count; i++)
            {
                metroLabel1.Text += "\n";
                for (int j = 0; j < WordsList[i].Length; j++)
                {
                    metroLabel1.Text += WordsList[i][j];


                   // MetroFramework.MetroMessageBox.Show(this, WordsList[i][j], "Оповещение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
