using System;
using System.Collections.Generic;
using MyLinkedList;

namespace MyPriorityQueue
{
    class MyPriorityQueue<T>
    {
        // Defining our Priority Queue Node
        private class QueueNode
        {
            public uint priority;
            public T value;
        }
        // Implementing Priority Queue Using Linked List which we created earlier
        private MyLinkedList<QueueNode> queue;
        private int count = 0,reverse = 0;
        
        // Default constructor calling the linked list
        public MyPriorityQueue()
        {
            queue = new MyLinkedList<QueueNode>();
        }
        // Priority should be positive so take uint
        public void Enqueue(uint priority,T value)
        {
            // Define the new node which we want to insert
            QueueNode newNode = new QueueNode();
            newNode.priority = priority;
            newNode.value = value;
            // Give default position = 1 to traverse from start
            int position = 1;
            // If list is empty insert at the start
            if(count == 0)
            {
                queue.Insert(newNode);
                count++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nOperation Successful");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            // If queue is not reversed 
            if (reverse % 2 == 0)
            {
                foreach(var i in queue)
                {
                    if (i.priority > priority)
                    {
                        queue.InsertAt(position,newNode);
                        count++;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nOperation Successful");
                        Console.ForegroundColor = ConsoleColor.White;
                        return;
                    }
                    position++;
                }              
            }
            // If queue is reversed the it would be in decreasing order of its priority in the Linked List so we traverse it differently
            else
            {
                foreach (var i in queue)
                {
                    if (i.priority < priority)
                    {
                        queue.InsertAt(position, newNode);
                        count++;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nOperation Successful");
                        Console.ForegroundColor = ConsoleColor.White;
                        return;
                    }
                    position++;
                }
            }
            queue.Insert(newNode);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nOperation Successful");
            Console.ForegroundColor = ConsoleColor.White;
            // Increment size of queue if element is enqueued
            count++;
        }

        public void Dequeue()
        {
            if (count == 0)
            {
                Console.WriteLine("\nQueue is empty");
                return;
            }
            // If queue is not reversed the first element is the one with highest priority
            if (reverse % 2 == 0)
            {
                queue.DeleteAt(1);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nOperation Successful");
                Console.ForegroundColor = ConsoleColor.White;
            }
            // If queue is reversed the last element is of highest priority
            else
            {
                queue.DeleteAt(count);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nOperation Successful");
                Console.ForegroundColor = ConsoleColor.White;
            }
            // Decrement size of queue if element is dequeued
            count--;
        }

        public void Peek()
        {
            if (count == 0)
            {
                Console.WriteLine("\nQueue is Empty");
                return;
            }
            // If queue is not reversed the first element is the one with highest priority
            if (reverse % 2 == 0)
            {
                var element = queue.ElementAtPosition(1);
                Console.WriteLine("\nItem with highest priority: Value: {0} --> Priority: {1}",element.value,element.priority);
            }
            // If queue is reversed the lstelement is the one with highest priority
            else
            {
                var element = queue.ElementAtPosition(count);
                Console.WriteLine("\nItem with highest priority: Value: {0} --> Priority: {1}", element.value, element.priority);
            }
        }

        public int Size()
        {
            return count;
        }

        public bool Contains(T value)
        {
            int flag = 0; 
            foreach(var i in queue)
            {
                if (i.value.Equals(value))
                {
                    flag = 1;
                }
            }
            if (flag == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reverse()
        {
           if(count == 0)
           {
                Console.WriteLine("\nQueue is Empty");
           }
           else
           {
                queue.Reverse();
                // Increment the reverse if the queue is reversed
                reverse++;
           }
        }
        

        public void Print()
        {
            if (count == 0)
            {
                Console.WriteLine("\nQueue is Empty");
                return;
            }

            int index = 1;
            Console.WriteLine("\nQueue: \n");
            foreach(var i in queue)
            {
                Console.WriteLine("Item {0} - Priority: {1}, Value:{2}",index,i.priority,i.value);
                index++;
            }
        }

        public void Iterator()
        {
            if (count == 0)
            {
                Console.WriteLine("\nQueue is Empty");
                return;
            }
            // Call the enumerator we made in our linked list 
            MyLinkedList<QueueNode>.Enumerator enumerator = queue.GetEnumerator();
            Console.WriteLine("\nQueue using Iterator:\n");
            while (enumerator.MoveNext())
            {
                Console.WriteLine("Value: {0},Priority: {1}",enumerator.Current.priority,enumerator.Current.value);
            }
        }
    }
}
