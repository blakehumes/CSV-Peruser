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
using CSV_Peruser.Data_Items;

namespace CSV_Peruser
{
    public partial class Form1 : Form
    {
        DataDriver dataDriver = new DataDriver();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = txtbx_Filepath.Text;
            string ext = Path.GetExtension(path);
            switch (combo_Delimeter.SelectedIndex)
            {
                case 0:
                    Row.delimiter = ',';
                    break;
                case 1:
                    Row.delimiter = '\t';
                    break;
                case 2:
                    Row.delimiter = ';';
                    break;
            }

            if (ext == ".csv")
            {
                TableBuilder tb = new TableBuilder(path);
                tb.Populate();
                if (tb.fileReadGood == false)
                {
                    MessageBox.Show("Error Reading File. File may be in use by another program.",
                        "File Error", MessageBoxButtons.OK);
                    return;

                }
                StringBuilder sb = new StringBuilder();
                StringBuilder sb2 = new StringBuilder();

                List<string> headerList = new List<string>();
                foreach(string name in tb.HeaderMain.CSVRow)
                {
                    headerList.Add(name);
                }

                combo_LeftFilter1.Items.AddRange(headerList.ToArray());
                dataDriver.Table = tb.Build();
                data_Grid.DataSource = dataDriver.Table;


                /*int i = 1;
                foreach (string rec in tb.HeaderMain.DataRow)
                {

                    sb.Append(i).Append("- ").Append(rec).Append(" ,");
                    i++;
                }
                sb2.Append(tb.HeaderMain.DataRow.Count).Append(" ");
                sb.Append("\n");

                foreach (Row rec in tb.Rows)
                {
                    i = 1;
                    foreach (string rec1 in rec.DataRow)
                    {
                        sb.Append(i).Append(" - ").Append(rec1).Append(" ,");
                        i++;
                    }
                    sb2.Append(rec.DataRow.Count).Append(" ");
                    sb.Append("\n");

                }

                richTextBox1.Text = sb2.Append("\n").Append(sb.ToString()).ToString();*/
            }
            else
            {
                MessageBox.Show("File type error. Please select a CSV file.", "File Error", MessageBoxButtons.OK);
                btn_Load.Visible = false;
            }
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtbx_Filepath.Text = openFileDialog1.FileName;
                btn_Load.Visible = true;

            }
        }

        private void combo_LeftFilter1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> filteredList = new List<string>();

            DataRow[] foundRows = dataDriver.Table.Select();
        }
    }
}
