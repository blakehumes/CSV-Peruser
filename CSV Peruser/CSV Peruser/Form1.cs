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
            String path = "C:\\Users\\blake\\Downloads\\Gender_Stats_csv\\Gender_StatsData.csv";

            TableBuilder tb = new TableBuilder(path);
            tb.Populate();

            StringBuilder sb = new StringBuilder();

            foreach(string rec in tb.HeaderMain.DataRow)
            {
                sb.Append(rec).Append(" ");
            }

            foreach (Row rec in tb.Rows)
            {
                foreach (string rec1 in rec.DataRow)
                {
                    sb.Append(rec1).Append(" ");
                }


            }

            richTextBox1.Text = sb.ToString();
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.Text = openFileDialog1.FileName;
                
            }
        }
    }
}
