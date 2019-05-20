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
    public partial class DeepRunSetting : MetroFramework.Forms.MetroForm
    {
        public DeepRunSetting()
        {
            InitializeComponent();
            LoadSavedConfs();
        }

        private void LoadSavedConfs()
        {
            SavedConfsList.Rows.Clear();
            if (Directory.Exists(Directory.GetCurrentDirectory() + "\\Configurations\\Series\\Saved"))
            {
                DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\Configurations\\Series\\Saved");
                DirectoryInfo[] dirs = dir.GetDirectories();
                int n = -1;
                foreach (DirectoryInfo f in dirs)
                {
                    n++;
                    SavedConfsList.Rows.Add();
                    SavedConfsList.Rows[n].Cells[0].Value = System.IO.Path.GetFileNameWithoutExtension(@f.FullName);
                    SavedConfsList.Rows[n].Cells[1].Value = f.FullName;

                    //DirectoryInfo subDir = new DirectoryInfo(f.FullName);
                    //DirectoryInfo[] subDirs = subDir.GetDirectories();
                    //foreach (DirectoryInfo subF in subDirs)
                    //{

                    //}
                }
            }
           
        }
        private DataGridViewCellEventArgs cell_e = null;
        private void SavedConfsList_CellClick(object sender, DataGridViewCellEventArgs _e)
        {
            if ((_e.ColumnIndex != -1) && (_e.RowIndex != -1))
            {
                cell_e = _e;

                if (cell_e.ColumnIndex == 2)
                {
                    if (Convert.ToInt32(SavedConfsList.CurrentRow.Cells[cell_e.ColumnIndex].Value) == 0)
                        SavedConfsList.CurrentRow.Cells[cell_e.ColumnIndex].Value = 1;
                    else
                        SavedConfsList.CurrentRow.Cells[cell_e.ColumnIndex].Value = 0;
                }
                if (cell_e.ColumnIndex == 3)
                {
                    metroGrid1.Rows.Clear();
                    DirectoryInfo dir = new DirectoryInfo(SavedConfsList.CurrentRow.Cells[1].Value.ToString());
                    DirectoryInfo[] dirs = dir.GetDirectories();
                    int n = -1;
                    foreach (DirectoryInfo f in dirs)
                    {
                        n++;
                        metroGrid1.Rows.Add();
                        metroGrid1.Rows[n].Cells[0].Value = System.IO.Path.GetFileNameWithoutExtension(@f.FullName);
                        metroGrid1.Rows[n].Cells[1].Value = f.FullName;

                    }

                    // CreateSettingsTable(metroGrid1, SavedConfsList.CurrentRow.Cells[1].Value.ToString());
                }
            }
        }
        private DataGridViewCellEventArgs cell_e1 = null;
        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs _e)
        {
            if ((_e.ColumnIndex != -1) && (_e.RowIndex != -1))
            {
                cell_e1 = _e;

                if (cell_e1.ColumnIndex == 2)
                {
                    if (Convert.ToInt32(SavedConfsList.CurrentRow.Cells[cell_e1.ColumnIndex].Value) == 0)
                        SavedConfsList.CurrentRow.Cells[cell_e1.ColumnIndex].Value = 1;
                    else
                        SavedConfsList.CurrentRow.Cells[cell_e1.ColumnIndex].Value = 0;
                }
                if (cell_e1.ColumnIndex == 3)
                {
                    metroGrid2.Rows.Clear();
                   
                    string[] files = Directory.GetFiles(metroGrid1.CurrentRow.Cells[1].Value.ToString(), "*.xml");
                    DataSet ds = new DataSet();
                    if (File.Exists(files[0]))
                    {
                        ds.ReadXml(files[0]);
                    
                       
                    foreach (DataRow item in ds.Tables["exe"].Rows)
                    {
                        int k = -1;
                        foreach (object cell in item.ItemArray)
                        {
                            k++;
                            if (k < (item.ItemArray.Length / 2))
                            {
                                metroGrid2.Rows.Add();
                                metroGrid2.Rows[k].Cells[0].Value = item["key" + k];
                                metroGrid2.Rows[k].Cells[1].Value = item["par" + k];
                            }

                        }

                    }
                    }
                }
            }
        }
    }
}
