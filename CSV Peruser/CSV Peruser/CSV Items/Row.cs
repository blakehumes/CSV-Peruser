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
        public List<string> CSVRow { get; set; }

        public static char delimiter = ',';
        public static int firstNumber = 99999;

        /// <summary>
        /// Create Row object
        /// </summary>
        /// <param name="line">row from CSV file</param>
        public Row(string line)
        {
            this.CSVRow = new List<string>();

            this.WriteRow(line);
        }

        /// <summary>
        /// Write row from CSV file to Row Object
        /// </summary>
        /// <param name="r">line of a CSV file</param>
        public void WriteRow(string r)
        {
            r = r.TrimEnd(Row.delimiter);
            Stream stream = Utility.GetStream(r);
            int leastInt = 0;
            bool foundInt = false;
            int j = 0;
            double testDouble;
                

            using (TextFieldParser parser = new TextFieldParser(stream))
            {
                parser.Delimiters = new string[] { "," };
                string[] row = parser.ReadFields();

                string temp = "";

                foreach (string rec in row)
                {
                    temp = CleanString(rec);
                    this.CSVRow.Add(temp);
                    if(Double.TryParse(temp, out testDouble))
                    {
                        leastInt = j;
                        foundInt = true;
                    }

                    j++;
                }
            }

            if (foundInt == false) leastInt = j + 1;
            if(firstNumber > leastInt) firstNumber = leastInt;
            Console.WriteLine(firstNumber);
        }

        /// <summary>
        /// Cleans the string before adding to the the row
        /// </summary>
        /// <param name="s">string to be cleaned</param>
        /// <returns></returns>
        public static string CleanString(string s)
        {
            s = s.Trim();
            s = s.Replace("\"", string.Empty);
            return s;
        }
    }
}

