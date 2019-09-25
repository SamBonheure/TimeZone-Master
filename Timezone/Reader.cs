using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Timezone
{
    class Reader<T, T2> : IReader<T, T2>, IDisposable
    {
        /// <summary>
        /// Read a text file of times and split accordingly
        /// </summary>
        /// <returns>List of times and timeszones to convert to</returns>
        public List<Tuple<T, T2>> Read()
        {
            List<Tuple<T, T2>> lReturn = new List<Tuple<T, T2>>();
            var assembly = Assembly.GetExecutingAssembly();
            string[] fileParts;

            // Search for resource dynamically and include namespacing
            string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("Timezone.txt"));

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                fileParts = reader.ReadToEnd().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (string part in fileParts)
            {
                string[] sLineParts = part.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        
                Tuple<T, T2> timeZone = new Tuple<T, T2>((T)Convert.ChangeType(sLineParts.First(), typeof(T)), (T2)Convert.ChangeType(sLineParts.Last(), typeof(T2)));

                lReturn.Add(timeZone);
            }

            return lReturn;
        }

        public void Dispose()
        {
        }
    }
}
