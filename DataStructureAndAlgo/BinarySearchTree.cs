using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgo
{

    public class BinarySearchTreeRunner
    {
        public void MainMethod()
        {
            string userInput = string.Empty;
            BinarySearchTree queue = new BinarySearchTree();

            while (userInput == string.Empty || userInput.ToUpper() == "Y")
            {
                int opsInput = 0;
                Console.WriteLine();
                Console.WriteLine("What do you want to do in a BTREE?");
                Console.WriteLine("1. Insert");
                Console.WriteLine("2. Delete");
                Console.WriteLine("3  Display");
                opsInput = Convert.ToInt32(Console.ReadLine());


                if (opsInput == 1)
                {
                    Console.WriteLine("Enter element to be add?");
                    int data = Convert.ToInt32(Console.ReadLine());
                    queue.InsertData(data);
                    queue.Display();
                }
                else if (opsInput == 2)
                {
                    Console.WriteLine("Enter element to be Deleted?");
                    int data = Convert.ToInt32(Console.ReadLine());
                    queue._root=queue.DeleteNode(queue._root, data);
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

                //Console.WriteLine();
                //Console.WriteLine("Do you wnat to continue? Y/N");
                //userInput = Console.ReadLine();
            }
        }
    }

    public class TreeNode
    {
        public int _data;
        public TreeNode _leftNode;
        public TreeNode _rightNode;

        public TreeNode(int data)
        {
            _data = data;
            _leftNode = null;
            _rightNode = null;
        }
    }

    internal class BinarySearchTree
    {
        public TreeNode _root;

        public BinarySearchTree() { _root = null; }

        //Insert
        public void InsertData(int data)
        {
            TreeNode newNode = new TreeNode(data);
            _root = InsertatPosition(_root, newNode);
        }

        private TreeNode InsertatPosition(TreeNode Start, TreeNode newNode)
        {
            if (Start == null)
            {
                //empty tree
                Start = newNode;
            }
            else if (Start._data > newNode._data)
            {
                Start._leftNode = InsertatPosition(Start._leftNode, newNode);
            }
            else
            {
                Start._rightNode = InsertatPosition(Start._rightNode, newNode);
            }
            return Start;
        }

        public TreeNode DeleteNode(TreeNode root, int data)
        {
            if (root == null)
            {
                return root;
            }
            else if (data < root._data)
            {
                root._leftNode = DeleteNode(root._leftNode, data);
            }
            else if (data > root._data)
            {
                root._rightNode = DeleteNode(root._rightNode, data);
            }
            else
            {
                if (root._leftNode == null)
                {
                    return root._rightNode;
                }

                if (root._rightNode == null)
                {
                    return root._leftNode;
                }

                //find min in right tree
                root._data = MininRightTree(root._rightNode);

                root._rightNode = DeleteNode(root._rightNode, root._data);
            }
            return root;

        }

        private int MininRightTree(TreeNode root)
        {

            int minv = root._data;
            while (root._leftNode != null)
            {
                minv = root._leftNode._data;
                root = root._leftNode;
            }
            return minv;
        }






        //Delete
        public void Display()
        {
            InOrderBTree(_root);
        }

        private void InOrderBTree(TreeNode start)
        {
            if (start == null)
            {
                return;
            }
            InOrderBTree(start._leftNode);
            Console.Write($"{start._data} --> ");
            InOrderBTree(start._rightNode);
        }
        //Dispaly Inorder
        //Display preorder
        //display postorder

    }
}
