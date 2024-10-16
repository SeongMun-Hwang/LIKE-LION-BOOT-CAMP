using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_
{
    public class ArrayStack<T>
    {
        T[] array;
        int maxSize;
        int top;

        public ArrayStack(int size = 10)
        {
            array = new T[size];
            maxSize = size;
            top = -1;
        }
        public void Push(T item)
        {
            if (top >= maxSize - 1)
            {
                Console.WriteLine("Stack Fulled");
                return;
            }
            top++;
            array[top] = item;
        }
        public T Pop()
        {
            if (top < 0)
            {
                Console.WriteLine("Empty");
            }
            return array[top--];
        }
        public void Print()
        {
            for(int i=0;i<=top;i++)
            {
                Console.WriteLine((array[i]+" ");
            }
            Console.WriteLine();

        }
    }
}
