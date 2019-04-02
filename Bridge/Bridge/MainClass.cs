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
        public String Config_path = "";
        public String Program_name = "";

        public String ChosenXML = "";
        public String ChosenProgram = "";

        public Info InfoData = new Info();
        public MainClass()
        {
            InitializeComponent();

            InitTable();

            ComboBoxProgName.SelectedItem = "examin.exe";

            UpdateExpJournal();
        }


        //Open
        private void OpenXMLbutton_Click(object sender, EventArgs e)
        {
            OpenXML();
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
            Search();
        }


        //Run
        private void Run_Click(object sender, EventArgs e)
        {
            Run_exp(ChosenXML, ChosenProgram);
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
                //DirectoryInfo dir = new DirectoryInfo(path);
                // FileInfo[] XMLFiles = dir.GetFiles("*.xml", SearchOption.AllDirectories);

        }
    }

}
