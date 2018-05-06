using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CSV_Peruser.CSV_Items;

namespace CSV_Peruser.Data_Items
{
    class DataDriver
    {
        public DataPod leftPod = new DataPod();
        public DataPod rightPod = new DataPod();

        public DataTable Table { get; set; }

        public Header header;


    }
}
