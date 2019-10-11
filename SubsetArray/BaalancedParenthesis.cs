using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
   public class BaalancedParenthesis
    {

        public static bool IsMatchingPair(char char1, char char2)
        {
            if (char1 == '(' && char2 == ')')
            {
                return true;
            }
            else if (char1 == '{' && char2 == '}')
            {
                return true;
            }
            else if (char1 == '[' && char2 == ']')
            {
                return true;
            }
            return false;
        }

       public static bool AreParenthesisBalanaced(char[] exp)
        {
            Stack<char> st = new Stack<char>();
            for (int i = 0; i < exp.Length; i++)
            {
                if (exp[i] == '{' || exp[i] == '(' || exp[i] == '[')
                {
                    st.Push(exp[i]);
                }

                /* If exp[i] is an ending parenthesis  
                    then pop from stack and check if the  
                    popped parenthesis is a matching pair*/
                if (exp[i] == '}' || exp[i] == ')' || exp[i] == ']')
                {

                    /* If we see an ending parenthesis without  
                        a pair then return false*/
                    if (st.Count == 0)
                    {
                        return false;
                    }

                    /* Pop the top element from stack, if  
                        it is not a pair parenthesis of character  
                        then there is a mismatch. This happens for  
                        expressions like {(}) */
                    else if (!IsMatchingPair(st.Pop(), exp[i]))
                    {
                        return false;
                    }
                }
            }//for

            if (st.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    //implement stack using array
    public class Stack
    {
        public int top = -1;
        public char[] items = new char[100];

        public void push(char x)
        {
            if (top==99)
            {
                Console.WriteLine( "ooverflow");
            }
            else
            {
                items[++top] = x;
            }
        }

        public char pop()
        {
            if (top==-1)
            {
                Console.WriteLine("underflow");
                return '\0';
            }
            else
            {
                char element = items[top];
                top--;
                return element;
            }
        }

        Boolean isEmpty()
        {
            return (top == -1 ? true : false);
        }

    }

}
