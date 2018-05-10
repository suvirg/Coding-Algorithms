using CodingAlgorithms.Contracts;
using CodingAlgorithms.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter02
{
    public class ReverseNodesk_Group : IQuestion
    {
        public LinkedListNode ReverseList(LinkedListNode head, int groupSize)
        {
            LinkedListNode current = head;
            LinkedListNode next = null;
            LinkedListNode prev = null;

            int count = 0;

            /* Reverse first k nodes of linked list */
            while (count < groupSize && current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
                count++;
            }

            /* next is now a pointer to (k+1)th LinkedListNode 
               Recursively call for the list starting from current.
               And make rest of the list as next of first LinkedListNode */
            if (next != null)
                head.Next = ReverseList(next, groupSize);

            // prev is now head of input list
            return prev;
        }


        public void Run()
        {
            int[] Arr = new int[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15};
            var head = AssortedMethods.LinkedListWithValue(15, Arr);
            var resultNode = ReverseList(head, 3);
            while(resultNode != null)
            {
                Console.Write(resultNode.Data + "->");
                resultNode = resultNode.Next;
            }

        }
    }
}
