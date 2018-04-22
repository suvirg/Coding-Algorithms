using System;
using System.Collections.Generic;
using System.Text;

namespace CodingAlgorithms.Library
{
    public class GetString
    {
        public string GetStringFrom(string str)
        {
            char[] strArray = new char[str.Length];
            StringBuilder result = new StringBuilder();

            strArray = str.ToCharArray();

            int a = 'A' - str[0];

            for (int i = 0; i < strArray.Length; i++)
            {
                strArray[i] = Convert.ToChar(str[i] + a);
                result.Append(strArray[i].ToString());
            }

            return result.ToString();


        }

    }
}
