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
        
        public void Run_exp(String _Config_path, String _ChosenProgram)
        {
            if ((_Config_path != "")&&(_ChosenProgram !=""))
            {
                String ConfigName = new DirectoryInfo(_Config_path).Name;
                String ProgramName = new DirectoryInfo(_ChosenProgram).Name;

                var psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",

                    Arguments = "/c " + ProgramName + " " + ConfigName,
                    // '/c' is close cmd after run
                    RedirectStandardOutput = true,
                    UseShellExecute = false
                };
              
                String result = Process.Start(psi).StandardOutput.ReadToEnd();
                TextBoxOutLog.Text = result;

            }
            else { MessageBox.Show("Not selected XML or EXE file", "Error."); }
        }


        public void ChoseXML()
        {
            OpenFileDialog OPF = new OpenFileDialog();
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                ChosenXML = OPF.FileName;
            }


            if (File.Exists(ChosenXML))
            {
                TextBoxChosenXML.Text = ChosenXML;
            }
            else
            {
                MessageBox.Show("XML file not found.", "Error.");
            }
        }


        public void ChoseProgram()
        {
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
                MessageBox.Show(".exe file not found.", "Error.");
            }
        }
    }
}
