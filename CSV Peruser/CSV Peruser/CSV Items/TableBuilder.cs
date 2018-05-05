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

        public TableBuilder(string path)
        {
            this._path = path;
            this.Rows = new List<Row>();
        }

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

                    while ((line = readFile.ReadLine()) != null && j < 100)
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

        public DataTable Build()
        {
            DataTable dataTable = new DataTable();

            foreach(string rec in this.HeaderMain.CSVRow)
            {
                dataTable.Columns.Add(rec, typeof(string));
            }

            for(int i =0; i < 10; i++)
            {
                dataTable.Columns.Add("NOPE "+i, typeof(string));
            }

            foreach(Row rec in this.Rows)
            {
                dataTable.Rows.Add(rec.CSVRow.ToArray());
            }

            return dataTable;
        }
    }
}
