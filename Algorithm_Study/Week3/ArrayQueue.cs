using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_
{
    public class ArrayQueue<T>
    {
        T[] array;
        int front;
        int rear;
        int maxSize;
        int count;
        public ArrayQueue(int size)
        {
            this.array = new T[size];
            maxSize = size;
            front = 0;
            rear = -1;
        }

        public void Enqueue(T item)
        {
            if (isFull())
            {
                Console.WriteLine("Queue Fulled");
                return;
            }
            rear = (rear + 1) % maxSize;
            array[rear] = item;
            count++;
        }

        public T Dequeue()
        {
            if (isEmpty())
            {
                Console.WriteLine("Empty");
                return default;
            }
            T item = array[front];
            front = (front + 1) % maxSize;
            count--;
            return item;
        }

        public bool isEmpty()
        {
            return count == 0;
        }

        public bool isFull()
        {
            return count == maxSize;
        }
        public void Print()
        {
            if (array == null || count == 0)
            {
                Console.WriteLine("Queue Blanked");
                return;
            }
            for (int i = 0; i < count; i++)
            {
                Console.Write(array[i] + " -> ");
            }
            Console.WriteLine("null");
        }
    }
}
