using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace HL7
{
    static class ITPSystem
    {
        public static void Log(string msg)
        {
            File.AppendAllLines(@"C:\LOG\log.txt", new[] { msg });
        }
        public static IEnumerable<string> ReadFile(string path)
        {

            var lines = File.ReadLines(path);

            return lines;
        }
    }
}
