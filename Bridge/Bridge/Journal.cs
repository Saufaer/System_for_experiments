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

        public void UpdateExpJournal()
        {
            string expPath = Directory.GetCurrentDirectory() + "\\Experiments";
            string journalPath = expPath + "\\Journal.xml";
            
            if (File.Exists(journalPath))
            {
                File.WriteAllText(journalPath, string.Empty);
            }
            string start = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n";
            string end = "\n<?include somedata?>\n";
            System.IO.File.AppendAllText(journalPath, start);
            GridJournal.Rows.Clear();


            string ConfPath = "";
            string LogPath = Directory.GetCurrentDirectory() + "\\Experiments";
            if (Directory.Exists(LogPath))
            {
                DirectoryInfo dir = new DirectoryInfo(LogPath);
                DirectoryInfo[] dirs = dir.GetDirectories();
                foreach (DirectoryInfo f in dirs)
                {
                    string[] readText = System.IO.File.ReadAllLines(f.FullName + "\\Log.txt");
                    ConfPath = readText[1];//строка в логе , содержащая путь конфига
                   AddExpRecord(ConfPath, f.FullName + "\\Log.txt");
                    GridJournal.Rows.Add(f.CreationTime, f.FullName, ConfPath);
                }
                System.IO.File.AppendAllText(journalPath, end);
            }
        }

        public void AddExpRecord(string confPath, string LogPath)
        {
            string experiment_Path = "\n <exp>\n\n<expPath>\n" + LogPath + "\n</expPath>\n";
            string configuration_Path = " <confPath>\n" + confPath + "\n</confPath>\n\n </exp>\n";
            string expPath = Directory.GetCurrentDirectory() + "\\Experiments";
            string journalPath = expPath + "\\Journal.xml";

                System.IO.File.AppendAllText(journalPath,  experiment_Path + configuration_Path  );

        }

        private void GridJournal_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            String name = Convert.ToString(GridJournal.Rows[e.RowIndex].Cells[0].Value);
            String path = Convert.ToString(GridJournal.Rows[e.RowIndex].Cells[1].Value);
            string filePath = path + "\\Log.txt";
            if (File.Exists(filePath))
            {
                StreamReader file = new StreamReader(filePath);
                string lines = file.ReadToEnd();
                TextBoxOutLog.Text = lines;
            }


        }
    }
}
