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

namespace Bridge
{
    public partial class MainClass : MetroFramework.Forms.MetroForm
    {
        public void Run_exp(String _fileLoc, String _Program_name)
        {
            if (_fileLoc != "")
            {
                string ConfigName = new DirectoryInfo(_fileLoc).Name;

                Process.Start("cmd.exe", "/k " + _Program_name + " " + ConfigName);
            }
            else { MessageBox.Show("Not selected XML file", "Error."); }
        }
    }
}
