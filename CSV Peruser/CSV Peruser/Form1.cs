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

                List<string> headerList = new List<string>();
                dataDriver.header = tb.HeaderMain;
                string[] headerNames = dataDriver.header.CSVRow.ToArray();

                combo_LeftReturnCol.Items.AddRange(headerNames);
                dataDriver.Table = tb.Build();
                data_Grid.DataSource = dataDriver.Table;
                
            }
            else
            {
                MessageBox.Show("File type error. Please select a CSV file.", "File Error", MessageBoxButtons.OK);
                btn_Load.Visible = false;
            }

            txtbox_LeftPod.Text = dataDriver.Table.Columns[47].DataType.ToString();
        }

        // Executes when file is selected
        private void btn_Browse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtbx_Filepath.Text = openFileDialog1.FileName;
                btn_Load.Visible = true;
                combo_Delimeter.SelectedIndex = 0;

            }
        }

        // Event when the column header filter combo box is changed
        // Dynamic updates to left most text box
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

            txt_LeftFilter1.Text = "";
            combo_LeftSign1.Items.Clear();
            combo_LeftSign1.Items.AddRange(new string[] { "<", "<=", "=", ">=", ">" });
        }

        // Event executes when the Return Column is select
        // This is the column whose data appears in the left most text box
        private void combo_LeftReturnCol_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> filteredList = new List<string>();

            DataRow[] foundRows = dataDriver.Table.Select();
            string s = combo_LeftReturnCol.SelectedItem.ToString();
            string rowName;
            StringBuilder sb = new StringBuilder();



            foreach (DataRow rec in foundRows)
            {
                rowName = rec[s].ToString();

                if (!filteredList.Contains(rowName))
                {
                    filteredList.Add(rowName);
                    sb.Append(rowName).Append("\n");
                }
            }

            txtbox_LeftPod.Text = sb.ToString();

            combo_LeftFilter1.Items.Clear();
            combo_LeftFilter1.Items.AddRange(dataDriver.header.CSVRow.ToArray());
        }

        private void combo_LeftSign1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Attempts to filter the leftmost text box to only show rows that meet the filter criteria
        // Returns if null or incorrect values occur to avoid exception
        private void btn_LeftFilter_Click(object sender, EventArgs e)
        {
            if (combo_LeftFilter1.SelectedItem == null|| combo_LeftSign1.SelectedItem == null ||
                String.IsNullOrEmpty(txt_LeftFilter1.Text)) return;

            double testDoub;

            if (!Double.TryParse(txt_LeftFilter1.Text, out testDoub)) return;

            string colToFilter = combo_LeftFilter1.SelectedItem.ToString();
            string sign = combo_LeftSign1.SelectedItem.ToString();
            string filterValue = txt_LeftFilter1.Text;
            string query = colToFilter + " " + sign + " " + filterValue;

            if (String.IsNullOrEmpty(colToFilter) || String.IsNullOrEmpty(sign) ||
                String.IsNullOrEmpty(filterValue))
            {
                return;
            }

            List<string> filteredList = new List<string>();
            string rowName;
            string rowName2;
            DataRow[] foundRows = dataDriver.Table.Select(query);
            string s = combo_LeftReturnCol.SelectedItem.ToString();
            string s2 = combo_LeftFilter1.SelectedItem.ToString();
            StringBuilder sb = new StringBuilder();
            int p = 0;

            foreach (DataRow rec in foundRows)
            {
                rowName = rec[s].ToString();
                rowName2 = rec[s2].ToString();

                if (!filteredList.Contains(rowName))
                {
                    filteredList.Add(rowName);
                    sb.Append(rowName).Append(" - ").Append(rowName2).Append("\n");
                    p++;
                }
            }

            txtbox_LeftPod.Text = sb.ToString();

        }
    }
}
