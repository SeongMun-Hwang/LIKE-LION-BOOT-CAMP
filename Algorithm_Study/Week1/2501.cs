using System;
using static System.Console;

namespace Program
{
    class MainApp
    {
        static void Main(string[] args)
        {
            string[] inputs = ReadLine().Split();
            int num = int.Parse(inputs[0]);
            int k = int.Parse(inputs[1]);

            List<int> list = new List<int>();

            for (int i = 1; i <= num; i++)
            {
                if (num % i == 0)
                {
                    list.Add(i);
                }
            }
            if (k > list.Count)
            {
                WriteLine("0");
            }
            else
            {
                WriteLine(list[k - 1]);
            }
        }
    }
}