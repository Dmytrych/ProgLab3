using System;
using System.Collections.Generic;

namespace ProgLab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(CreatePostfixNotation(input));
            string input = Console.ReadLine();
        }

        static string CreatePostfixNotation(string input)
        {
            Stack<char> stack = new Stack<char>();
            string result="";
            input = input.Replace(" ", "");
            char[] tokens = input.ToCharArray();
            for (int i = 0; i < tokens.Length; i++)
            {
                switch (tokens[i])
                {
                    case '/':
                        result += " ";
                        while (stack.Count > 0)
                        {
                            if (stack.Peek() == '/' || stack.Peek() == '*')
                            {
                                result += stack.Pop().ToString();
                            }
                            else
                            {
                                break;
                            }
                        }
                        stack.Push(tokens[i]);
                        break;
                    case '*':
                        result += " ";
                        while (stack.Count > 0)
                        {
                            if(stack.Peek() == '/' || stack.Peek() == '*')
                            {
                                result += stack.Pop().ToString();
                            }
                            else
                            {
                                break;
                            }
                        }
                        stack.Push(tokens[i]);
                        break;
                    case '-':
                        result += " ";
                        while (stack.Count > 0)
                        {
                            if (stack.Peek() == '/' || stack.Peek() == '*' || stack.Peek() == '-' || stack.Peek() == '+')
                            {
                                result += stack.Pop().ToString();
                            }
                            else
                            {
                                break;
                            }
                        }
                        stack.Push(tokens[i]);
                        break;
                    case '+':
                        result += " ";
                        while (stack.Count > 0)
                        {
                            if (stack.Peek() == '/' || stack.Peek() == '*' || stack.Peek() == '-' || stack.Peek() == '+')
                            {
                                result += stack.Pop().ToString();
                            }
                            else
                            {
                                break;
                            }
                        }
                        stack.Push(tokens[i]);
                        break;
                    case '(':
                        stack.Push(tokens[i]);
                        break;
                    case ')':
                        while (stack.Peek() != '(')
                        {
                            result += stack.Pop().ToString();
                        }
                        stack.Pop();
                        break;
                    default:
                        result += tokens[i].ToString();
                        break;
                }
            }
            while (stack.Count > 0)
            {
                result += stack.Pop().ToString();
            }
            return result;
        }

   
    }
}
