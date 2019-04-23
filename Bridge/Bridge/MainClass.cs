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

        public int SeriesNumber = 0 ;

        public Info InfoData = new Info();
        public MainClass()
        {
            InitializeComponent();

            InitTable();

            ComboBoxProgName.SelectedItem = "examin.exe";

            UpdateExpJournal();

            TextBoxChosenProgram.Text = gChosenProgram;
            TextBoxChosenDirXML.Text = gChosenDirXML;
            metroTabControl1.SelectTab(Base);
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
            SeriesNumber++;
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
            DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\Configurations\\Series");
            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo file in dirs)
            {
                if (Directory.Exists(file.FullName))
                {
                    Directory.Delete(file.FullName, true);
                }

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
        public DataGridViewCellEventArgs Set_cell_e = null;

       
    }

}
