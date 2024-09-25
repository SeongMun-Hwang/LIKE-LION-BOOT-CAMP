using System;
using static System.Console;

namespace Program
{
    class MainApp
    {
        //#1
        static void Main(string[] args)
        {
            string word;
            bool isPalindrmoe = true;
            word = ReadLine();

            int option;
            WriteLine("Choose Option : 1. Basic  2. Remove White space  3. Don't Check case sensitive");
            option = Read();

            switch (option)
            {
                case '1':
                    break;
                case '2':
                    word = word.Replace(" ", "");
                    break;
                case '3':
                    word = word.ToLower();
                    break;
            }

            for (int i = 0; i < word.Length / 2; i++)
            {
                if (word[i] != word[word.Length - i - 1])
                {
                    isPalindrmoe = false;
                    break;
                }
            }
            if (isPalindrmoe)
            {
                WriteLine(word + " is Palindrome");
            }
            else { WriteLine(word + " is not Palindrome"); }
        }
    }
}