using System;

namespace MyLinkedList
{

    public class MyLinkedList<T>
    {
        private class Node
        {
            public T value;
            public Node next;
        }

        private Node Head;

        public MyLinkedList()
        {
            Head = null;
        }

        public int Size()
        {
            int count = 0;
            Node first = Head;

            while (first != null)
            {
                count++;
                first = first.next;
            }
            return count;
        }

        public void Insert(T value)
        {
            Node newNode = new Node();
            newNode.value = value;

            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                Node first = Head;
                while (first.next != null)
                {
                    first = first.next;
                }
                first.next = newNode;
            }
        }

        public void InsertAt(int position, T value)
        {
            Node newNode = new Node();
            newNode.value = value;

            if (position == 1)
            {
                newNode.next = Head;
                Head = newNode;
            }
            else if (position > Size() || position == 0)
            {
                Console.WriteLine("Position Not in the list");
                return;
            }
            else
            {
                Node first = Head;

                for (int i = 1; i < position - 1; i++)
                {
                    first = first.next;
                }
                newNode.next = first.next;
                first.next = newNode;
            }
        }

        public void Print()
        {
            var headOfList = Head;
            try
            {
                while (headOfList.next != null)
                {
                    Console.Write(headOfList.value + " -> ");
                    headOfList = headOfList.next;
                }
                Console.Write(headOfList.value + "\n");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Linked List is empty");
            }
        }

        public void Delete(T value)
        {
            Node previous = null;
            Node first = Head;
            try
            {
                if (Head == null)
                {
                    Console.WriteLine("\nList is empty");
                    return;
                }

                if (first != null && first.value.Equals(value))
                {
                    Head = first.next;
                    return;
                }

                while (first != null && !(first.value.Equals(value)))
                {
                    previous = first;
                    first = first.next;
                }
                previous.next = first.next;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("\n" +
                    "Element not in the list");
            }

        }

        public void DeleteAt(int position)
        {
            int size = Size();
            Node first = Head;
            Node temp = null;

            // If the given position is not in the linked List
            if (position > size || position == 0)
            {
                Console.WriteLine("Position is not in the Linked List");
                return;
            }
            // Delete at head if position = 1
            else if (position == 1)
            {
                Head = first.next;
                return;
            }
            for (int i = 1; i < position - 1; i++)
            {
                first = first.next;
            }
            temp = first.next.next;
            first.next.next = null;
            first.next = temp;
        }

        public  T ElementAtPosition(int position)
        {
            Node first = Head;
            for(int i = 1; i < position; i++)
            {
                first = first.next;
            }
            return first.value;
        }

        public void Center()
        {
            Node first = Head;
            int size = Size();
            int middle;
            // Check if list is empty or not
            if (first == null)
            {
                Console.WriteLine("List is Empty");
            }
            else
            {
                // If list has odd number of elements
                if (size % 2 != 0)
                {
                    middle = size / 2;
                    for (int i = 0; i < middle; i++)
                    {
                        first = first.next;
                    }
                    Console.WriteLine("Value at center: " + first.value);
                }
                // Else with list of even number of elements
                else
                {
                    Console.WriteLine("List size is Even. Hence no center in the list");
                }
            }
        }

        public void Reverse()
        {
            Node previous = null;
            Node current = Head;
            Node temp = null;
            // Checking if list is empty or not
            if (current == null)
            {
                Console.WriteLine("\nList is Empty");
                return;
            }
            // Reversing the list
            while (current != null)
            {
                temp = current.next;
                current.next = previous;
                previous = current;
                current = temp;
            }

            Head = previous;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nOperation Successful");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Iterator(MyLinkedList<T> myList)
        {
            MyLinkedList<T>.Enumerator enumerator = GetEnumerator();
            enumerator.Reset();
            Console.WriteLine("\nPriority Queue using Iterator: ");
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }
        public Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        public class Enumerator
        {
            private Node current;
            private MyLinkedList<T> myList;

            public Enumerator(MyLinkedList<T> list)
            {
                myList = list;
                Reset();
            }

            public void Reset()
            {
                current = null;
            }

            public T Current
            {
                get
                {
                    return current.value;
                }
            }

            public bool MoveNext()
            {
                if (current == null)
                {
                    current = myList.Head;
                }
                else
                {
                    current = current.next;
                }
                return (current != null);
            }

            
        }

    }
}
