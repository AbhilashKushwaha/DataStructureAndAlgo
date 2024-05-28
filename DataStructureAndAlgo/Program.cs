using System;

namespace DataStructureAndAlgo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //SinglyListRunner slr = new SinglyListRunner();
            //slr.MainMethod();

            //DoublyLinkedListRunner dlr = new DoublyLinkedListRunner();
            //dlr.MainMethod();


            //CircularSinglyLinkedListRunner cll = new CircularSinglyLinkedListRunner();
            //cll.MainMethod();

            //StackRunner sr = new StackRunner();
            //sr.MainMethod();

            //QueueRunner qr= new QueueRunner();
            //qr.MainMethod();

            //CircularQueueRunner CQR= new CircularQueueRunner();
            //CQR.MainMethod();

            //BinarySearchTreeRunner BT = new BinarySearchTreeRunner();
            //BT.MainMethod();

            //GraphsRunner gr= new GraphsRunner();
            //gr.MainMethod();

            Sorting bubbleSort = new Sorting();
            // bubbleSort.BubbleSort();
            int[] arr = new int[] { 9, 5, 8, 6, 3, 1, 0, 4, 7 };
            bubbleSort.QuickSort(arr, 0, arr.Length - 1);
           // bubbleSort.Display(arr);
        }
    }
}

