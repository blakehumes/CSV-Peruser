using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Peruser.CSV_Items
{
    class Header
    {
        public List<string> DataRow { get; set; }

        public Header(string line)
        {
            this.DataRow = new List<string>();

            this.AddRow(line, ',');
        }

        public void AddRow(string r, char c)
        {
            string[] row = r.Split(c);

            string temp = "";

            foreach(string rec in row)
            {
                temp = CleanString(rec);
                this.DataRow.Add(temp);
            }
        }

        public static string CleanString(string s)
        {
            s = s.Trim();
            return s;
        }
    }
}
