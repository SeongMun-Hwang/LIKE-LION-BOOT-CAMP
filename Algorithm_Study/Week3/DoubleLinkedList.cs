using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_
{
    public class DoubleLinkedList<T>
    {
        Node<T> head;
        Node<T> tail;

        public DoubleLinkedList()
        {
            head = null;
            tail = null;
        }

        public void AddFirst(T data)
        {
            Node<T> current = new Node<T>(data);
            if(head == null)
            {
                head = current;
                tail = current;
            }
            else
            {
                current.Next = head;
                head.Prev = current;
                head = current;                
            }
        }
        public void AddLast(T data)
        {
            Node<T> current=new Node<T>(data);
            if(tail== null)
            {
                tail = current;
                head=current;
            }
            else
            {
                tail.Next= current;
                current.Prev = tail;
                tail = current;
            }
        }

        public void Remove(T data)
        {
            if (head == null)
            {
                Console.WriteLine("empty");
                return;
            }
            Node<T> current = head;
            while(current != null && !current.Data.Equals(data)){
                current = current.Next;
            }

            if (current == null)
            {
                Console.WriteLine("There's no data");
                return;
            }
            if (current.Prev != null)
            {
                current.Prev.Next = current.Next;
            }
            else
            {
                head = current.Next;
            }
            if(current.Next!= null)
            {
                current.Next.Prev = current.Prev;
            }
            else
            {
                tail = current.Prev;
            }
        }
        public void Print()
        {
            if (head == null)
            {
                Console.WriteLine("Linked List is empty");
                return;
            }
            Node<T> current = head;
            while (current != null)
            {
                Console.Write(current.Data + " -> ");
                current = current.Next;
            }
            Console.WriteLine("Null");
        }

        public class Node<T>
        {
            public T Data;
            public Node<T> Prev;
            public Node<T> Next;

            public Node(T Data)
            {
                this.Data = Data;
            }
        }      
    }
}
