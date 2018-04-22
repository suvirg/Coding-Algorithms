using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctci.Library
{
    public class SortString
    {
        public static string Sort(string str)
        {
            char[] strArr = str.ToCharArray();

            Array.Sort(strArr);
            return new string(strArr);

        }

    }
}
