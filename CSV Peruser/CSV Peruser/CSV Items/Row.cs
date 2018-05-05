using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CSV_Peruser.Data_Items;
using Microsoft.VisualBasic.FileIO;

namespace CSV_Peruser.CSV_Items
{
    class Row
    {
        public List<string> DataRow { get; set; }

        public static char delimiter = ',';

        public Row(string line)
        {
            this.DataRow = new List<string>();

            this.WriteRow(line);
        }

        public void WriteRow(string r)
        {
            r = r.TrimEnd(Row.delimiter);
            Stream stream = Utility.GetStream(r);
                

            using (TextFieldParser parser = new TextFieldParser(stream))
            {
                parser.Delimiters = new string[] { "," };
                string[] row = parser.ReadFields();

                string temp = "";

                foreach (string rec in row)
                {
                    temp = CleanString(rec);
                    this.DataRow.Add(temp);
                }
            }
        }

        public static string CleanString(string s)
        {
            s = s.Trim();
            s = s.Replace("\"", string.Empty);
            return s;
        }
    }
}

