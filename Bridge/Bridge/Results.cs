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
    public partial class Results : MetroFramework.Forms.MetroForm
    {
        public DataGridViewCellMouseEventArgs e;
        public Results(DataGridViewCellMouseEventArgs _e)
        {
            InitializeComponent();
            e = _e;
            PrintTables();
        }
        System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["MainClass"];
        
        private void PrintTables()
        {
            
           
            String EXpath = Convert.ToString(((MainClass)f).GridJournal.Rows[e.RowIndex].Cells[1].Value);
            string EXfilePath = EXpath + "\\Log.txt";
            if (File.Exists(EXfilePath))
            {
                NameLog.Clear();
                NameLog.Text = EXpath;
                textBoxLog.Clear();
                StreamReader file = new StreamReader(EXfilePath);
                string lines = file.ReadToEnd();
                textBoxLog.Text = lines;
            }

            String OptimPath = EXpath + "\\optim.dat";

           
            if (File.Exists(OptimPath))
            {
                OptimName.Text = OptimPath;
                TextOptimPath.Clear();
                TextOptimPath.Lines = File.ReadAllLines(OptimPath);


            }

               
           
            String CONFpath = Convert.ToString(((MainClass)f).GridJournal.Rows[e.RowIndex].Cells[3].Value);
            
            if (File.Exists(CONFpath))
            {
                ConfName.Clear();
                ConfName.Text = CONFpath;
                textBoxConf.Clear();
                textBoxConf.Lines = File.ReadAllLines(CONFpath);
            }
        }
    }
}
