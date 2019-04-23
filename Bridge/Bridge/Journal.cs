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
                //string journalPath = expPath + "\\Journal.xml";
                //File.WriteAllText(journalPath, string.Empty);
                //string start = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<journal>\n";
                //string end = "\n</journal>\n<?include somedata?>\n";
                //System.IO.File.AppendAllText(journalPath, start);

                GridJournal.Rows.Clear();
                string SeriesPath = Directory.GetCurrentDirectory() + "\\Experiments";
                if (Directory.Exists(SeriesPath) && Directory.Exists(Directory.GetCurrentDirectory() + "\\Configurations"))
                {
                    int k = 0;
                    DirectoryInfo dir = new DirectoryInfo(SeriesPath);
                    DirectoryInfo[] dirs = dir.GetDirectories();
                    foreach (DirectoryInfo f in dirs)
                    {
                        GridJournal.Rows.Add(f.CreationTime, f.FullName, f.Name);
                        k++;
                    }
                
                    GridJournal.CurrentCell = GridJournal[0, 0];
                    GridJournal.Rows[0].Cells[0].Selected = false;
                }
            }
        }

      
        
       
       
        private  void GridJournal_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs _e)
        {
            if ((_e.ColumnIndex != -1) && (_e.RowIndex != -1))
            {
                e = _e;
                using (Series Ser = new Series(e))
                {
                    Ser.ShowDialog();
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
