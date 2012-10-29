using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connect_Three
{
    class CharStack
    {
        char[] stack;
        int size;
        int current;
        char empty;

        public CharStack(int size, char empty)
        {
            this.size = size;
            this.empty = empty;
            stack = new char[size];
            for (int i = 0; i < size; ++i)
            {
                stack[i] = empty;
            }
            current = 0;
        }

        public bool IsFull()
        {
            return current == size;
        }

        public void Push(char c)
        {
            stack[current] = c;
            current++;
        }

        public char Pop()
        {
            char c = stack[current];
            stack[current] = empty;
            current--;
            return c;
        }

        public char Peek()
        {
            return stack[current];
        }
    }
}
