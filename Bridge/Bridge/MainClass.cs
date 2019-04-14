using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
namespace Bridge
{
    public partial class MainClass : MetroFramework.Forms.MetroForm
    {
        public String gConfig_path = "";
        public String gProgram_name = "";

        public String gChosenXML = "";
        public String gChosenDirXML = Directory.GetCurrentDirectory() + "\\" + "Configurations";
        public String gTempChosenXML = "";
        public String gChosenProgram = "examin.exe";
        
        public Info InfoData = new Info();
        public MainClass()
        {
            InitializeComponent();

           

            InitTable();

            ComboBoxProgName.SelectedItem = "examin.exe";

            UpdateExpJournal();

            TextBoxChosenProgram.Text = gChosenProgram;
            TextBoxChosenDirXML.Text = gChosenDirXML;

            //ProgressBarJour.ValueChanged += ProgressBarJour_ValueChanged;

        }


        //Open
        private void OpenXMLbutton_Click(object sender, EventArgs e)
        {
            OpenXML(true);
        }

        //Write
        private void WriteConf_Click(object sender, EventArgs e)
        {
            WriteConfing();
        }

        //Create
        private void Create_Click(object sender, EventArgs e)
        {
            CreateXML();
        }

        //Delete
        private void Delete_Click(object sender, EventArgs e)
        {
            DeleteXML();
        }

        //Add link
        private void AddLink_Click(object sender, EventArgs e)
        {
            AddLinkToConf();
        }

        //SearchInfo
        private void SearchInfo_Click(object sender, EventArgs e)
        {
            Search(InfoTable, TextBoxSearch, SearchResLabel);
        }


        //Run
        private void Run_Click(object sender, EventArgs e)
        {
            Run_exp(gTempChosenXML, gChosenXML, gChosenProgram, CheckMpiCom.Checked,true);
        }


        private void ButtonChoseTargetXML_Click(object sender, EventArgs e)
        {
            ChoseXML();
        }

        private void ButtonChoseProgram_Click(object sender, EventArgs e)
        {
            ChoseProgram();
        }

        private void CreateXMLDefault_Click(object sender, EventArgs e)
        {
            CreateXMLDefault();
        }

        private void ButtonSaveAs_Click(object sender, EventArgs e)
        {
            SaveAs();
            OpenXML(false);
        }

        private void MainClass_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (File.Exists(TempXML))
            {
                File.Delete(TempXML);
            }
        }

        private void SearchButton2_Click(object sender, EventArgs e)
        {
            Search(GridJournal, SearchTextBox2, ResLabel2);
        }





        private void ButOpenConfList_Click(object sender, EventArgs e)
        {
            ReadConfsInDir(TextBoxChosenDirXML.Text);
        }

        private void ConfigList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs _e)
        {
            
            
        }

      
      

        private void GridConfAllCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (GridConfAllCheckBox1.Checked)
            {

                for (int i = 0; i < ConfigList.Rows.Count; i++)
                {
                    ConfigList.Rows[i].Cells[2].Value = 1;
                }
            }
            else
            {
                for (int i = 0; i < ConfigList.Rows.Count; i++)
                {
                    ConfigList.Rows[i].Cells[2].Value = 0;
                }
            }
        }

        private void MPIAllCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (MPIAllCheckBox1.Checked)
            {

                for (int i = 0; i < ConfigList.Rows.Count; i++)
                {
                    ConfigList.Rows[i].Cells[3].Value = 1;
                }
            }
            else
            {
                for (int i = 0; i < ConfigList.Rows.Count; i++)
                {
                    ConfigList.Rows[i].Cells[3].Value = 0;
                }
            }
        }
    }

}
