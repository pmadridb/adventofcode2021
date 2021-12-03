using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Util
{
    public static string[] GetLines(string Filename)
    {
        return System.IO.File.ReadAllLines(@"c:\Users\pmadrid\Documents\GitHub\adventofcode2021\" + Filename);
    }
}
