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

namespace Bridge
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        //file location
        string fileLoc = Environment.CurrentDirectory + "/" + "config.xml";
        string Program_name;

        public object DataGridView1 { get; internal set; }

        //Create
        private void metroButton1_Click(object sender, EventArgs e)
        {
            FileStream fs = null;
            if (!File.Exists(fileLoc))
            {
                using (fs = File.Create(fileLoc))
                {

                }
            }
        }

        //Write
        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (File.Exists(fileLoc))
            {
                using (StreamWriter sw = new StreamWriter(fileLoc))
                {
                    string start = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
                    string one = " <par1>"+ Program_name +"</par1>\n";
                    string two = " <par2>"+ metroGrid1[0, 0].Value.ToString() + "</par2>\n";
                    string three = " <par3>"+ metroGrid1[1, 0].Value.ToString() +"</par3>";
                    string end = "<?include somedata?>";
                    sw.Write(start + "\n<exe>\n"+one+two+three+"\n</exe>\n"+ end);
                }
            }
        }

        //Read
        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (File.Exists(fileLoc))
            {
                using (TextReader tr = new StreamReader(fileLoc))
                {
                    MessageBox.Show(tr.ReadLine());
                }
            }
        }

        //Delete
        private void metroButton4_Click(object sender, EventArgs e)
        {
            if (File.Exists(fileLoc))
            {
                File.Delete(fileLoc);
            }
        }

        //Copy
        private void metroButton5_Click(object sender, EventArgs e)
        {
            string fileLocCopy = Environment.CurrentDirectory + "/" + "config.xml"; ;
            if (File.Exists(fileLoc))
            {
                if (File.Exists(fileLocCopy))
                    File.Delete(fileLocCopy);
                File.Copy(fileLoc, fileLocCopy);
            }
        }

        //Move
        private void metroButton6_Click(object sender, EventArgs e)
        {
            string fileLocMove = Environment.CurrentDirectory + "/" + "config" + System.DateTime.Now.Ticks + ".xml";
            if (File.Exists(fileLoc))
            {
                File.Move(fileLoc, fileLocMove);
            }
        }

        private void metroComboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Program_name = metroComboBox3.Text;
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            using (frmAddEditParams frm = new frmAddEditParams())
            {
                frm.ShowDialog();
            }
        }
    }
}
