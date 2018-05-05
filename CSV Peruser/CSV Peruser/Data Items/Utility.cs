using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSV_Peruser.Data_Items;
using System.IO;

namespace CSV_Peruser.Data_Items
{
    public static class Utility
    {
        public static Stream GetStream(string line)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(line);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
