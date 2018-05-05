using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSV_Peruser.CSV_Items
{
    class TableBuilder
    {
        public Header HeaderMain { get; set; }

        public List<Row> Rows { get; set; }

        private string _path;

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
                    string line = readFile.ReadLine();
                    HeaderMain = new Header(line);
                    int j = 0;

                    while ((line = readFile.ReadLine()) != null && j < 5)
                    {
                        Rows.Add(new Row(line));
                        j++;
                    }
                }
            }
            catch (IOException ioex)
            {
                
            }
        }
    }
}
