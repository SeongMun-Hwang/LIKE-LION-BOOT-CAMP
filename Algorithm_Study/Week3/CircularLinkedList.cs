using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_
{
    public class CircularLinkedList<T>
    {
        private Node<T> tail;

        public CircularLinkedList()
        {
            tail = null;
        }
        public void Add(T data)
        {
            Node<T> newNode=new Node<T>(data);
            if (tail == null)
            {
                tail = newNode;
                tail.Next = tail;
            }
            else
            {
                newNode.Next = tail.Next;
                tail.Next = newNode;
                tail = newNode;
            }
        }
        public void Print()
        {
            if(tail == null)
            {
                Console.WriteLine("Empty");
            }
            Node<T> current = tail.Next;
            do
            {
                Console.Write(current.Data + " -> ");
                current = current.Next;
            } while (current != tail.Next);

            Console.WriteLine("(head)");
        }
        public class Node<T>
        {
            public T Data;
            public Node<T> Next;

            public Node(T Data)
            {
                this.Data = Data;
                Next = null;
            }
        }
    }
}
