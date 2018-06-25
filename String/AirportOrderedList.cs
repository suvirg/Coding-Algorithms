using CodingAlgorithms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Problems
{
    public class AirportOrderedList : IQuestion
    {
        // https://www.careercup.com/question?id=5713295334965248

        List<KeyValuePair<string, string>> MakeOrderedList(List<KeyValuePair<string, string>> airportLists)
        {
            var orderedList = new List<KeyValuePair<string, string>>();
            Dictionary<string, string> airportList = new Dictionary<string, string>();
            foreach(var list in airportLists)
            {
                airportList.Add(list.Key, list.Value);
            }
            var currentKey = airportLists[0].Key;
            var currentValue = airportLists[0].Value;
            orderedList.Add(new KeyValuePair<string, string>(currentKey, currentValue));

            while (airportList.Count>0)
            {
                if(airportList.ContainsKey(currentValue))
                {
                    var temp = airportList[currentValue];
                    orderedList.Add(new KeyValuePair<string, string>(currentValue , temp));
                    airportList.Remove(currentKey);
                    airportList.Remove(currentValue);
                    currentKey = currentValue;
                    currentValue = temp;
                    
                }
            }

            return orderedList;
        }

        public void Run()
        {
            // ("ITO", "KOA"), ("ANC", "SEA"), ("LGA", "CDG"), ("KOA", "LGA"), 
            // ("PDX", "ITO"), ("SEA", "PDX"))
            var unorderedList = new List<KeyValuePair<string, string>>();
            unorderedList.Add(new KeyValuePair<string, string>("ANC", "SEA"));
            unorderedList.Add(new KeyValuePair<string, string>("ITO", "KOA"));
            unorderedList.Add(new KeyValuePair<string, string>("LGA", "CDG"));
            unorderedList.Add(new KeyValuePair<string, string>("KOA", "LGA"));
            unorderedList.Add(new KeyValuePair<string, string>("PDX", "ITO"));
            unorderedList.Add(new KeyValuePair<string, string>("SEA", "PDX"));
            var results = MakeOrderedList(unorderedList);

            foreach (var item in results)
            {
                Console.WriteLine("ordered list {0},{1}", item.Key, item.Value);
            }
        }
    }
}
