using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CSV_Peruser.CSV_Items;

namespace CSV_Peruser.Data_Items
{
    /// <summary>
    /// Main data reservoir
    /// </summary>
    class DataDriver
    {

        public DataTable Table { get; set; }

        public Header header;


    }
}
