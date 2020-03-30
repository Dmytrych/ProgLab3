using System;
using System.Collections.Generic;
using System.Text;

namespace ProgLab3
{
    class Node<T>
    {
        public Node<T> LastElem { get; private set; }
        public T Value { get; private set; }
        public Node(Node<T> lastElem, T value)
        {
            LastElem = lastElem;
            Value = value;
        }
    }
}
