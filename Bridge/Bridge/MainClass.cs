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
        public String fileLoc = "";
        public String Program_name;

        public Info InfoData = new Info();
        public MainClass()
        {
            InitializeComponent();

            InitTable();

            ComboBoxProgName.SelectedItem = "examin.exe";
            Program_name = ComboBoxProgName.SelectedItem.ToString();
        }

        //Run
        private void Run_Click(object sender, EventArgs e)
        {
           Run_exp(fileLoc, Program_name);
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
    }

}
