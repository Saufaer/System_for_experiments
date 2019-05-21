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
          //  metroTabControl1.SelectTab(Base);
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
            ConfSaveAs();
            OpenXML(false);
        }

        private void MainClass_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (File.Exists(TempXML))
            {
                File.Delete(TempXML);
            }
            if(Directory.Exists(Directory.GetCurrentDirectory() + "\\Configurations\\Series\\Temp"))
                {
                DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\Configurations\\Series\\Temp");
                DirectoryInfo[] dirs = dir.GetDirectories();
                foreach (DirectoryInfo file in dirs)
                {
                    if (Directory.Exists(file.FullName))
                    {
                        Directory.Delete(file.FullName, true);
                    }

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

        private void metroButton2_Click(object sender, EventArgs e)
        {
            GenConfsGrid.Rows.Clear();
        }
    }
    public static class Exten
    {
        public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(this IEnumerable<IEnumerable<T>> sequences)
        {
            // базовый случай:
            IEnumerable<IEnumerable<T>> result = new[] { Enumerable.Empty<T>() };
            foreach (var sequence in sequences)
            {
                var s = sequence; // не замыкаем на переменную цикла    // рекурсивный случай: используем SelectMany для создания нового произведения на основе исходного произведения
                result =
                  from seq in result
                  from item in s
                  select seq.Concat(new[] { item });
            }
            return result;
        }
    }
}
