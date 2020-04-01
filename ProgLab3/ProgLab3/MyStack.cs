using System;

namespace ProgLab3
{
    class MyStack<T>
    {
        Node<T> Top;
        public int Count { get; private set; }
        public MyStack()
        {
            Count = 0;
        }
        public void Push(T value)
        {
            if (Count == 0)
                Top = new Node<T>(null, value);
            else
                Top = new Node<T>(Top, value);
            Count++;
        }
        public T Peek()
        {
            return Top.Value;
        }
        public T Pop()
        {
            T value = Top.Value;
            Top = Top.LastElem;
            Count--;
            return value;
        }
    }
}
