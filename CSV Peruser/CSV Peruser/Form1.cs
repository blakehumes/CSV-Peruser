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
                dataDriver.header = tb.HeaderMain;
                string[] headerNames = dataDriver.header.CSVRow.ToArray();

                combo_LeftReturnCol.Items.AddRange(headerNames);
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
                combo_Delimeter.SelectedIndex = 0;

            }
        }

        private void combo_LeftFilter1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> filteredList = new List<string>();

            DataRow[] foundRows = dataDriver.Table.Select();
            string i = combo_LeftFilter1.SelectedItem.ToString();
            string columnName;

            foreach(DataRow rec in foundRows)
            {
                columnName = rec[i].ToString();

                if(!filteredList.Contains(columnName)) filteredList.Add(columnName);
            }

            combo_LeftSelector1.Items.Clear();
            combo_LeftSelector1.Items.AddRange(filteredList.ToArray());
            combo_LeftSign1.Items.Clear();
            combo_LeftSign1.Items.AddRange(new string[] { "<", "<=", "=", ">=", ">" });
        }

        private void combo_LeftReturnCol_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> filteredList = new List<string>();

            DataRow[] foundRows = dataDriver.Table.Select();
            string s = combo_LeftReturnCol.SelectedItem.ToString();
            string columnName;
            StringBuilder sb = new StringBuilder();



            foreach (DataRow rec in foundRows)
            {
                columnName = rec[s].ToString();

                if (!filteredList.Contains(columnName))
                {
                    filteredList.Add(columnName);
                    sb.Append(columnName).Append("\n");
                }
            }

            txtbox_LeftPod.Text = sb.ToString();

            combo_LeftFilter1.Items.Clear();
            combo_LeftFilter1.Items.AddRange(dataDriver.header.CSVRow.ToArray());
        }

        private void combo_LeftSign1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_LeftFilter_Click(object sender, EventArgs e)
        {
            string colToFilter = combo_LeftFilter1.SelectedItem.ToString();
            string sign = combo_LeftSign1.SelectedItem.ToString();
            string filterValue = txt_LeftFilter1.Text;
            string query = colToFilter + " " + sign + " " + filterValue;

            if (String.IsNullOrEmpty(colToFilter) || String.IsNullOrEmpty(sign) ||
                String.IsNullOrEmpty(filterValue))
            {
                txtbox_LeftPod.Text = "Nope";
                return;
            }

            List<string> filteredList = new List<string>();
            string columnName;
            DataRow[] foundRows = dataDriver.Table.Select(query);
            string s = combo_LeftReturnCol.SelectedItem.ToString();
            StringBuilder sb = new StringBuilder();
            int p = 0;

            foreach (DataRow rec in foundRows)
            {
                columnName = rec[s].ToString();

                if (!filteredList.Contains(columnName))
                {
                    filteredList.Add(columnName);
                    sb.Append(columnName).Append("\n");
                    p++;
                }
            }

            txtbox_LeftPod.Text = sb.ToString();
            //txtbox_LeftPod.Text = p.ToString();

        }
    }
}
