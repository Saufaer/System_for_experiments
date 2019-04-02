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

        String TempXML = "";

        public void Run_exp(String _Config_path, String _ChosenProgram)
        {
            if ((_Config_path != "")&&(_ChosenProgram !=""))
            {
                String ConfigName = new DirectoryInfo(_Config_path).Name;
                String ProgramName = new DirectoryInfo(_ChosenProgram).Name;

                if (File.Exists(_Config_path))
                {
                    var psi = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",

                        Arguments = "/c " + ProgramName + " " + ConfigName,
                        // '/c' is close cmd after run
                        RedirectStandardOutput = true,
                        UseShellExecute = false
                    };
                    string result = Process.Start(psi).StandardOutput.ReadToEnd();
                    AddExperiment(result, _Config_path);

                    

                    TextBoxOutLog.Text = result;
                    
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Not temp XML or EXE file", "Error.");
                }

            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this,"Not selected XML or EXE file", "Error.");
            }
        }

        public void AddExperiment(string res, string _Config_path)
        {
            String currentPath = Directory.GetCurrentDirectory();
            if (!Directory.Exists(Path.Combine(currentPath, "Experiments")))
            {
                Directory.CreateDirectory(Path.Combine(currentPath, "Experiments"));
            }

            String newPath = Directory.GetCurrentDirectory()+ "\\Experiments";
            String date = DateTime.Now.ToString("dd.MM.yyyy [HH-mm-ss]");
            if (!Directory.Exists(Path.Combine(newPath, date)))
            {
                Directory.CreateDirectory(Path.Combine(newPath, date));
            }
           
            String OutFileName = date;
            String LogPath = newPath + "\\" + OutFileName + "\\Log.txt";
            StreamWriter file = new StreamWriter(LogPath);
            file.Write("Config Path:\n" + _Config_path+ "\n");
            file.Write(res);
            //закрыть для сохранения данных
            file.Close();

          

            UpdateExpJournal();



        }


       
        public void ChoseXML()
        {
            UpdateExpJournal();
            if (File.Exists(TempXML))
            {
                File.Delete(TempXML);
            }

            OpenFileDialog OPF = new OpenFileDialog();
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                ChosenXML = OPF.FileName;
            }
            if (File.Exists(ChosenXML))
            {
                String ConfigName = new DirectoryInfo(ChosenXML).Name;
                TempXML  = Directory.GetCurrentDirectory() + "\\" + ConfigName;
                if (!File.Exists(TempXML))
                {
                    File.Copy(ChosenXML, TempXML);
                }
                ChosenXML = TempXML;
            }
            if (File.Exists(ChosenXML))
            {
                TextBoxChosenXML.Text = ChosenXML;
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "XML file not found.", "Error.");
            }
        }


        public void ChoseProgram()
        {
            UpdateExpJournal();
            OpenFileDialog OPF = new OpenFileDialog();
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                ChosenProgram = OPF.FileName;
            }
            if (File.Exists(ChosenProgram))
            {
                TextBoxChosenProgram.Text = ChosenProgram;
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, ".exe file not found.", "Error.");
            }
        }
    }
}
