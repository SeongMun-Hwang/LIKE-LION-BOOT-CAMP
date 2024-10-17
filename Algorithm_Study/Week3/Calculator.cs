using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_
{
    public class Calculator
    {
        string expression;
        string postFix;

        public Calculator(string expr)
        {
            expression = expr;
        }
        int GetPriority(char op)
        {
            if (op == '+' || op == '-')
            {
                return 1;
            }
            else if (op == '*' || op == '/')
            {
                return 2;
            }
            return 0;
        }
        public string InfixToPostfix()
        {
            Stack<char> stack = new Stack<char>();
            postFix = "";
            foreach (char c in expression)
            {
                if (char.IsDigit(c))
                {
                    postFix += c;
                }
                else if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    while (stack.Peek() != '(')
                    {
                        postFix += stack.Pop();
                    }
                    stack.Pop();
                }
                else if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    while (!stack.IsEmpty() && GetPriority(stack.Peek()) >= GetPriority(c))
                    {
                        postFix += stack.Pop();
                    }
                    stack.Push(c);
                }
            }
            while (!stack.IsEmpty())
            {
                postFix += stack.Pop();
            }

            return postFix;
        }
    }
}
