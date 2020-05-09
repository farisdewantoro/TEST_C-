using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace C_SHARP_LEETCODE_TEST
{
   public class Linked_List_Add_Two_Numbers
    {

        //[2,4,3]
        //[5,6,4]
        // hasil : 2+5 7, 4+6= 10 -> 0, 3+4+1 = 8;

        //[2,4,3]
        //[5,6]
        // hasil : 2+5 7, 4+6= 10 -> 0, 3+1+0 = 4;

        //[2,4,3]
        //[]
        // hasil : 2+0=2, 4+0=4, 3+0 =3;
        [Fact]
        public void Test()
        {

            ListNode node1 = new ListNode(2, new ListNode(4, new ListNode(3)));
            ListNode node2 = new ListNode(5, new ListNode(6));
            var result = AddTwoNumbers(node1, node2);
            string printResult = PrintAllNodes(result);
            Assert.True(printResult == "704");

        }



        static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode dummyHead = new ListNode(0);
            ListNode p = l1;
            ListNode q = l2;
            ListNode curr = dummyHead;
            int carry = 0;
            while (p != null || q != null)
            {
                int x = (p != null) ? p.val : 0;
                int y = (q != null) ? q.val : 0;
                int sum = x + y + carry;
                carry = sum / 10;
                curr.next = new ListNode(sum % 10);
                curr = curr.next;
                if (p != null)
                    p = p.next;
                if (q != null)
                    q = q.next;
            }
            if (carry > 0)
            {
                curr.next = new ListNode(carry);
            }
            return dummyHead.next;
        }
        static string PrintAllNodes(ListNode result)
        {
            string response = String.Empty;
            while (result != null)
            {
                response += result.val;
                result = result.next;
            }
            return response;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
