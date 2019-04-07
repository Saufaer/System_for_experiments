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
        public String TempXML = "";
        public String MpiCommand = "";

        public void SetMpiRun()
        {
            if (CheckMpiCom.Checked)
            {
                 MpiCommand = "mpiexec -n "+TextMpiComm.Text ;
            }
        }

        public void Run_exp(String _Temp_Config_path, String _Source_Config_path, String _ChosenProgram)
        {
            String _Config_path = _Temp_Config_path;
            if ((_Config_path != "") && (_ChosenProgram != ""))
            {
                if ((File.Exists(_Config_path)) && (File.Exists(_ChosenProgram)))
                {
                    String CurConfigName = new DirectoryInfo(_Config_path).Name;
                    //String ProgramName = new DirectoryInfo(_ChosenProgram).Name;
                    String ProgramName = "examin.exe";
                    SetMpiRun();
                    var psi = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        Arguments = "/c " + MpiCommand + " " + ProgramName + " " + CurConfigName,
                        // '/c' is close cmd after run
                        RedirectStandardOutput = true,
                        UseShellExecute = false
                    };
                    string result = Process.Start(psi).StandardOutput.ReadToEnd();
                    AddExperiment(result, _Source_Config_path);
                }
                else MetroFramework.MetroMessageBox.Show(this, "XML или EXE не найден", "Оповещение");
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Не выбран XML или EXE ", "Оповещение");
            }
        }

        public void AddExperiment(string res, string _Source_Config_path)
        {
            String currentPath = Directory.GetCurrentDirectory();
            if (!Directory.Exists(Path.Combine(currentPath, "Experiments")))
            {
                Directory.CreateDirectory(Path.Combine(currentPath, "Experiments"));
            }
            String ExpNewPath = Directory.GetCurrentDirectory() + "\\Experiments";
            String date = DateTime.Now.ToString("[HH-mm-ss]_dd.MM.yy");
            if (!Directory.Exists(Path.Combine(ExpNewPath, date)))
            {
                Directory.CreateDirectory(Path.Combine(ExpNewPath, date));
            }

            String OutFileName = date;
            String EXP = ExpNewPath + "\\" + OutFileName;
            String LogPath = EXP + "\\Log.txt";
            StreamWriter file = new StreamWriter(LogPath);
            file.Write(res);
            file.Close();

            String ConfPath = ExpNewPath + "\\" + OutFileName + "\\ConfPath.txt";
            StreamWriter ConfFile = new StreamWriter(ConfPath);
            ConfFile.WriteLine(_Source_Config_path);
            ConfFile.Close();

            //отправка точек в соответствующую папку
           if(File.Exists(Directory.GetCurrentDirectory() + "\\" + "optim.dat"))
            {
                String TempOptim = Directory.GetCurrentDirectory() + "\\" + "optim.dat";
                String OptimLoc = EXP + "\\" + "optim.dat";
                File.Copy(TempOptim, OptimLoc);

                File.Delete(TempOptim);
            }

            UpdateExpJournal();
        }



        public void ChoseXML()
        {
            if (File.Exists(TempXML))
            {
                File.Delete(TempXML);
            }
            OpenFileDialog OPF = new OpenFileDialog();
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                gChosenXML = OPF.FileName;
            }
            if (File.Exists(gChosenXML))
            {
                String ConfigName = new DirectoryInfo(gChosenXML).Name;
                TempXML = Directory.GetCurrentDirectory() + "\\" + ConfigName;
                if (!File.Exists(TempXML))
                {
                    File.Copy(gChosenXML, TempXML);
                }
                gTempChosenXML = TempXML;
            }
            if (File.Exists(gChosenXML))
            {
                TextBoxChosenXML.Text = gChosenXML;
            }
            else
            {
                if (!File.Exists(gChosenXML))
                {
                    MetroFramework.MetroMessageBox.Show(this, "XML не найден.", "Оповещение");
                }
            }
        }


        public void ChoseProgram()
        {
            OpenFileDialog OPF = new OpenFileDialog();
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                gChosenProgram = OPF.FileName;
            }
            if (File.Exists(gChosenProgram))
            {
                  TextBoxChosenProgram.Text = gChosenProgram;
            }
            else
            {
                if (gChosenProgram != "")
                {
                    MetroFramework.MetroMessageBox.Show(this, "EXE не найден.", "Оповещение");
                }
            }
        }
    }
}
