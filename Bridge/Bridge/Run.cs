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

        public List<string> Results = new List<string>();
        public List<string> ActiveConfs = new List<string>();
        public List<string> TempComboXML = new List<string>();

        public List<bool> MpiList = new List<bool>();
        public int ComboSize = 0;
        public int comboT = 0;
        public bool Stop = false;
        public void SetMpiRun(bool _UseMpi, bool _SingleStart)
        {
            if (_SingleStart)
            {
                if (CheckMpiCom.Checked)
                {
                    MpiCommand = "mpiexec -n " + TextMpiComm.Text;
                }
            }
            else
            {
            if (_UseMpi)
            {
                MpiCommand = "mpiexec -n " + TextMpiComm.Text;
            }
            else
                {
                MpiCommand = "";
            }
            }
        }



        public Process PR;

        public void SingleStartFunc(ProcessStartInfo _psi, String _Source_Config_path, bool UseMpi)
        {
            StopButton.Enabled = true;
            PR = new Process();
            PR.StartInfo = _psi;
            PR.EnableRaisingEvents = true;
            PR.Start();
            string result = PR.StandardOutput.ReadToEnd();
            AddExperiment(result, _Source_Config_path, UseMpi,true);
            UpdateExpJournal();
            StopButton.Enabled = false;
        }
        public async void Run_exp(String _Temp_Config_path, String _Source_Config_path, String _ChosenProgram, bool UseMpi,bool SingleStart)
        {
            String _Config_path = _Temp_Config_path;
            if ((_Config_path != "") && (_ChosenProgram != ""))
            {
                if ((File.Exists(_Config_path)) && (File.Exists(_ChosenProgram)))
                {
                    String CurConfigName = new DirectoryInfo(_Config_path).Name;
                    String CommandLine = "";
                    DataSet ds = new DataSet();
                    ds.ReadXml(CurConfigName);
                    foreach (DataRow item in ds.Tables["exe"].Rows)
                    {
                        int n = -1;
                        foreach (object cell in item.ItemArray)
                        {
                            n++;
                            if (n < (item.ItemArray.Length / 2))
                            {
                                CommandLine+= item["key" + n];
                                CommandLine += " ";
                                CommandLine += item["par" + n];
                                CommandLine += " ";
                            }

                        }

                    }

                    //String ProgramName = new DirectoryInfo(_ChosenProgram).Name;
                    String ProgramName = "examin.exe";
                    
                    SetMpiRun(UseMpi, SingleStart);

                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        Arguments = "/c " + MpiCommand + " " + ProgramName + " " + CommandLine,
                        // '/c' is close cmd after run
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                        CreateNoWindow = true
                    };

                    if (SingleStart)
                    {

                        ProgressBarJour.Value = 0;
                        await TaskEx.Run(() => SingleStartFunc(psi, _Source_Config_path, UseMpi));
                        ProgressBarJour.Value = 100;

                    }
                    else
                    {
                        PR = new Process();
                        PR.StartInfo = psi;
                        PR.EnableRaisingEvents = true;
                        PR.Start();
                        Results.Add(PR.StandardOutput.ReadToEnd());

                    }
                   
                }
                else MetroFramework.MetroMessageBox.Show(this, "XML или EXE не найден", "Оповещение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                
                MetroFramework.MetroMessageBox.Show(this, "Не выбран XML или EXE ", "Оповещение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        public void CreateTempConfigs()
        {
           
            for (int i = 0; i < ConfigList.RowCount; i++)
            {
                if (Convert.ToInt32(ConfigList.Rows[i].Cells[2].Value) == 1)
                {
                    ActiveConfs.Add(ConfigList.Rows[i].Cells[1].Value.ToString());
                    MpiList.Add(Convert.ToBoolean(ConfigList.Rows[i].Cells[3].Value));
                   
                }
                

            }
            ComboSize = 0;
            comboT = 0;
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

                TempComboXML.Add(gTempChosenXML);
                ComboSize++;
                comboT++;
                gTempChosenXML = TextBoxChosenXML.Text;
            }

        }
       

       private void StopFunc()
        {
            if (PR != null)
            {
                try
                {
                    PR.Kill();
                    PR.WaitForExit();
                }
                catch
                {
//это значит, что процесс уже завершился, но ни кто не успел это отследить
                } 
            }
            Process[] ProcessesExamin = System.Diagnostics.Process.GetProcessesByName("examin");
            foreach (Process pr in ProcessesExamin)
            {
                if (pr.HasExited == false)
                {
                    pr.Kill();
                    pr.WaitForExit();
                }
            }

            StopButton.Enabled = false;


            Stop = true;
            RunComboFin.Enabled = true;
            TextMpiComm.Enabled = true;
            ButtonChoseTargetXML.Enabled = true;
            ButtonChoseProgram.Enabled = true;
            Run.Enabled = true;
            ButOpenConfList.Enabled = true;
            ChoseDirConfBut.Enabled = true;
            TextBoxChosenDirXML.Enabled = true;
            TextBoxChosenProgram.Enabled = true;
            TextBoxChosenXML.Enabled = true;

            
            for (int i = 0; i < ComboSize; i++)
            {
                if (File.Exists(TempComboXML[i]))
                {
                    File.Delete(TempComboXML[i]);
                }
            }

            for (int i = 0; i < Convert.ToInt32(TextMpiComm.Text); i++)
            {
                if (i == 0)
                {
                    if (File.Exists(Directory.GetCurrentDirectory() + "\\" + "ExaMin.png"))
                    {
                        String TempPic = Directory.GetCurrentDirectory() + "\\" + "ExaMin.png";
                        File.Delete(TempPic);
                    }
                }
                else
                {
                    if (File.Exists(Directory.GetCurrentDirectory() + "\\" + "ExaMin_" + i + ".png"))
                    {
                        String TempPic = Directory.GetCurrentDirectory() + "\\" + "ExaMin_" + i + ".png";
                        File.Delete(TempPic);
                    }
                }

            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            StopFunc();
        }
        
        
   
    public void AWFunc(int i, List<string> ActiveConfs, List<string> TempComboXML)
        {
            Run_exp(TempComboXML[i], ActiveConfs[i], gChosenProgram, MpiList[i], false);
            AddExperiment(Results[i], ActiveConfs[i], MpiList[i],false);
        }

        public async void ComboFinRun(int k, List<string> ActiveConfs, List<string> TempComboXML)
        {
            StopButton.Enabled = true;
            Stop = false;
            ProgressBarJour.Value = 0;
            for (int i = 0; i < ComboSize; i++)
            {
                if (!Stop)
                {
                    if (i == ComboSize - 1)
                    {
                        ProgressBarJour.Value = 100;
                    }
                    else
                    {
                        ProgressBarJour.Value += 100 / ComboSize;
                    }

                    comboT = i + 1;
                    String ShortName = new DirectoryInfo(TempComboXML[i]).Name;
                    ProcessTextBox.Text = ShortName;
                    await TaskEx.Run(() => AWFunc(i, ActiveConfs, TempComboXML));
                    // AWFunc(i, ActiveConfs, TempComboXML);

                    if (File.Exists(TempComboXML[i]))
                    {
                        File.Delete(TempComboXML[i]);
                    }
                   

                }
                
            }
            UpdateExpJournal();
            

            RunComboFin.Enabled = true;
                TextMpiComm.Enabled = true;
                ButtonChoseTargetXML.Enabled = true;
                ButtonChoseProgram.Enabled = true;
                Run.Enabled = true;
                ButOpenConfList.Enabled = true;
                ChoseDirConfBut.Enabled = true;
                TextBoxChosenDirXML.Enabled = true;
                TextBoxChosenProgram.Enabled = true;
                TextBoxChosenXML.Enabled = true;

                Results.Clear();
                TempComboXML.Clear();
                ActiveConfs.Clear();
                MpiList.Clear();

                ComboSize = 0;
                comboT = 0;
                MpiCommand = "";
                TempXML = "";

    }
       
        public  void AddExperiment(string res, string _Source_Config_path,bool useMpi,bool SingleStart)
        {
            String currentPath = Directory.GetCurrentDirectory();
            
            if (!Directory.Exists(Path.Combine(currentPath, "Experiments")))
            {
                 Directory.CreateDirectory(Path.Combine(currentPath, "Experiments"));
                
            }
            String ExpNewPath = Directory.GetCurrentDirectory() + "\\Experiments";
            String date = DateTime.Now.ToString("[HH-mm-ss]_dd.MM.yy")+"_{" + (comboT).ToString() + "}";
            if (!Directory.Exists(Path.Combine(ExpNewPath, date )))
            {
                Directory.CreateDirectory(Path.Combine(ExpNewPath, date));
            }
            
            String OutFileName = date;
            String EXP = ExpNewPath + "\\" + OutFileName ;
            String LogPath = EXP + "\\Log.txt";

            //лог

            System.IO.File.AppendAllText(LogPath, res);

            //путь конфига
            String ConfPath = ExpNewPath + "\\" + OutFileName + "\\ConfPath.txt";
            System.IO.File.AppendAllText(ConfPath, _Source_Config_path);


           
            //отправка точек в соответствующую папку
           if (File.Exists(Directory.GetCurrentDirectory() + "\\" + "optim.dat"))
            {
                String TempOptim = Directory.GetCurrentDirectory() + "\\" + "optim.dat";
                String OptimLoc = EXP + "\\" + "optim.dat";
               
                File.Copy(TempOptim, OptimLoc);
                File.Delete(TempOptim);
            }
           
           //линии уровня
           if (useMpi)
            {
                for (int i = 0; i < Convert.ToInt32(TextMpiComm.Text); i++)
                {
                    if (i == 0)
                    {
                        if (File.Exists(Directory.GetCurrentDirectory() + "\\" + "ExaMin.png"))
                        {
                            String TempPic = Directory.GetCurrentDirectory() + "\\" + "ExaMin.png";
                            String PicLoc = EXP + "\\" + "ExaMin.png";
                            File.Copy(TempPic, PicLoc);
                            File.Delete(TempPic);
                        }
                    }
                    else
                    {
                        if (File.Exists(Directory.GetCurrentDirectory() + "\\" + "ExaMin_" + i + ".png"))
                        {
                            String TempPic = Directory.GetCurrentDirectory() + "\\" + "ExaMin_" + i + ".png";
                            String PicLoc = EXP + "\\" + "ExaMin_" + i + ".png";
                            File.Copy(TempPic, PicLoc);
                            File.Delete(TempPic);
                        }
                    }
                }
            }
            else
            {
                if (File.Exists(Directory.GetCurrentDirectory() + "\\" + "ExaMin.png"))
                {
                    String TempPic = Directory.GetCurrentDirectory() + "\\" + "ExaMin.png";
                    String PicLoc = EXP + "\\" + "ExaMin.png";
                    File.Copy(TempPic, PicLoc);
                    File.Delete(TempPic);
                }
            }
          

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
                    MetroFramework.MetroMessageBox.Show(this, "XML не найден.", "Оповещение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MetroFramework.MetroMessageBox.Show(this, "XML не найден.", "Оповещение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                    for (int i = 0; i < files.Length; i++)
                    {
                        ConfigList.Rows.Add();
                        ConfigName = new DirectoryInfo(files[i]).Name;
                        ConfigList.Rows[i].Cells[0].Value = ConfigName;
                        ConfigList.Rows[i].Cells[1].Value = files[i];
                        ConfigList.Rows[i].Cells[2].Value = 0;
                        ConfigList.Rows[i].Cells[3].Value = 0;
                }
                
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Указанная директория не найдена.", "Оповещение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }



        public DataGridViewCellEventArgs cell_e = null;
        private void ConfigList_CellClick(object sender, DataGridViewCellEventArgs _e)
        {
            if ((_e.ColumnIndex != -1) && (_e.RowIndex != -1))
            {
                cell_e = _e;

                if ((cell_e.ColumnIndex == 2)|| (cell_e.ColumnIndex == 3))
                {
                    if (Convert.ToInt32(ConfigList.CurrentRow.Cells[cell_e.ColumnIndex].Value) == 0)
                        ConfigList.CurrentRow.Cells[cell_e.ColumnIndex].Value = 1;
                    else
                        ConfigList.CurrentRow.Cells[cell_e.ColumnIndex].Value = 0;
                }
                
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
                    MetroFramework.MetroMessageBox.Show(this, "EXE не найден.", "Оповещение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


    }
}
