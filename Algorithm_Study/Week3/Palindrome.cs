using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_
{
    internal class Palindrome
    {
        public static bool IsPalindrome(string str)
        {
            Stack<char> stack = new Stack<char>();
            Queue<char> queue = new Queue<char>();

            foreach(char c in str)
            {
                stack.Push(c);
                queue.Enqueue(c);
            }
            while (!stack.IsEmpty())
            {
                if (stack.Pop() != queue.Dequeue())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
