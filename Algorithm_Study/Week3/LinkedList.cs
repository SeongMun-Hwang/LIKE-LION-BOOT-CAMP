using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_
{
    public class LinkedListNode<T>
    {
        public T Data;
        public LinkedListNode<T> Next;
        public LinkedListNode(T data)
        {
            Data = data;
            Next = null;
        }
    }
    public class LinkedList<T>
    {
        private LinkedListNode<T> head;
        public LinkedList()
        {
            head = null;
        }
        public void Add(T data)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(data);

            if (head == null)
            {
                head = node;
            }
            else
            {
                LinkedListNode<T> current = head;
                while(current.Next!= null)
                {
                    current = current.Next;
                }
                current.Next = node;
            }
        }
        public void Print()
        {
            if(head == null)
            {
                Console.WriteLine("Linked List is empty");
                return;
            }
            LinkedListNode<T> current = head;
            while(current != null)
            {
                Console.Write(current.Data + " -> ");
                current = current.Next;
            }
            Console.WriteLine("Null");
        }

        public void Remove(T data)
        {
            if (head == null)
            {
                Console.WriteLine("Linked List is empty");
                return;
            }
            if (head.Data.Equals(data))
            {
                head = head.Next;
                return;
            }
            LinkedListNode<T> current = head;
            LinkedListNode<T> previous = null;

            while(current!=null && !current.Data.Equals(data))
            {
                previous = current;
                current=current.Next;
            }
            if (current == null)
            {
                Console.WriteLine("There's no data");
            }
            else
            {
                previous.Next = current.Next;
            }
        }
    }
}
