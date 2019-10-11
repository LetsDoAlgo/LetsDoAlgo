using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    //Find maximum in stack in O(1) without using additional stack
    public class MaxElementStack_order_1
    {
        //: Instead of pushing a single element to the stack, push a pair instead. The pair consists of the (value, localMax) where localMax is the maximum value upto that element.

        //When we insert a new element, if the new element is greater than the local maximum below it, we set the local maximum of a new element equal to the element itself.
        //Else, we set the local maximum of the new element equal to the local maximum of the element below it.
        //The local maximum of the top of the stack will be the overall maximum.
        //Now if we want to know the maximum at any given point, we ask the top of the stack for local maximum associated with it which can be done in O(1).
        public class Block
        {
            public int value;
            public int localMax;
        }
        public class Stack
        {
            //pointer of type block will be useful later as size can be dynamically allocated 
            public Block[] block;
            public int size, top;
            public Stack(int n)
            {
                size = n;
                top = -1;
                block = new Block[n];
                for (int i = 0; i < n; i++)
                {
                    block[i] = new Block();                    
                }

            }

            public void Push(int data)
            {
                if (top==size-1)
                {
                    Console.WriteLine("stack is full");
                }
                else
                {
                    top++;
                    if (top==0)
                    {
                        //inserted element is the first element 
                        //// If the inserted element is the first element  
                        // then it is the maximum element, since no other  
                        // elements is in the stack, so the localMax  
                        // of the first element is the element itself 
                        block[top].value = data;
                        block[top].localMax =data;
                    }
                    else
                    {
                        if (block[top-1].localMax>data)
                        {
                            block[top].value = data;
                            block[top].localMax = block[top - 1].localMax;

                        }
                        else
                        {
                            block[top].value = data;
                            block[top].localMax = data;

                        }
                    }
                }

                Console.WriteLine(data+"inserted in stack");
            }

            public void pop()
            {
                if (top==-1)
                {
                    Console.WriteLine("stack is empty");
                }
                else
                {
                    top--;
                    Console.WriteLine("elemet popped");
                }
            }

            public void max()
            {
                if (top==-1)
                {
                    Console.WriteLine("stack is empty");
                }
                else
                {
                    // The overall maximum is the local maximum  
                    // of the top element  
                    Console.WriteLine("max elemet is ",block[top].localMax);
                }
            }
        }

    }
}
