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
            if (_UseMpi == true)
            {
                MpiCommand = "mpiexec -n " + TextMpiComm.Text;
            }
            else
                {
                MpiCommand = "";
            }
            }
        }




        public void Run_exp(String _Temp_Config_path, String _Source_Config_path, String _ChosenProgram, bool UseMpi,bool SingleStart)
        {
            String _Config_path = _Temp_Config_path;
            if ((_Config_path != "") && (_ChosenProgram != ""))
            {
                if ((File.Exists(_Config_path)) && (File.Exists(_ChosenProgram)))
                {
                    String CurConfigName = new DirectoryInfo(_Config_path).Name;
                    //String ProgramName = new DirectoryInfo(_ChosenProgram).Name;
                    String ProgramName = "examin.exe";
                    
                    SetMpiRun(UseMpi, SingleStart);

                    var psi = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        Arguments = "/c " + MpiCommand + " " + ProgramName + " " + CurConfigName,
                        // '/c' is close cmd after run
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                        CreateNoWindow = true
                };
                   
                    if (SingleStart)
                    {
                        ProgressBarJour.Value = 0;
                        string result = Process.Start(psi).StandardOutput.ReadToEnd();
                        AddExperiment(result, _Source_Config_path, UseMpi);
                        UpdateExpJournal();
                        ProgressBarJour.Value = 100;
                    }
                    else
                    {
                        Process PR = new Process();
                        PR.StartInfo = psi;
                        PR.EnableRaisingEvents = true;
                        PR.Start();
                        Results.Add(PR.StandardOutput.ReadToEnd());
                    }
                   
                }
                else MetroFramework.MetroMessageBox.Show(this, "XML или EXE не найден", "Оповещение");
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Не выбран XML или EXE ", "Оповещение");
            }
        }


        
        public  void CreateTempConfigs()
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

                gTempChosenXML = TextBoxChosenXML.Text;
            }

        }
        public async void ComboFinRun(int k, List<string> ActiveConfs, List<string> TempComboXML)
        {
            ProgressBarJour.Value = 0;
                for (int i = 0; i < ComboSize; i++)
                {
                
                Run_exp(TempComboXML[i], ActiveConfs[i], gChosenProgram, MpiList[i],false);

                AddExperiment(Results[i], ActiveConfs[i], MpiList[i]);
             
                 //TaskEx.Delay(2200).Wait();
                await TaskEx.Delay(2500);

                if (i == ComboSize - 1)
                {
                    ProgressBarJour.Value = 100;
                }
                else
                {
                    ProgressBarJour.Value += 100 / ComboSize;
                }


                if (File.Exists(TempComboXML[i]))
                    {
                        File.Delete(TempComboXML[i]);
                    }
                UpdateExpJournal();
            }

            RunComboFin.Enabled = true;
            TextMpiComm.Enabled = true;
            TempComboXML.Clear();
            ActiveConfs.Clear();
            MpiList.Clear();
            ComboSize = 0;

        }
        public void AddExperiment(string res, string _Source_Config_path,bool useMpi)
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

            //лог
            using (StreamWriter Resfile = new StreamWriter(LogPath))
            {
                Resfile.Write(res);
                Resfile.Close();
            }
            

            //путь конфига
            String ConfPath = ExpNewPath + "\\" + OutFileName + "\\ConfPath.txt";
            using (StreamWriter ConfFile = new StreamWriter(ConfPath))
            {
                ConfFile.WriteLine(_Source_Config_path);
                ConfFile.Close();
            }
               

            //отправка точек в соответствующую папку
           if(File.Exists(Directory.GetCurrentDirectory() + "\\" + "optim.dat"))
            {
                String TempOptim = Directory.GetCurrentDirectory() + "\\" + "optim.dat";
                String OptimLoc = EXP + "\\" + "optim.dat";
                File.Copy(TempOptim, OptimLoc);
                File.Delete(TempOptim);
            }

           //линии уровня
           if(useMpi)
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
                MessageBox.Show("Указанная директория не найдена.", "Оповещение");
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
                    MetroFramework.MetroMessageBox.Show(this, "EXE не найден.", "Оповещение");
                }
            }
        }
    }
}
