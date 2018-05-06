using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using Microsoft.VisualBasic.FileIO;
using CSV_Peruser;

namespace CSV_Peruser.CSV_Items
{
    class TableBuilder
    {
        public Header HeaderMain { get; set; }

        public List<Row> Rows { get; set; }

        private string _path;
        public bool fileReadGood = false;

        /// <summary>
        /// Creates instance of tablebuilder class
        /// </summary>
        /// <param name="path">filepath for CSV</param>
        public TableBuilder(string path)
        {
            this._path = path;
            this.Rows = new List<Row>();
        }

        /// <summary>
        /// Populates the Header and Row classes attached to the TB object
        /// </summary>
        public void Populate()
        {
           

            try
            {
                using (StreamReader readFile = new StreamReader(this._path))
                {
                    fileReadGood = true;
                    string line = readFile.ReadLine();
                    HeaderMain = new Header(line);
                    int j = 0;

                    while ((line = readFile.ReadLine()) != null && j < 5000)
                    {

                        Rows.Add(new Row(line));
                        j++;
                    }
                }
            }
            catch (IOException ioex)
            {
                fileReadGood = false;
            }
        }

        /// <summary>
        /// Creates Datatable from the Header and Rows attached to the TB object
        /// </summary>
        /// <returns>Datatable of the CSV file</returns>
        public DataTable Build()
        {
            DataTable dataTable = new DataTable();
            int i = 0;

            foreach(string rec in this.HeaderMain.CSVRow)
            {
                if (i < Row.firstNumber)
                {
                    dataTable.Columns.Add(rec, typeof(string));
                }
                else
                {
                    dataTable.Columns.Add(rec, typeof(Double));
             
                }
                i++;
            }

            foreach(Row rec in this.Rows)
            {
                i = 0;
                List<string> rowToAdd = new List<string>();
                Object[] ArrayOfObjects = new Object[this.HeaderMain.CSVRow.Count]; 
                foreach (string rec1 in rec.CSVRow)
                {
                    if (i >= Row.firstNumber && String.IsNullOrEmpty(rec1))
                    {
                        ArrayOfObjects[i] = 0;
                        

                    }
                    else if(i >= Row.firstNumber)
                    {
                        double temp = 0;
                        Double.TryParse(rec1, out temp);
                        ArrayOfObjects[i] = temp;
                    }
                    else
                    {
                        ArrayOfObjects[i] = rec1;
                    }
                    i++;
                }
                dataTable.Rows.Add(ArrayOfObjects);
            }

            return dataTable;
        }
    }
}
