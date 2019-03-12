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
            metroComboBox3.SelectedItem = "examin.exe";
        }
        //file location
        string fileLoc = Environment.CurrentDirectory + "/" + "config.xml";
        string Program_name;

        public object DataGridView1 { get; internal set; }

        //Create
        private void metroButton1_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|xml files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    myStream.Close();
                }

                fileLoc = saveFileDialog1.FileName;
                using (StreamWriter SWriter = new StreamWriter(fileLoc))
                {
                    string start = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<exe>\n";
                    string program_name = " <Prog>" + Program_name + "</Prog>\n";
                    string body = "";
                    string end = "</exe>\n<?include somedata?>";
                    SWriter.Write(start + program_name + body + end);
                }
                metroTextBox1.Lines = File.ReadAllLines(fileLoc);
                metroTextBox2.Text = fileLoc;
                metroGrid1.Rows.Clear();
            }
        }

        //Write
        private void metroButton2_Click(object sender, EventArgs e)
        {
            try
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
                            string tagParSt = "\n  <key" + i + ">";

                            string parameter_name = metroGrid1[0, i].Value.ToString();

                            string tagParFin = "</key" + i + ">\n";

                            string tagValSt = "   <par" + i + ">";

                            string value = metroGrid1[1, i].Value.ToString();

                            string tagValFin = "</par" + i + ">\n";

                            body += tagParSt + parameter_name + tagParFin + tagValSt + value + tagValFin;
                        }
                        SWriter.Write(start + program_name + body + end);
                    }
                    metroTextBox1.Lines = File.ReadAllLines(fileLoc);
                    metroTextBox2.Text = fileLoc;
                }
                MessageBox.Show("XML файл успешно изменен.", "Выполнено.");
            }
            catch
            {
                MessageBox.Show("Невозможно изменить XML файл.", "Ошибка.");
            }
        }

        //Read
        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (File.Exists(fileLoc))
            {
                metroTextBox1.Lines = File.ReadAllLines(fileLoc);
                metroTextBox2.Text = fileLoc;
            }
        }

        //Delete
        private void metroButton4_Click(object sender, EventArgs e)
        {
            if (File.Exists(fileLoc))
            {
                File.Delete(fileLoc);
                metroTextBox1.Text="";
                metroTextBox2.Text = "";
                metroGrid1.Rows.Clear();
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
            using (CreateLink form = new CreateLink())
            {
                form.ShowDialog();
            }
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {

            OpenFileDialog OPF = new OpenFileDialog();
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                fileLoc = OPF.FileName;
            }


            if (File.Exists(fileLoc)) // if he be
            {
                try
                {
                    metroTextBox1.Lines = File.ReadAllLines(fileLoc);
                    metroTextBox2.Text = fileLoc;
                    metroGrid1.Rows.Clear();
                    DataSet ds = new DataSet(); // enpty cache
                    ds.ReadXml(fileLoc);
                    foreach (DataRow item in ds.Tables["exe"].Rows)
                    {
                        int n = -1;
                        foreach (object cell in item.ItemArray)
                        {
                            n++;
                            if (n < item.ItemArray.Length / 2)
                            {
                                metroGrid1.Rows.Add();
                                metroGrid1.Rows[n].Cells[0].Value = item["key" + n];
                                metroGrid1.Rows[n].Cells[1].Value = item["par" + n];
                            }
                        }

                    }
                }
                catch
                {
                    MessageBox.Show("Bad XML file", "Error.");
                }
            }
            else
            {
                MessageBox.Show("XML file not found.", "Error.");
            }
        }
    }
}
