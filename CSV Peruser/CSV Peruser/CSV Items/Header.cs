using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Peruser.CSV_Items
{
    class Header: Row
    {
        private int _columnCount = 0;

        public Header(string line) : base(line) { }
        
    }
}
