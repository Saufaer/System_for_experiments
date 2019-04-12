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
    public partial class MainClass : MetroFramework.Forms.MetroForm
    {
        public DataGridViewCellMouseEventArgs e = null;
        public void UpdateExpJournal()
        {
            string expPath = Directory.GetCurrentDirectory() + "\\Experiments";
            if (Directory.Exists(expPath))
            {
                string journalPath = expPath + "\\Journal.xml";
                File.WriteAllText(journalPath, string.Empty);
                string start = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<journal>\n";
                string end = "\n</journal>\n<?include somedata?>\n";
                System.IO.File.AppendAllText(journalPath, start);
                GridJournal.Rows.Clear();
                string LogPath = Directory.GetCurrentDirectory() + "\\Experiments";
                if (Directory.Exists(LogPath) && Directory.Exists(Directory.GetCurrentDirectory() + "\\Configurations"))
                {
                    int k = 0;
                    DirectoryInfo dir = new DirectoryInfo(LogPath);
                    DirectoryInfo[] dirs = dir.GetDirectories();
                    foreach (DirectoryInfo f in dirs)
                    {
                        if (File.Exists(f.FullName + "\\Log.txt"))
                        {
                            string confP = f.FullName + "\\ConfPath.txt";
                            if (File.Exists(confP))
                            {
                                string[] readText = System.IO.File.ReadAllLines(confP);
                                string ConfPath = readText[0];

                                if (File.Exists(ConfPath))
                                {
                                    String ConfigName = new DirectoryInfo(ConfPath).Name;
                                    AddExpRecord(k, ConfPath, f.FullName + "\\Log.txt", f.CreationTime.ToString());
                                    GridJournal.Rows.Add(f.CreationTime, f.FullName, f.Name, ConfPath, ConfigName);
                                    k++;
                                }
                                else
                                {
                                    AddExpRecord(k, "Confuguration not found", f.FullName + "\\Log.txt", f.CreationTime.ToString());
                                    GridJournal.Rows.Add(f.CreationTime, f.FullName, f.Name, "not", "Файл не найден");
                                    k++;
                                }
                            }
                            else
                            {
                                AddExpRecord(k, "Confuguration path not saved", f.FullName + "\\Log.txt", f.CreationTime.ToString());
                                GridJournal.Rows.Add(f.CreationTime, f.FullName, f.Name, "not", "Не сохранен путь");
                                k++;
                            }
                        }
                        else
                        {
                            string confP = f.FullName + "\\ConfPath.txt";
                            if (File.Exists(confP))
                            {
                                string[] readText = System.IO.File.ReadAllLines(confP);
                                string ConfPath = readText[0];

                                if (File.Exists(ConfPath))
                                {
                                    String ConfigName = new DirectoryInfo(ConfPath).Name;
                                    AddExpRecord(k, ConfPath, "Файл не найден", f.CreationTime.ToString());
                                    GridJournal.Rows.Add(f.CreationTime, "not", "Файл не найден", ConfPath, ConfigName);
                                    k++;
                                }
                                else
                                {
                                    AddExpRecord(k, "Confuguration not found", "Файл не найден", f.CreationTime.ToString());
                                    GridJournal.Rows.Add(f.CreationTime, "not", "Файл не найден", "not", "Файл не найден");
                                    k++;
                                }
                            }
                            else
                            {
                                AddExpRecord(k, "Confuguration path not saved", "Файл не найден", f.CreationTime.ToString());
                                GridJournal.Rows.Add(f.CreationTime, "not", "Файл не найден", "not", "Не сохранен путь");
                                k++;
                            }
                        }
                    }
                    System.IO.File.AppendAllText(journalPath, end);
                    GridJournal.CurrentCell = GridJournal[0, 0];
                    GridJournal.Rows[0].Cells[0].Selected = false;
                }
            }
        }

        public void AddExpRecord(int num, string confPath, string LogPath, string date)
        {
            string date_exp = "\n <exp" + num + ">\n\n<date>\n" + date + "\n</date>";
            string experiment_Path = "\n<expPath>\n" + LogPath + "\n</expPath>\n";
            string configuration_Path = " <confPath>\n" + confPath + "\n</confPath>\n\n </exp" + num + ">\n";
            string expPath = Directory.GetCurrentDirectory() + "\\Experiments";
            string journalPath = expPath + "\\Journal.xml";
            System.IO.File.AppendAllText(journalPath, date_exp + experiment_Path + configuration_Path);
        }
        
        private void GridJournal_CellMouseClick(object sender, DataGridViewCellMouseEventArgs _e)
        {
            if ((_e.ColumnIndex != -1) && (_e.RowIndex != -1))
            {
                e = _e;
                String name = Convert.ToString(GridJournal.Rows[_e.RowIndex].Cells[2].Value);
                String path = Convert.ToString(GridJournal.Rows[_e.RowIndex].Cells[1].Value);
                string filePath = path + "\\Log.txt";
                if (File.Exists(filePath))
                {
                    StreamReader file = new StreamReader(filePath);
                    string lines = file.ReadToEnd();
                }
            }
        }
       
        private void GridJournal_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs _e)
        {
            if ((_e.ColumnIndex != -1) && (_e.RowIndex != -1))
            {
                e = _e;
                using (Results Res = new Results(e))
                {
                    Res.ShowDialog();

                }
            }
            
        }

        private void ResultsButton_Click(object sender, EventArgs _e)
        {
            if (e != null)
            {
                using (Results Res = new Results(e))
                {
                    Res.ShowDialog();
                }
            }
        }
        private void RunComboFin_Click(object sender, EventArgs e)
        {

            CreateTempConfigs();
            if (ComboSize != 0)
            {

                  RunComboFin.Enabled = false;
                TextMpiComm.Enabled = false;
                ButtonChoseTargetXML.Enabled = false;
                ButtonChoseProgram.Enabled = false;
                Run.Enabled = false;
                ButOpenConfList.Enabled = false;
                ChoseDirConfBut.Enabled = false;
                TextBoxChosenDirXML.Enabled = false;
                TextBoxChosenProgram.Enabled = false;
                TextBoxChosenXML.Enabled = false;
                ComboFinRun(ComboSize, ActiveConfs, TempComboXML);
            }


        }
       
    }
}
