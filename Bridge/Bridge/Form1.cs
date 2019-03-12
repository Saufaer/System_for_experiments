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
                using (StreamWriter SWriter = new StreamWriter(fileLoc))
                {
                    string start = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<exe>\n";
                    string program_name = " <Prog>" + Program_name + "</Prog>\n";
                    string body = "";
                    string end = "</exe>\n<?include somedata?>";

                    for (int i = 0; i < metroGrid1.Rows.Count - 1; i++)
                    {
                        string tagParSt = "\n  <par" + i + ">";

                        string parameter_name = metroGrid1[0, i].Value.ToString();

                        string tagParFin = "</par" + i + ">\n";

                        string tagValSt = "   <val" + i + ">";

                        string value = metroGrid1[1, i].Value.ToString();

                        string tagValFin = "</val" + i + ">\n";

                        body += tagParSt + parameter_name + tagParFin + tagValSt + value + tagValFin;
                    }
                    SWriter.Write(start + program_name + body + end);
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
