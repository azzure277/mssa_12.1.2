using System;

namespace mssa_12._1._2
{
    // Definition for singly-linked list node
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

    public class LinkedList
    {
        public ListNode head;

        public void AddLast(int val)
        {
            if (head == null)
            {
                head = new ListNode(val);
                return;
            }
            var current = head;
            while (current.next != null)
                current = current.next;
            current.next = new ListNode(val);
        }

        // Checks if the linked list is a palindrome
        public bool IsPalindrome()
        {
            // Fast/slow pointer to find middle
            ListNode slow = head, fast = head;
            var stack = new System.Collections.Generic.Stack<int>();
            while (fast != null && fast.next != null)
            {
                stack.Push(slow.val);
                slow = slow.next;
                fast = fast.next.next;
            }
            // Odd number of nodes, skip the middle
            if (fast != null)
                slow = slow.next;
            while (slow != null)
            {
                if (stack.Pop() != slow.val)
                    return false;
                slow = slow.next;
            }
            return true;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(2);
            list.AddLast(1);
            Console.WriteLine($"Is palindrome: {list.IsPalindrome()}"); // Output: True
        }
    }
}
