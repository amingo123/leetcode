using System;
using Utility;

namespace _2._Add_Two_Numbers
{
    class Program : BaseProgram
    {
        static void Main(string[] args)
        {
            ListNode l1 = new ListNode(2);
            ListNode l11 = new ListNode(4);
            ListNode l111 = new ListNode(3);
            l1.next = l11;
            l11.next = l111;

            ListNode l2 = new ListNode(5);
            ListNode l22 = new ListNode(6);
            ListNode l222 = new ListNode(4);
            l2.next = l22;
            l22.next = l222;

            ListNode ln = Solution.AddTwoNumbers(l1, l2);
            PrintListNode(ln);

            ln = Solution.AddTwoNumbers(new ListNode(5), new ListNode(5));
            PrintListNode(ln);
            Read();
        }

        static void PrintListNode(ListNode ln)
        {
            while (ln != null)
            {
                Write(ln.val);
                ln = ln.next;
            }
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public static class Solution
    {
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode(0);
            int temp = 0;
            bool carry = false;           
            ListNode head = result;

            while (l1 != null && l2 != null)
            {
                temp = l1.val + l2.val + (carry ? 1 : 0);
                if (temp >= 10)
                {
                    result.next = new ListNode(temp % 10);
                    carry = true;
                }
                else
                {
                    result.next = new ListNode(temp);
                    carry = false;
                }
                l1 = l1.next;
                l2 = l2.next;
                result = result.next;
            }

            while (l1 != null)
            {
                temp = l1.val + (carry ? 1 : 0);
                if (temp >= 10)
                {
                    result.next = new ListNode(temp % 10);
                    carry = true;
                }
                else
                {                   
                    result.next = new ListNode(temp);
                    carry = false;
                }
                l1 = l1.next;
                result = result.next;
            }

            while (l2 != null)
            {
                temp = l2.val + (carry ? 1 : 0);
                if (temp >= 10)
                {
                    result.next = new ListNode(temp % 10);
                    carry = true;
                }
                else
                {
                    result.next = new ListNode(temp);
                    carry = false;
                }
                l2 = l2.next;
                result = result.next;
            }

            if (carry)
            {
                result.next = new ListNode(1);
            }

            return head.next;
        }
    }
}
