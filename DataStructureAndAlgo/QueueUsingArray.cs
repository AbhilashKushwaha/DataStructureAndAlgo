using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgo
{
    public class QueueRunner
    {
        public void MainMethod()
        {
            string userInput = string.Empty;
            QueueUsingArray queue = new QueueUsingArray();
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
                    queue.DisplayQueue();
                }
                else if (opsInput == 2)
                {
                    Console.WriteLine("--------Dequeue--------");
                    queue.Dequeue();
                    queue.DisplayQueue();
                }
                else
                {
                    Console.WriteLine("--------Display--------");
                    queue.DisplayQueue();
                    Console.WriteLine();
                    Console.WriteLine("Do you wnat to continue? Y/N");
                    userInput = Console.ReadLine();
                }
            }
        }
    }
    internal class QueueUsingArray
    {
        private static readonly int Maxlength= 3;
        int[] queue = new int[Maxlength];
        int front, rear = -1;

        //FIFO

        //enqueue
        public void Enqueue(int data)
        {
            if (rear + 1 > Maxlength-1)
            {
                Console.WriteLine("OverFlow");
                return;
                
            }
            else
            {
                if (front==-1)
                {
                    front++;
                }
                queue[++rear] = data;
            }
        }

        //dequeue
        public void Dequeue()
        {
            if (front > rear)
            {
                Console.WriteLine("Underflow");
                return;
            }
            //else if (front > Maxlength - 1)
            //{
            //    Console.WriteLine("OverFlow");
            //    return;

            //}
            else
            {
                queue[front] = 0;
                front++;
            }
        }
        //display

        public void DisplayQueue()
        {
            for (int i = front; i <= rear; i++)
            {
                Console.Write($"{queue[i] } --> ");
            }
        }
    }
}
