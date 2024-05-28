using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgo
{
    public class CircularSinglyLinkedListRunner
    {
        public void MainMethod()
        {
            Console.WriteLine("Hello World!");
            string userInput = string.Empty;
            CircularSinglyLinkedList circularSinglyLinkedList = new CircularSinglyLinkedList();
            while (userInput == string.Empty || userInput == "Y")
            {
                int opsInput = 0;
                Console.WriteLine();
                Console.WriteLine("What do you want to do in a Linked list?");
                Console.WriteLine("1. Insert");
                Console.WriteLine("2. Delete");
                Console.WriteLine("3  Display List");
                Console.WriteLine("4  End Ops");
                opsInput = Convert.ToInt32(Console.ReadLine());

                if (opsInput == 1)
                {
                    Console.WriteLine("--------INSERT--------");
                    int insertOps = 0;
                    int data;
                    Console.WriteLine("Where do you wnat to add?");
                    Console.WriteLine("1. Head");
                    Console.WriteLine("2. Last");
                    Console.WriteLine("3. In Between");
                    insertOps = Convert.ToInt32(Console.ReadLine().Trim());

                    Console.WriteLine("Enter Element to be added?");
                    data = Convert.ToInt32(Console.ReadLine());

                    switch (insertOps)
                    {

                        case 3:
                            int afternode;
                            circularSinglyLinkedList.DiaplayLinkedList();
                            Console.WriteLine("After which Node you want to enter?");
                            afternode = Convert.ToInt32(Console.ReadLine());
                            circularSinglyLinkedList.InsertInBetween(data, afternode);
                            break;
                        case 2:
                            circularSinglyLinkedList.InsertAtLast(data);
                            break;
                        case 1:
                        default:
                            circularSinglyLinkedList.InsertAtHead(data);
                            break;

                    }
                    Console.WriteLine();
                    circularSinglyLinkedList.DiaplayLinkedList();
                    Console.WriteLine();

                    Console.WriteLine("--------INSERT-END------");
                }
                else if (opsInput == 2)
                {
                    Console.WriteLine("--------DELETE--------");
                    int deleteOps = 0;

                    Console.WriteLine("Where do you want to Delete?");
                    Console.WriteLine("1. Head");
                    Console.WriteLine("2. Last");
                    Console.WriteLine("3. In Between");
                    deleteOps = Convert.ToInt32(Console.ReadLine());

                    switch (deleteOps)
                    {

                        case 3:
                            int deleteAfterData;
                            circularSinglyLinkedList.DiaplayLinkedList();
                            Console.WriteLine("Enter Element to be Deleted?");
                            deleteAfterData = Convert.ToInt32(Console.ReadLine());
                            circularSinglyLinkedList.DeleteInBetween(deleteAfterData);
                            break;
                        case 2:
                            circularSinglyLinkedList.DeleteAtLast();
                            break;
                        case 1:
                        default:

                            circularSinglyLinkedList.DeleteAtHead();
                            break;

                    }
                    Console.WriteLine();
                    circularSinglyLinkedList.DiaplayLinkedList();
                    Console.WriteLine();
                    Console.WriteLine("--------DELETE-END------");
                }
                else if (opsInput == 3)
                {
                    circularSinglyLinkedList.DiaplayLinkedList();
                }
                else
                {
                    Console.WriteLine();
                    circularSinglyLinkedList.DiaplayLinkedList();
                    Console.WriteLine();

                    Console.WriteLine("Do you wnat to continue? Y/N");
                    userInput = Console.ReadLine();
                }

            }
        }
    }

    public class CircularSinglyNode
    {
        public int _data;
        public CircularSinglyNode _next;
        public CircularSinglyNode(int data)
        {
            _data = data;
            _next = null;
        }
    }
    public class CircularSinglyLinkedList
    {
        private CircularSinglyNode head, tail;
        internal void InsertAtHead(int data)
        {
            CircularSinglyNode newNode = new CircularSinglyNode(data);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
                newNode._next = head;
            }
            else
            {
                newNode._next = head;
                tail._next = newNode;
                head = newNode;
            }
        }

        internal void InsertAtLast(int data)
        {
            CircularSinglyNode newNode = new CircularSinglyNode(data);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
                newNode._next = head;
            }
            else
            {
                tail._next = newNode;
                newNode._next = head;
                tail = newNode;
            }
        }

        internal void InsertInBetween(int data, int afternode)
        {
            CircularSinglyNode newNode = new CircularSinglyNode(data);
            CircularSinglyNode specificNode = GetSpecificNode(afternode);
            newNode._next = specificNode._next;
            specificNode._next = newNode;
        }

        private CircularSinglyNode GetSpecificNode(int afternode)
        {
            CircularSinglyNode tempNode = head;
            while (tempNode._next != head)
            {
                tempNode = tempNode._next;
                if (tempNode._data == afternode)
                {
                    break;
                }
            }
            return tempNode;
        }

        internal void DeleteAtHead()
        {
            if (head == null)
            {
                Console.WriteLine("Underflow");
            }
            else
            {
                CircularSinglyNode tempNode = head._next;
                tail._next = head._next;
                head._next = null;
                head = tempNode;

            }
        }

        internal void DeleteAtLast()
        {
            if (head == null)
            {
                Console.WriteLine("Underflow");
            }
            else
            {
                CircularSinglyNode tempNode = head;
                while (tempNode._next != tail)
                {
                    tempNode = tempNode._next;
                }
                tempNode._next = head;
                tail = tempNode;
            }
        }

        internal void DeleteInBetween(int deleteAfterData)
        {
            if (head == null)
            {
                Console.WriteLine("underflow");
            }
            else
            {
                CircularSinglyNode tempNode = head;
                while (tempNode._next._data != deleteAfterData)
                {
                    tempNode = tempNode._next;
                }
                tempNode._next = tempNode._next._next;
            }
        }

        internal void DiaplayLinkedList()
        {
            Console.WriteLine($"Updated List");
            CircularSinglyNode tempNode = head;

            if (head == null)
            {
                Console.WriteLine($"Empty");
            }

            if (head == tail)
            {
                Console.Write($"{tempNode._data} --> ");
            }
            else
            {
                do
                {
                    Console.Write($"{tempNode._data} --> ");
                    tempNode = tempNode._next;
                } while (tempNode._next != head._next);
            }
        }


    }
}
