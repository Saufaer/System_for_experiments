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

       
        private int elapsedTime;
        private bool eventHandled;

       

        // Handle Exited event and display process information.
        private void myProcess_Exited(object sender, System.EventArgs e)
        {
            eventHandled = true;
           
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
                    Process PR = new Process();
                   
                    elapsedTime = 0;
                    eventHandled = false;
                    try
                    {
                        PR.StartInfo = psi;
                        PR.EnableRaisingEvents = true;
                        PR.Exited += new EventHandler(myProcess_Exited);
                        PR.Start();
                        PR.WaitForExit();
                    }
                    catch (Exception ex)
                    {
                       // Console.WriteLine($"An error occurred trying to print \"{fileName}\":\n{ex.Message}");
                        return;
                    }
                    // Wait for Exited event, but not more than 30 seconds.

                    //const int SleepAmount = 100;
                    //while (!eventHandled)
                    //{
                    //    elapsedTime += SleepAmount;
                    //    if (elapsedTime > 30000)
                    //    {
                    //        break;
                    //    }

                    //    Thread.Sleep(SleepAmount);
                    //}

                    //string result = PR.StandardOutput.ReadToEnd();
                   // AddExperiment(result, _Source_Config_path);
                     Results.Add(PR.StandardOutput.ReadToEnd());

                    //string result = Process.Start(psi).StandardOutput.ReadToEnd();
                    //AddExperiment(result, _Source_Config_path);

                    //PR.WaitForExit();

                    //   string result = PR.StandardOutput.ReadToEnd();
                    //  string result = Process.Start(psi).StandardOutput.ReadToEnd();
                    //   AddExperiment(result, _Source_Config_path);


                }
                else MetroFramework.MetroMessageBox.Show(this, "XML или EXE не найден", "Оповещение");
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Не выбран XML или EXE ", "Оповещение");
            }
        }

    
        public List<string> Results = new List<string>();
        public   List<string> ActiveConfs = new List<string>();
      public   List<string> TempComboXML = new List<string>();
        public int k =0;

        public void Run_Combo()
        {
           
            for (int i = 0; i < ConfigList.RowCount; i++)
            {
                if (Convert.ToInt32(ConfigList.Rows[i].Cells[2].Value) == 1)
                {
                    ActiveConfs.Add(ConfigList.Rows[i].Cells[1].Value.ToString());
                }
            }
             k = 0;
            foreach (String SingleConf in ActiveConfs)
            {
                gChosenXML = SingleConf;
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
                TempComboXML.Add(gTempChosenXML);
                k++;
            }

        }
        public async void FinRun(int k, List<string> ActiveConfs, List<string> TempComboXML)
        {

            for (int i = 0; i < k; i++)
            {

                Run_exp(TempComboXML[i], ActiveConfs[i], gChosenProgram);
                
                //  AddExperiment(Results[i], ActiveConfs[i]);
                if (File.Exists(TempComboXML[i]))
                {
                    File.Delete(TempComboXML[i]);
                }
            
            }
            
            for (int i = 0; i < k; i++)
            {
                //MetroFramework.MetroMessageBox.Show(this,  Results[i]);
                AddExperiment(Results[i], ActiveConfs[i]);
                await System.Threading.Tasks.Task.Delay(1000);

            }
            UpdateExpJournal();

            TempComboXML.Clear();
            ActiveConfs.Clear();
            k = 0;

        }
        private void RunComboFin_Click(object sender, EventArgs e)
        {
            FinRun(k, ActiveConfs, TempComboXML);
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
            using (StreamWriter Resfile = new StreamWriter(LogPath))
            {
                Resfile.Write(res);
                Resfile.Flush();
                Resfile.Close();
            }
            


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

          
            //Thread.Sleep(1000);
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

        public void ChoseDirXML()
        {
            if (File.Exists(TempXML))
            {
                File.Delete(TempXML);
            }

            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                gChosenDirXML = FBD.SelectedPath;
            }

         
            if (Directory.Exists(gChosenDirXML))
            {
                String ConfigDirName = new DirectoryInfo(gChosenDirXML).Name;
            }
            if (Directory.Exists(gChosenDirXML))
            {
                TextBoxChosenDirXML.Text = gChosenDirXML;
            }
            else
            {
                if (!Directory.Exists(gChosenDirXML))
                {
                    MetroFramework.MetroMessageBox.Show(this, "XML не найден.", "Оповещение");
                }
            }
        }
        public void ReadConfsInDir(String DirPath)
        {
            if (Directory.Exists(DirPath))
            {
                ConfigList.Rows.Clear();
                String ConfigName = "";
                String[] files = Directory.GetFiles(DirPath, "*.xml");
                DataGridViewColumn column = new DataGridViewCheckBoxColumn();
                column.DataPropertyName = "ToCombo";
                column.Name = "Включение в серию";
                ConfigList.Columns.Add(column);
                for (int i=0;i<files.Length;i++)
                {
                    ConfigList.Rows.Add();
                    ConfigName = new DirectoryInfo(files[i]).Name;
                    ConfigList.Rows[i].Cells[0].Value = ConfigName;
                    ConfigList.Rows[i].Cells[1].Value = files[i];
                    ConfigList.Rows[i].Cells[2].Value = 0;
                    
                }
            }
            else
            {
                MessageBox.Show("Указанная директория не найдена.", "Ошибка.");
            }
            
        }
        
       


        private void ConfigList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                if (Convert.ToInt32(ConfigList.CurrentRow.Cells[e.ColumnIndex].Value) == 0)
                    ConfigList.CurrentRow.Cells[e.ColumnIndex].Value = 1;
                else
                    ConfigList.CurrentRow.Cells[e.ColumnIndex].Value = 0;
            }
        }




        private void ChoseDirConfBut_Click(object sender, EventArgs e)
        {
            ChoseDirXML();
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
