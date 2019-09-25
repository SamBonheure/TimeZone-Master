using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone
{
    class Parser : IParser
    {
        /// <summary>
        /// Display the uk time and the converted time for the appropriate timezone
        /// </summary>
        /// <param name="time">UK time</param>
        /// <param name="timezone">The timezone to convert to</param>
        public void DisplayTime(string time, string timezone)
        {
            var convertedTimeZone = TimeZoneInfo.GetSystemTimeZones().FirstOrDefault(t => t.DisplayName.Contains(timezone));

            if (convertedTimeZone == null)
            {
                Console.WriteLine("Could not find timezone with name: " + timezone);
                return;
            }
            else if (!TimeSpan.TryParse(time, out var timespan))
            {
                Console.WriteLine("The following time format is incorrect: " + time);
                return;
            }

            TimeSpan offset = convertedTimeZone.GetUtcOffset(DateTime.UtcNow);
            DateTime ukTime = Convert.ToDateTime(time);
            DateTime convertedTime = ukTime.Add(offset);

            string result = string.Format("The time in the UK is {0} and the time in {1} is {2}", time, timezone, convertedTime.ToLongTimeString());
            Console.WriteLine(result);
        }
    }
}
