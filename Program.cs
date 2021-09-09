using System;

namespace MyPriorityQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declaring a priority queue
            // For this question we Have taken a queue that takes in only integers
            MyPriorityQueue<int> myQueue = new MyPriorityQueue<int>();
            int flag = 0, element;
            uint priority;

        redo:
            Console.Clear();
            ShowOptions();
            int choice = Choice();
            while (flag == 0)
            {
                switch (choice)
                {
                    case 1:
                        element = GetValue();
                        priority = GetPriority();
                        myQueue.Enqueue(priority,element);
                        PressToContinue();
                        goto redo;

                    case 2:
                        myQueue.Dequeue();
                        PressToContinue();
                        goto redo;

                    case 3:
                        myQueue.Peek();
                        PressToContinue();
                        goto redo;

                    case 4:
                        element = GetValue();
                        Console.WriteLine(myQueue.Contains(element));
                        PressToContinue();
                        goto redo;

                    case 5:
                        Console.WriteLine("\nSize is: " + myQueue.Size());
                        PressToContinue();
                        goto redo;

                    case 6:
                        myQueue.Reverse();
                        PressToContinue();
                        goto redo;

                    case 7:
                        myQueue.Iterator();
                        PressToContinue();
                        goto redo;

                    case 8:

                        myQueue.Print();
                        PressToContinue();
                        goto redo;
                    // Case to exit the application
                    case 0:
                        flag = 1;
                        break;
                }
            }
        }
        // Displaying operations
        public static void ShowOptions()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press 0 ---> Exit");
            Console.WriteLine("Press 1 ---> Enqueue");
            Console.WriteLine("Press 2 ---> Dequeue");
            Console.WriteLine("Press 3 ---> Peek");
            Console.WriteLine("Press 4 ---> Contains");
            Console.WriteLine("Press 5 ---> Size");
            Console.WriteLine("Press 6 ---> Reverse");
            Console.WriteLine("Press 7 ---> Iterator");
            Console.WriteLine("Press 8 ---> Print");
        }
        // To get choice of operation
        public static int Choice()
        {
        redo:
            Console.Write("\nEnter Choice of Operation: ");
            int choice;
            try
            {
                choice = int.Parse(Console.ReadLine());
                while (choice < 0 || choice > 8)
                {
                    Console.Write("Please enter valid choice: ");
                    choice = int.Parse(Console.ReadLine());
                }
                return choice;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid Type. Please enter a choice");
                Console.ForegroundColor = ConsoleColor.White;
                goto redo;
            }
        }
        // To get value
        public static int GetValue()
        {
        redo:
            try
            {
                Console.Write("\nEnter Value : ");
                int value = int.Parse(Console.ReadLine());
                return value;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid Type. Please enter a integer");
                Console.ForegroundColor = ConsoleColor.White;
                goto redo;
            }
        }
        // To get priority
        public static uint GetPriority()
        {
        redo:
            try
            {
                Console.WriteLine("\nEnter Priority in range [0,+ve infinity] where 0 is considered highest priority");
                Console.Write("\nEnter Priority : ");
                uint value = uint.Parse(Console.ReadLine());
                return value;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid Type. Please enter a integer");
                Console.ForegroundColor = ConsoleColor.White;
                goto redo;
            }
            catch (OverflowException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nPriority cannot be negative! Should be in range [0,infinity] where 0 is the highest priority");
                Console.ForegroundColor = ConsoleColor.White;
                goto redo;
            }
        }

        public static void PressToContinue()
        {
            Console.WriteLine("\nPress Any Key to continue: ");
            Console.ReadKey();
        }
    }
}
