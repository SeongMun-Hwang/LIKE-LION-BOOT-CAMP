using System;
using static System.Console;

namespace Program
{
    class MainApp
    {
        static void Main(string[] args)
        {
            string str= ReadLine();
            bool isPalindrome = true;
            for(int i=0; i < str.Length /2; i++)
            {
                if(str[i] != str[str.Length - 1 - i])
                {
                    isPalindrome = false;
                    break;
                }
            }
            if(isPalindrome)
            {
                WriteLine("1");
            }
            else { WriteLine("0"); }
        }
    }
}