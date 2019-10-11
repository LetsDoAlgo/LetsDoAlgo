using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public static class Heap_MinHeaptoMaxHeap
    {
        //Bilding heap from array 
        //left child is at (2*i+1)th index
        //right child at (2*i+2)th index
        //parent of (i-1)th node is at (i-1)/2 index

        // Simple Approach: Suppose, we need to build a Max-Heap from the above-given array elements.It can be clearly seen that the above complete binary tree formed does not follow the Heap property.So, the idea is to heapify the complete binary tree formed from the array in reverse level order following top-down approach.
         //That is first heapify, the last node in level order traversal of the tree, then heapify the second last node and so on.

        //Heapify a subtree rooted with node i which is an index in 
        //arr[] 

        static void heapify(int[]arr , int n , int i)
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;
            if (l<n&&arr[l]>arr[largest])
            {
                largest = l;
            }
         
            if (r<n&&arr[r]>arr[largest])
            {
                largest = r;
            }

            if (largest!=i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;
                heapify(arr, n, largest);
            }
        }

        public static void buildHeap(int[] arr, int n)
        {
            int startIndex = (n/2)-1; //
            for (int i = startIndex; i>=0;i--)
            {
                heapify(arr, n, i);
            }
        }

        public static void PrintHeap(int[] arr , int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i]+" ");
            }
            Console.WriteLine();
        }
    }

    public class MinHeap
    {
        private readonly int[] _elements;
        private int _size;
        public MinHeap(int size)
        {
            _elements = new int[size];
        }
        private int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;
        private int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;

        private int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;

        private bool HasLeftChild(int elementIndex) => GetLeftChildIndex(elementIndex) < _size;

        private bool HasRightChild(int elementIndex) => GetRightChildIndex(elementIndex) < _size;

        private bool IsRoot(int elementindex) => elementindex == 0;

        private int GetLeftChild(int elementIndex) => _elements[GetLeftChildIndex(elementIndex)];

        private int GetRightChild(int elementIndex) => _elements[GetRightChildIndex(elementIndex)];

        private int Getparent(int elementIndex) => _elements[GetParentIndex(elementIndex)];

        private void Swap(int firstIndex, int secondIndex)
        {
            var temp = _elements[firstIndex];
            _elements[firstIndex] = _elements[secondIndex];
            _elements[secondIndex] = temp;
        }

        private bool IsEmpty()
        {
            return _size == 0;
        }

        public int Peek()
        {
            if (_size == 0)
            {
                throw new IndexOutOfRangeException();
            }
            return _elements[0];
        }
        public int Pop()
        {
            if (_size == 0)
            {
                throw new IndexOutOfRangeException();

            }
            var result = _elements[0];
            _elements[0] = _elements[_size - 1];
            _size--;

            HeapifyDown();

            return result;
        }

        public void Add(int element)
        {
            if (_size == _elements.Length)
            {
                throw new IndexOutOfRangeException();
            }

            _elements[_size] = element;
            _size++;

            HeapifyUp();
        }

        //In case of minheap
        private void HeapifyUp()
        {
            var index = _size - 1;
            while (!IsRoot(index)&&_elements[index]<Getparent(index))
            {
                var parentIndex = GetParentIndex(index);
                Swap(parentIndex, index);
                index = parentIndex;
            }

        }

        //in cacse of minheap 
        private void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                var smallerIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && GetRightChild(index) < GetLeftChildIndex(index))
                {
                    smallerIndex = GetRightChildIndex(index);
                }

                if (_elements[smallerIndex] >= _elements[index])
                {
                    break;
                }
                Swap(smallerIndex, index);
                index = smallerIndex;
            }
        }
       
        
        // If we want to sort it, every time, it would take O(n) to find the median. but we do not need to know exactly the order of the input stream. So use max heap and min heap would be a good way to do it. Max heap on left side to store elements that are less than previous median; min heap on right side to store elements that are larger than previous median.
       
    }
}




//// private void ReCalculateDown()
//            {
//                int index = 0;
//                while (HasLeftChild(index))
//                {
//                    var biggerIndex = GetLeftChildIndex(index);
//                    if (HasRightChild(index) && GetRightChild(index) > GetLeftChild(index))
//                    {
//                        biggerIndex = GetRightChildIndex(index);
//                    }

//                    if (_elements[biggerIndex] < _elements[index])
//                    {
//                        break;
//                    }

//                    Swap(biggerIndex, index);
//index = biggerIndex;
//                }
//            }

//            private void ReCalculateUp()
//{
//    var index = _size - 1;
//    while (!IsRoot(index) && _elements[index] > GetParent(index))
//    {
//        var parentIndex = GetParentIndex(index);
//        Swap(parentIndex, index);
//        index = parentIndex;
//    }
//}