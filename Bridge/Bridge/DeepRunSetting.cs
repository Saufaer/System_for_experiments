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
        private List<bool> CheckList = new List<bool>();
        public DeepRunSetting()
        {
            InitializeComponent();
            LoadSavedConfs();
            InitCheckList();
        }
        private void InitCheckList()
        {

            for (int i = 0; i < SavedConfsList.Rows.Count; i++)
            {
                CheckList.Add(false);
            }
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

                    SavedConfsList.Rows[n].Cells[2].Value = 0;
                    SavedConfsList.Rows[n].Cells[3].Value = "+";
                    SavedConfsList.Rows[n].Cells[4].Value = "-";
                }
            }
           
        }
        private DataGridViewCellEventArgs cell_e = null;
        private int CurrRow = -1;
        private int CurrCell = -1;
    
     
        


        int n = -1;
        private void SavedConfsList_CellClick(object sender, DataGridViewCellEventArgs _e)
        {
            if ((_e.ColumnIndex != -1) && (_e.RowIndex != -1))
            {
                cell_e = _e;

                if (cell_e.ColumnIndex == 2)
                {
                    if (Convert.ToInt32(SavedConfsList.CurrentRow.Cells[cell_e.ColumnIndex].Value) == 0)
                    {
                        SavedConfsList.CurrentRow.Cells[cell_e.ColumnIndex].Value = 1;
                       


                        if(metroGrid1.Rows.Count!=0)
                        {
                            for(int i=0;i< metroGrid1.Rows.Count;i++)
                            {
                                if ((int)metroGrid1.Rows[i].Cells[4].Value == SavedConfsList.CurrentRow.Index)
                                {
                                    metroGrid1.Rows[i].Cells[2].Value = 1;
                                }
                            }
                        }

                    }
                    else
                    {
                        SavedConfsList.CurrentRow.Cells[cell_e.ColumnIndex].Value = 0;
                     

                        if (metroGrid1.Rows.Count != 0)
                        {
                            for (int i = 0; i < metroGrid1.Rows.Count; i++)
                            {
                                if ((int)metroGrid1.Rows[i].Cells[4].Value == SavedConfsList.CurrentRow.Index)
                                {
                                    metroGrid1.Rows[i].Cells[2].Value = 0;
                                }
                            }
                        }
                    }
                       
                }
                if (cell_e.ColumnIndex == 3)
                {
                    CurrCell = 2;
                    CurrRow = SavedConfsList.CurrentRow.Index;



                    if (CheckList[CurrRow] == false)
                    {
                        //metroGrid1.Rows.Clear();
                        DirectoryInfo dir = new DirectoryInfo(SavedConfsList.CurrentRow.Cells[1].Value.ToString());
                    DirectoryInfo[] dirs = dir.GetDirectories();
                   
                    foreach (DirectoryInfo f in dirs)
                    {
                        
                        n++;
                        
                        metroGrid1.Rows.Add();
                        metroGrid1.Rows[n].Cells[0].Value = System.IO.Path.GetFileNameWithoutExtension(@f.FullName);

                           
                            
                            metroGrid1.Rows[n].Cells[1].Value = f.FullName;

                            string[] files = Directory.GetFiles(metroGrid1.Rows[n].Cells[1].Value.ToString(), "*.xml");
                            if (File.Exists(files[0]))
                            {
                                metroGrid1.Rows[n].Cells[5].Value = files[0];
                            }

                            metroGrid1.Rows[n].Cells[4].Value = CurrRow;
                        
                        metroGrid1.Rows[n].Cells[2].Value = SavedConfsList.Rows[CurrRow].Cells[2].Value;
                       
                    }
                    }
                    else
                    {
                        if (metroGrid1.Rows.Count != 0)
                        {
                            for (int i = 0; i < metroGrid1.Rows.Count; i++)
                            {
                                if ((int)metroGrid1.Rows[i].Cells[4].Value == SavedConfsList.CurrentRow.Index)
                                {
                                    metroGrid1.Rows[i].Cells[2].Value = SavedConfsList.Rows[CurrRow].Cells[2].Value;
                                }
                            }
                        }
                    }

                    if (CheckList[CurrRow] == false)
                    {
                        CheckList[CurrRow] = true;
                    }

                }

                if (cell_e.ColumnIndex == 4)
                {
                    if (metroGrid1.Rows.Count != 0)
                    {
                        for (int i = metroGrid1.Rows.Count-1; i >= 0; i--)
                        {
                            if ((int)metroGrid1.Rows[i].Cells[4].Value == SavedConfsList.CurrentRow.Index)
                            {
                                  
                                metroGrid1.Rows.RemoveAt(i);
                                n--;
                                CheckList[SavedConfsList.CurrentRow.Index] = false ;

                            }
                        }
                        
                    }
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
                    if (Convert.ToInt32(metroGrid1.CurrentRow.Cells[cell_e1.ColumnIndex].Value) == 0)
                    {
                        metroGrid1.CurrentRow.Cells[cell_e1.ColumnIndex].Value = 1;
                    }
                    else
                    {
                        metroGrid1.CurrentRow.Cells[cell_e1.ColumnIndex].Value = 0;
                    }
                        
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
        
        System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["MainClass"];
        private void metroButton1_Click(object sender, EventArgs e)
        {
            ((MainClass)f).GenConfsGrid.Rows.Clear();
            ((MainClass)f).GenConfsGrid.Rows.Add();
         
            
            for (int i = 0; i < metroGrid1.RowCount; i++)
            {
                if (Convert.ToInt32(metroGrid1.Rows[i].Cells[2].Value) == 1)
                {
                    //DataGridViewRow rowToAdd = (DataGridViewRow)((MainClass)f).ConfigList.Rows[0].Clone();


                    DataGridViewRow rowToAdd = (DataGridViewRow)((MainClass)f).GenConfsGrid.Rows[0].Clone();

                    rowToAdd.Cells[0].Value = metroGrid1.Rows[i].Cells[0].Value.ToString();//short name
                    rowToAdd.Cells[1].Value = metroGrid1.Rows[i].Cells[5].Value.ToString();//full name
                    rowToAdd.Cells[2].Value = metroGrid1.Rows[i].Cells[2].Value;//use
                    rowToAdd.Cells[3].Value = 0;//mpi

                    ((MainClass)f).GenConfsGrid.Rows.Add(rowToAdd);
                }


            }
            ((MainClass)f).GenConfsGrid.Rows.RemoveAt(0);

        }
    }
}
