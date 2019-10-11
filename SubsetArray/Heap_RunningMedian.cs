using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    class Heap_RunningMedian
    {
        //min heap
        //public class MinHeap<T> where T : IComparable
        //{
        //    private List<T> elements = new List<T>();

        //    public int GetSize()
        //    {
        //        return elements.Count;
        //    }

        //    public T GetMin()
        //    {
        //        return this.elements.Count > 0 ? this.elements[0] : default(T);
        //    }

        //    public void Add(T item)
        //    {
        //        elements.Add(item);
        //        this.HeapifyUp(elements.Count - 1);
        //    }

        //    public T PopMin()
        //    {
        //        if (elements.Count > 0)
        //        {
        //            T item = elements[0];
        //            elements[0] = elements[elements.Count - 1];
        //            elements.RemoveAt(elements.Count - 1);

        //            this.HeapifyDown(0);
        //            return item;
        //        }

        //        throw new InvalidOperationException("no element in heap");
        //    }

        //    private void HeapifyUp(int index)
        //    {
        //        var parent = this.GetParent(index);
        //        if (parent >= 0 && elements[index].CompareTo(elements[parent]) < 0)
        //        {
        //            var temp = elements[index];
        //            elements[index] = elements[parent];
        //            elements[parent] = temp;

        //            this.HeapifyUp(parent);
        //        }
        //    }

        //    private void HeapifyDown(int index)
        //    {
        //        var smallest = index;

        //        var left = this.GetLeft(index);
        //        var right = this.GetRight(index);

        //        if (left < this.GetSize() && elements[left].CompareTo(elements[index]) < 0)
        //        {
        //            smallest = left;
        //        }

        //        if (right < this.GetSize() && elements[right].CompareTo(elements[smallest]) < 0)
        //        {
        //            smallest = right;
        //        }

        //        if (smallest != index)
        //        {
        //            var temp = elements[index];
        //            elements[index] = elements[smallest];
        //            elements[smallest] = temp;

        //            this.HeapifyDown(smallest);
        //        }

        //    }

        //    private int GetParent(int index)
        //    {
        //        if (index <= 0)
        //        {
        //            return -1;
        //        }

        //        return (index - 1) / 2;
        //    }

        //    private int GetLeft(int index)
        //    {
        //        return 2 * index + 1;
        //    }

        //    private int GetRight(int index)
        //    {
        //        return 2 * index + 2;
        //    }



        //}

        //max heap 

        //Median
        //public class CalcMedian
        //{
        //    public double GetMedian(double num, double prevMedian, MinHeap<int> left, Heap<int> right)
        //    {
        //        if (left.GetSize() > right.GetSize())
        //        {
        //            right.Add(left.g)
        //        }
        //    }
        //}
        int n = 5;
        int[] arr = new int[5];
        int[] minheap = new int[5];
        int[] maxheap = new int[5];
        int minHeapSize = 0;
        int maxHeapSize = 0;
        float currentMedian = 0;

        public  void CalaculateMedian()
        {
            for (int i = 0; i < n; i++)
            {
                arr[i] =Convert.ToInt32( Console.ReadLine().ToString() );
                if (arr[i]<currentMedian)
                {
                    maxheap[maxHeapSize++] = arr[i];
                    // making sure the max heap has maximum value at the top
                    if (maxheap[maxHeapSize - 1] > maxheap[0])
                    {
                        swap(maxheap, maxHeapSize - 1, 0);
                    }
                }
                else
                {
                    minheap[minHeapSize++] = arr[i];
                    // making sure the min heap has minimum value at the top
                    if (minheap[minHeapSize - 1] < minheap[0])
                    {
                        swap(minheap, minHeapSize - 1, 0);
                    }
                }

                //if difference b/w minheapsize and maxheapsize >1 
                if (Math.Abs(maxHeapSize-minHeapSize)>1)
                {
                    if (maxHeapSize>minHeapSize)
                    {
                        swap(maxheap, maxHeapSize - 1, 0);
                        minheap[minHeapSize++] = maxheap[--maxHeapSize];
                        swap(minheap, 0, minHeapSize - 1);

                        buildMaxHeap(maxheap,maxHeapSize);
                    }
                    else
                    {
                        swap(minheap, minHeapSize - 1, 0);
                        maxheap[maxHeapSize++] = minheap[--minHeapSize];
                        swap(maxheap, 0, maxHeapSize-1);
                        buildMinHeap(minheap,minHeapSize);
                    }
                }

                //calculate the median 
                if (maxHeapSize==minHeapSize)
                {
                    currentMedian = minheap[0] + maxheap[0];
                    currentMedian = currentMedian / 2;

                }
                else if(maxHeapSize>minHeapSize)
                {
                    currentMedian = maxheap[0];
                }
                else
                {
                    currentMedian = minheap[0];
                }
            }
        }

        private void buildMinHeap(int[] input, int heapsize)
        {
            int depth = (heapsize - 1) / 2;
            for (int i = depth; i >=0; i--)
            {
                minheapify(input , i , heapsize);
            }
        }

        private void minheapify(int[] input, int i, int heapsize)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int smallest = i;
            if (left<heapsize&&input[left]<input[smallest])
            {
                smallest = left;
            }
            if (right < heapsize && input[right] < input[smallest])
            {
                smallest = right;
            }
            if (smallest!=i)
            {
                swap(input, i, smallest);
                minheapify(input, smallest, heapsize);
            }
        }

        private void buildMaxHeap(int[] input, int heapsize)
        {
            int depth = (heapsize - 1) / 2;
            for (int i = depth; i >=0; i--)
            {
                maxheapify(input,i,heapsize);
            }
        }

        private void maxheapify(int[] input, int i, int heapsize)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int largest = i;
            if (left<heapsize&&input[left]>input[largest])
            {
                largest = left;
            }
            if (right<heapsize&&input[right]>input[largest])
            {
                largest = right;
            }

            if (largest!=i)
            {
                swap(input,i ,largest);
                maxheapify(input, largest, heapsize);
            }
        }

        private void swap(int[] input, int v1, int v2)
        {
            if (v1==v2)
            {
                return;
            }
            int temp = input[v1];
            input[v1] = input[v2];
            input[v2] = temp;
        }
    }
}
