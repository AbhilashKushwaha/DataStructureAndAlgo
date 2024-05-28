using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgo
{

    public class Node
    {
        public int _data;
        public Node _next;

        public Node(int data)
        {
            _data = data;
            _next = null;
        }
    }

    public class SinglyLinkedList
    {
        private Node head;

        public void PrintLinkedList()
        {
            Console.WriteLine($"Updated List");
            Node tempNode = head;
            while (tempNode != null)
            {
                Console.Write($"{tempNode._data} --> ");
                tempNode = tempNode._next;
            }
        }

        public void AddInfront(int data)
        {
            Node newNode = new Node(data);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                newNode._next = head;
                head = newNode;
            }
        }

        public void AddAtLast(int data)
        {

            Node newNode = new Node(data);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node lastNode = GetLastNode();
                lastNode._next = newNode;
            }
        }

        public void DeleteAtFront()
        {
            if (head == null)
            {
                Console.WriteLine("underflow");
            }
            else
            {
                head = head._next;
            }
        }

        public void DeleteAtLast()
        {
            if (head == null)
            {
                Console.WriteLine("underflow");
            }
            else
            {
                Node tempNode = head;
                while (tempNode._next._next != null)
                {
                    tempNode = tempNode._next;
                }
                tempNode._next = null;
            }
        }

        public void DeleteSpecificNode(int deleteNode)
        {
            if (head == null)
            {
                Console.WriteLine("underflow");
            }
            else
            {
                Node tempNode = head;
                while (tempNode._next._data != deleteNode)
                {
                    tempNode = tempNode._next;
                }
                tempNode._next = tempNode._next._next;
            }
        }

        public void AddAfterNode(int data, int afterData)
        {
            Node newNode = new Node(data);
            Node specificNode = GetSpecificNode(afterData);
            newNode._next = specificNode._next;
            specificNode._next = newNode;
        }

        private Node GetLastNode()
        {
            Node tempNode = head;
            while (tempNode._next != null)
            {
                tempNode = tempNode._next;
            }
            return tempNode;
        }

        private Node GetSpecificNode(int requiredData)
        {
            Node tempNode = head;
            while (tempNode != null)
            {
                tempNode = tempNode._next;
                if (tempNode._data == requiredData)
                {
                    break;
                }
            }
            return tempNode;
        }
    }

    public class SinglyListRunner
    {
        public void MainMethod()
        {
            Console.WriteLine("Hello World!");
            string userInput = string.Empty;
            SinglyLinkedList singlyLinkedList = new SinglyLinkedList();
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
                    insertOps = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter Element to be added?");
                    data = Convert.ToInt32(Console.ReadLine());

                    switch (insertOps)
                    {

                        case 3:
                            int afternode;
                            Console.WriteLine("After which Node you want to enter?");
                            singlyLinkedList.PrintLinkedList();
                            afternode = Convert.ToInt32(Console.ReadLine());
                            singlyLinkedList.AddAfterNode(data, afternode);
                            break;
                        case 2:
                            singlyLinkedList.AddAtLast(data);
                            break;
                        case 1:
                        default:
                            singlyLinkedList.AddInfront(data);
                            break;

                    }
                    Console.WriteLine();
                    singlyLinkedList.PrintLinkedList();
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
                            singlyLinkedList.PrintLinkedList();
                            Console.WriteLine("Enter Element to be Deleted?");
                            deleteAfterData = Convert.ToInt32(Console.ReadLine());
                            singlyLinkedList.DeleteSpecificNode(deleteAfterData);
                            break;
                        case 2:
                            singlyLinkedList.DeleteAtLast();
                            break;
                        case 1:
                        default:

                            singlyLinkedList.DeleteAtFront();
                            break;

                    }
                    Console.WriteLine();
                    singlyLinkedList.PrintLinkedList();
                    Console.WriteLine();
                    Console.WriteLine("--------DELETE-END------");
                }
                else if (opsInput == 3)
                {
                    singlyLinkedList.PrintLinkedList();
                }
                else
                {
                    Console.WriteLine();
                    singlyLinkedList.PrintLinkedList();
                    Console.WriteLine();

                    Console.WriteLine("Do you wnat to continue? Y/N");
                    userInput = Console.ReadLine();
                }

            }
        }
    }

}
