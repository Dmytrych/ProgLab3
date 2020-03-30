using System;
using System.Collections.Generic;
using System.Text;

namespace ProgLab3
{
    class MyStack<T>
    {
        T[] elements;
        public int Length { get; private set; }
        public MyStack(int length)
        {
            elements = new T[length];
            Length = 0;
        }
        public void Push(T elem)
        {
            elements[Length] = elem;
            Length++;
        }
    }
}
