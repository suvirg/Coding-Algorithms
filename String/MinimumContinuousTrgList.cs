using CodingAlgorithms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Problems
{
    //https://www.careercup.com/question?id=5730069841444864
    //Minimum Continuous Subsequence: targetList & availabletTagsList are two lists of string. 
    //Input: 

    //targetList = {"cat", "dog"};
    //availableTagsList = { "cat", "test", "dog", "get", "spain", "south" }; 

    //Output: [0, 2] //'cat' in position 0; 'dog' in position 2 

    //Input: 

    //targetList = {"east", "in", "south"}; 
    //availableTagsList = { "east", "test", "east", "in", "east", "get", "spain", "south" }; 
    //Output: [2, 6] //'east' in position 2; 'in' in position 3; 'south' in position 6 (east in position 4 is not outputted as it is coming after 'in') 

    public class MinimumContinuousTrgList : IQuestion
    {
        private List<int> FindSubSequence(string []targetList, string[] availableTargetList)
        {
            List<int> result = new List<int>();
            Dictionary<string, int> targetDic = new Dictionary<string, int>();
            int startIndex = -1;
            int endIndex = 0;
            int minWindow = 0;
            int targetListIndex = 0;
            int count = 0;
            foreach(string str in availableTargetList)
            {
                if(targetList[targetListIndex] == str)
                {
                    if (startIndex == -1)
                        startIndex = count;
                    if (targetListIndex == targetList.Length - 1)
                    {
                        endIndex = count;
                        if (minWindow <= endIndex - startIndex)
                        {
                            if (result.Any())
                            {
                                result.Clear();

                            }

                            result.Add(startIndex);
                            result.Add(endIndex);
                        }
                        targetListIndex = 0;
                        startIndex = -1;
                    }
                    targetListIndex++;

                }
                count++;
            }
            return result;

        }

        public void Run()
        {
            // string [] targetList = { "cat", "dog"};
            // string[]  availableTagsList = { "cat", "test", "dog", "get", "spain", "south" };
            string[] targetList =  { "east", "in", "south"};
            string[] availableTagsList = { "east", "thth","ththt","in", "south", "east", "in", "south" };
            var result = FindSubSequence(targetList, availableTagsList);

        }
    }
}
