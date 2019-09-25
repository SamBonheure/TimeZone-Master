using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone
{
    class Program
    {        
        static void Main(string[] args)
        {
            List<Tuple<string, string>> lTimes;
            using (Reader fileReader = new Reader())
            {
                lTimes = fileReader.Read();
            }

            Parser timeZoneParser = new Parser();
            foreach (var time in lTimes)
            {
                timeZoneParser.DisplayTime(time.Item1, time.Item2);
            }

            // Keep console open for validation
            Console.Read();
        }
    }
}
