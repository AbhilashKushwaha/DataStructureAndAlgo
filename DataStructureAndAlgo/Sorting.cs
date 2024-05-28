using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgo
{
    public class Sorting
    {
        public int[] UnsortedArray = new int[] { 9,5,8,6,3,1,0,4,7};

        public void BubbleSort()
        {
            for (int i = 0; i < UnsortedArray.Length-1; i++)
            {
                for (int j = 0; j < UnsortedArray.Length-1 - i; j++)
                {
                    if (UnsortedArray[j]> UnsortedArray[j+1])
                    {
                        var temp = UnsortedArray[j];
                        UnsortedArray[j] = UnsortedArray[j+1];
                        UnsortedArray[j + 1] = temp;
                    }
                }
            }
            Display(UnsortedArray);
        }
         
        public void QuickSort(int[] UnsortedArray, int low, int high)
        {
            if (low<high)
            {
                int partitionIndex = Partition( UnsortedArray,  low,  high);
                Display(UnsortedArray);
                Console.WriteLine();
                QuickSort(UnsortedArray, low, partitionIndex-1);
                QuickSort(UnsortedArray, partitionIndex+1 , high);
            }
        }

        private int Partition(int[] unsortedArray, int low, int high)
        {
            int pivot = unsortedArray[high];
            int lastindex = high;
            while (low < high)
            {
                while (unsortedArray[low] <= pivot)
                {
                    low++;
                } 

                while (unsortedArray[high] >= pivot)
                {
                    high--;
                }

                if (low < high)
                {
                    swapItem(unsortedArray,low, high);
                }
                else
                {
                    swapItem(unsortedArray,low, lastindex);
                    
                }
            }
            return low;
        }

        private void swapItem(int[] arr , int low, int high)
        {
            int temp = arr[low];
            arr[low] = arr[high];
            arr[high] = temp;
        }

        public void Display(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{item} ==> ");
            }
        }
    }
}
