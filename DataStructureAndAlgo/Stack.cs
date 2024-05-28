using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgo
{

    public class StackRunner
    {
        public void MainMethod()
        {
            string userInput = string.Empty;
            Stack stack = new Stack();
            while (userInput == string.Empty || userInput.ToUpper() == "Y")
            {
                int opsInput = 0;
                Console.WriteLine();
                Console.WriteLine("What do you want to do in a Stack?");
                Console.WriteLine("1. Push");
                Console.WriteLine("2. Pop");
                Console.WriteLine("3  Peek");
                Console.WriteLine("4  Display");
                opsInput = Convert.ToInt32(Console.ReadLine());

                if (opsInput == 1)
                {
                    Console.WriteLine("--------PUSH--------");
                    Console.WriteLine("Enter Element to be Pushed?");
                    int data = Convert.ToInt32(Console.ReadLine());
                    stack.Push(data);
                }
                else if (opsInput == 2)
                {
                    Console.WriteLine("--------POP--------");
                    stack.Pop();
                }
                else if (opsInput == 3)
                {
                    Console.WriteLine("--------PEEK--------");
                    stack.Peek();
                }
                else
                {
                    Console.WriteLine();
                    stack.DisplayStack();
                    Console.WriteLine();
                    Console.WriteLine("Do you wnat to continue? Y/N");
                    userInput = Console.ReadLine();
                }

            }
        }
    }

    internal class Stack
    {
        //LIFO
        private static readonly int maxLength=100;
        private int top;
        int[] stack= new int[maxLength];

        public Stack()
        {
            top=-1;
        }
        

        //push

        public void Push(int data)
        {
            if (top >= maxLength)
            {
                Console.WriteLine("Stack overflow");
            }
            else
            {
                stack[++top] = data;
            }
            DisplayStack();
        }

        //pop
        public void Pop()
        {
            if (top < 0)
            {
                Console.WriteLine("Stack underflow");
            }
            else
            {
                top--;
            }
            DisplayStack();
        }

        //peek
        public void Peek()
        {
            if (top < 0)
            {
                Console.WriteLine("Stack underflow");
            }
            else
            {
                Console.WriteLine($"Peeked Value = {stack[top]}");
            }
        }
        //dispaly
        public void DisplayStack()
        {
            Console.WriteLine("Your Stack");
            for (int i = 0; i <= top; i++)
            {
                Console.Write($"{stack[i]} --> ");
            }
        }
    }
}
