using System;
using System.Collections.Generic;

namespace ProgLab3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            MyStack<int> stack = new MyStack<int>();
            foreach (int i in arr)
                stack.Push(i);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            stack.Push(3);
            Console.WriteLine(stack.Pop());
            Console.ReadLine();
        }
    }
}
