using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgo
{
    public class CircularQueueRunner
    {
        public void MainMethod()
        {
            string userInput = string.Empty;
            CircularQueue queue = new CircularQueue();
            while (userInput == string.Empty || userInput.ToUpper() == "Y")
            {
                int opsInput = 0;
                Console.WriteLine();
                Console.WriteLine("What do you want to do in a Queue?");
                Console.WriteLine("1. Enqueue");
                Console.WriteLine("2. Dequeue");
                Console.WriteLine("3  Display");
                opsInput = Convert.ToInt32(Console.ReadLine());

                if (opsInput == 1)
                {
                    Console.WriteLine("--------Enqueue--------");
                    Console.WriteLine("Enter element to be add?");
                    int data = Convert.ToInt32(Console.ReadLine());
                    queue.Enqueue(data);
                    queue.Display();
                }
                else if (opsInput == 2)
                {
                    Console.WriteLine("--------Dequeue--------");
                    queue.Dequeue();
                    queue.Display();
                }
                else
                {
                    Console.WriteLine("--------Display--------");
                    queue.Display();
                    Console.WriteLine();
                    Console.WriteLine("Do you wnat to continue? Y/N");
                    userInput = Console.ReadLine();
                }
            }
        }
    }
    internal class CircularQueue
    {
        public int front = -1;
        public int rear = -1;
        public static int maxLength = 5;
        int[] circularQueue = new int[maxLength];

        //FIFO
        //Enqueu
        public void Enqueue(int data)
        {
            if (front == -1 && rear == -1)
            {
                // empty case
                front = 0;
                rear = 0;
                circularQueue[rear] = data;
            }
            else
            {
                if ((rear + 1) % maxLength == front)
                {
                    //full case
                    Console.WriteLine("over flow");
                    return;
                }
                else
                {
                    rear = (rear + 1) % maxLength;
                    circularQueue[rear] = data;
                }
            }
        }

        //Dequeue
        public void Dequeue()
        {
            if (front == -1 && rear == -1)
            {
                Console.WriteLine("Under flow");
                return;
            }
            else
            {
                if (front == rear)
                {
                    front = -1;
                    rear = -1;
                }
                else
                {
                    front = (front + 1) % maxLength;
                }
            }
        }
        //Display

        public void Display()
        {
            int start = front;
            if (front==-1 && rear==-1)
            {
                Console.WriteLine("Empty");
            }
            else if (front == 0 && rear == 0)
            {
                Console.Write($"{circularQueue[start] } --> ");
            }
           else
            {
                //Console.Write($"{circularQueue[start] } --> ");
                //start = (start + 1) % maxLength;


                do
                {
                    Console.Write($"{circularQueue[start] } --> ");
                    start = (start + 1) % maxLength;
                } while (start != rear);
                Console.Write($"{circularQueue[rear] } --> ");
            }
        }
    }
}
