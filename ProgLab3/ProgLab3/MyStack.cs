using System;

namespace ProgLab3
{
    class MyStack<T>
    {
        Node<T> Top;
        public int Length { get; private set; }
        public MyStack()
        {
            Length = 0;
        }
        public void Push(T value)
        {
            if (Length == 0)
                Top = new Node<T>(null, value);
            else
                Top = new Node<T>(Top, value);
            Length++;
        }
        public T Peek()
        {
            return Top.Value;
        }
        public T Pop()
        {
            T value = Top.Value;
            Top = Top.LastElem;
            return value;
        }
    }
}
