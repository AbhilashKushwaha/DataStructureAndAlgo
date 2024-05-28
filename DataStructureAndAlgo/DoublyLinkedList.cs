using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgo
{
    public class DoublyLinkedListRunner
    {
        public void MainMethod()
        {
            Console.WriteLine("Hello World!");
            string userInput = string.Empty;
            DoublyLinkedList doublyLinkedList = new DoublyLinkedList();
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
                            doublyLinkedList.DiaplayLinkedList();
                            Console.WriteLine("After which Node you want to enter?");
                            afternode = Convert.ToInt32(Console.ReadLine());
                            doublyLinkedList.InsertInBetween(data, afternode);
                            break;
                        case 2:
                            doublyLinkedList.InsertAtLast(data);
                            break;
                        case 1:
                        default:
                            doublyLinkedList.InsertAtHead(data);
                            break;

                    }
                    Console.WriteLine();
                    doublyLinkedList.DiaplayLinkedList();
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
                            doublyLinkedList.DiaplayLinkedList();
                            Console.WriteLine("Enter Element to be Deleted?");
                            deleteAfterData = Convert.ToInt32(Console.ReadLine());
                            doublyLinkedList.DeleteInBetween(deleteAfterData);
                            break;
                        case 2:
                            doublyLinkedList.DeleteAtLast();
                            break;
                        case 1:
                        default:

                            doublyLinkedList.DeleteAtHead();
                            break;

                    }
                    Console.WriteLine();
                    doublyLinkedList.DiaplayLinkedList();
                    Console.WriteLine();
                    Console.WriteLine("--------DELETE-END------");
                }
                else if (opsInput == 3)
                {
                    doublyLinkedList.DiaplayLinkedList();
                }
                else
                {
                    Console.WriteLine();
                    doublyLinkedList.DiaplayLinkedList();
                    Console.WriteLine();

                    Console.WriteLine("Do you wnat to continue? Y/N");
                    userInput = Console.ReadLine();
                }

            }
        }
    }

    public class DoublyNode
    {
        public int _data;
        public DoublyNode _prev;
        public DoublyNode _next;

        public DoublyNode(int data)
        {
            _data = data;
            _prev = null;
            _next =null;
        }
    }

    public class DoublyLinkedList
    {

        private DoublyNode head;
        //insert

        //insert at head

        public void InsertAtHead(int data)
        {
            DoublyNode newNode = new DoublyNode(data);
            if (head==null)
            {
                head = newNode;
            }
            else
            {
                head._prev = newNode;
                newNode._next = head;
                head = newNode;
            }
        }


        //insert at last
        public void InsertAtLast(int data)
        {
            DoublyNode newNode = new DoublyNode(data);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                DoublyNode tempNode = head;
                while (tempNode._next != null)
                {
                    tempNode= tempNode._next;
                }

                tempNode._next = newNode;
                newNode._prev = tempNode;
            }
        }

        //insert in between


        public void InsertInBetween(int data,int afterNode)
        {
            DoublyNode newNode = new DoublyNode(data);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                DoublyNode tempNode = head;
                while (tempNode._next != null && tempNode._next._data != afterNode)
                {
                    tempNode = tempNode._next;
                }

                newNode._next = tempNode._next;
                newNode._prev = tempNode;
                tempNode._next = newNode;
                tempNode._next._next._prev = newNode;
            }
        }


        //detele
        //delete at head
        public void DeleteAtHead()
        {
            if (head == null)
            {
                Console.WriteLine("UnderFlow");
            }
            else
            {
                DoublyNode tempNode = head;
                head = head._next;
                head._prev = null;
                tempNode._next = null;
            }
        }
        //delete at last
        public void DeleteAtLast()
        {
            if (head == null)
            {
                Console.WriteLine("UnderFlow");
            }
            else
            {
                DoublyNode tempNode = head;
                while (tempNode._next != null)
                {
                    tempNode = tempNode._next;
                }

                tempNode._prev._next = null;
                tempNode._prev = null;
            }
        }

        //delete in between

        public void DeleteInBetween(int data)
        {
            if (head == null)
            {
                Console.WriteLine("UnderFlow");
            }
            else
            {
                DoublyNode tempNode = head;
                while (tempNode._next != null && tempNode._next._data != data)
                {
                    tempNode = tempNode._next;
                }

                DoublyNode intermediateNode = tempNode._next._next;
                tempNode._next._next._prev = null;
                tempNode._next._next = null;

                tempNode._next._prev = null;
                tempNode._next = null;


                tempNode._next = intermediateNode;
                intermediateNode._prev = tempNode;
            }
        }

        //display


        public void DiaplayLinkedList()
        {
            Console.WriteLine($"Updated List");
            DoublyNode tempNode = head;
            DoublyNode lastNode = head;
            Console.WriteLine($"Inorder");

            while (tempNode != null)
            {
                if (tempNode._next != null)
                {
                    lastNode = lastNode._next;
                }
                Console.Write($"{tempNode._data} --> ");
                tempNode = tempNode._next;
                
            }
            Console.WriteLine();
            Console.WriteLine($"Reverseorder");

            while (lastNode != null)
            {
               Console.Write($"{lastNode._data} --> ");
                lastNode = lastNode._prev;
            }

        }
    }
}
