using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class AoCMethods{
    public static string Injest(string input) {
        return input.Replace("\n", "").Replace("\r", "").Replace(" ", "");
    }
}