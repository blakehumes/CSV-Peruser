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
using CSV_Peruser.CSV_Items;

namespace CSV_Peruser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*String path = "C:\\Users\\blake\\Downloads\\Gender_Stats_csv\\Gender_StatsData.csv";
            int j = 0;

            StringBuilder sb = new StringBuilder();

            try
            {
                using (StreamReader readFile = new StreamReader(path))
                {
                    string line;
                    string[] row;

                    while ((line = readFile.ReadLine()) != null && j < 5)
                    {
                        row = line.Split(',');
                        foreach (string rec in row)
                        {
                            sb.Append(rec).Append(" ");
                        }
                        sb.Append("\n");
                        j++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
            string something = "this, is, really, dumb";
            StringBuilder sb = new StringBuilder();
            Row whatve = new Row(something);
            foreach(string rec in whatve.DataRow)
            {
                sb.Append(rec).Append(" ");
            }

            richTextBox1.Text = sb.ToString();
        }
    }
}
