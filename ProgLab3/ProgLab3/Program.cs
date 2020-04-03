using System;
using System.Collections.Generic;

namespace ProgLab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Calculate(CreatePostfixNotation(Console.ReadLine())));
        }
        static int Fact(int x)
        {
            for (int i = x-1; i != 1; i--)
            {
                x *= i;
            }
            return x;
        }
        static string CreatePostfixNotation(string input)
        {
            MyStack<char> stack = new MyStack<char>();
            string result="";
            input = input.Replace(" ", "");
            char[] tokens = input.ToCharArray();
            bool nextIsNegative = false;
            for (int i = 0; i < tokens.Length; i++)
            {
                switch (tokens[i])
                {
                    case '!':
                        result += " ";
                        while (stack.Count > 0)
                        {
                            if (stack.Peek() == '!')
                            {
                                result += " ";
                                result += stack.Pop().ToString();
                                result += " ";
                            }
                            else
                            {
                                break;
                            }
                        }
                        stack.Push(tokens[i]);
                        break;
                    case '/':
                        result += " ";
                        while (stack.Count > 0)
                        {
                            if (stack.Peek() == 'V' || stack.Peek() == '/' || stack.Peek() == '*'|| stack.Peek() == '!')
                            {
                                result += " ";
                                result += stack.Pop().ToString();
                                result += " ";
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
                            if(stack.Peek() == 'V' || stack.Peek() == '/' || stack.Peek() == '*'||stack.Peek()=='!')
                            {
                                result += " ";
                                result += stack.Pop().ToString();
                                result += " ";
                            }
                            else
                            {
                                break;
                            }
                        }
                        stack.Push(tokens[i]);
                        break;
                    case 'V':
                        result += " ";
                        while (stack.Count > 0)
                        {
                            if ( stack.Peek() == '!')
                            {
                                result += " ";
                                result += stack.Pop().ToString();
                                result += " ";
                            }
                            else
                            {
                                break;
                            }
                        }
                        stack.Push(tokens[i]);
                        break;
                    case '-':
                        if (tokens[i - 1] == '(')
                        {
                            nextIsNegative = true;
                        }
                        else
                        {
                            nextIsNegative = false;
                            result += " ";
                            while (stack.Count > 0)
                            {
                                if (stack.Peek() == 'V' || stack.Peek() == '/' || stack.Peek() == '*' || stack.Peek() == '-' || stack.Peek() == '+'||stack.Peek()=='!')
                                {
                                    result += " ";
                                    result += stack.Pop().ToString();
                                    result += " ";
                                }
                                else
                                {
                                    break;
                                }
                            }
                            stack.Push(tokens[i]);
                        }
                        break;
                    case '+':
                        result += " ";
                        while (stack.Count > 0)
                        {
                            if (stack.Peek() == 'V' || stack.Peek() == '/' || stack.Peek() == '*' || stack.Peek() == '-' || stack.Peek() == '+' || stack.Peek() == '!')
                            {
                                result += " ";
                                result += stack.Pop().ToString();
                                result += " ";
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
                            result += " ";
                            result += stack.Pop().ToString();
                        }
                        stack.Pop();
                        break;
                    default:
                        if (nextIsNegative)
                        {
                            result += "-";
                            nextIsNegative = false;
                        }
                        result += tokens[i].ToString();
                        break;
                }
            }
            while (stack.Count > 0)
            {
                result += " ";
                result += stack.Pop().ToString();
            }
            return result;
        }

        static int Calculate(string input)
        {
            int temp;
            string[] tokensAndOperators = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] newArray;
            for (int i = 1; i < tokensAndOperators.Length; i++)
            {
                switch (tokensAndOperators[i])
                {
                    case "!":
                        temp = Fact(Convert.ToInt32(tokensAndOperators[i - 1]));
                        if (tokensAndOperators.Length > 1)
                        {
                            newArray = new string[tokensAndOperators.Length - 1];
                        }
                        else
                        {
                            return Convert.ToInt32(tokensAndOperators[0]);
                        }
                        for (int j = 0; j < i - 1; j++)
                        {
                            newArray[j] = tokensAndOperators[j];
                        }
                        newArray[i - 1] = temp.ToString();
                        for (int j = i; j < newArray.Length; j++)
                        {
                            newArray[j] = tokensAndOperators[j + 1];
                        }
                        tokensAndOperators = newArray;
                        i = -1;
                        break;
                        break;
                    case "+":
                    temp = Convert.ToInt32(tokensAndOperators[i - 2]) + Convert.ToInt32(tokensAndOperators[i - 1]);
                    if (tokensAndOperators.Length > 2)
                    {
                        newArray = new string[tokensAndOperators.Length - 2];
                    }
                    else
                    {
                        return Convert.ToInt32(tokensAndOperators[0]);
                    }
                    for (int j = 0; j < i-2; j++)
                    {
                        newArray[j] = tokensAndOperators[j];
                    }
                    newArray[i - 2] = temp.ToString();
                    for (int j = i-1; j < newArray.Length; j++)
                    {
                        newArray[j] = tokensAndOperators[j + 2];
                    }
                    tokensAndOperators = newArray;
                    i = -1;
                        break;

                    case "-":
                        temp = Convert.ToInt32(tokensAndOperators[i - 2]) - Convert.ToInt32(tokensAndOperators[i - 1]);
                        if (tokensAndOperators.Length > 2)
                        {
                            newArray = new string[tokensAndOperators.Length - 2];
                        }
                        else
                        {
                            return Convert.ToInt32(tokensAndOperators[0]);
                        }
                        for (int j = 0; j < i - 2; j++)
                        {
                            newArray[j] = tokensAndOperators[j];
                        }
                        newArray[i - 2] = temp.ToString();
                        for (int j = i - 1; j < newArray.Length; j++)
                        {
                            newArray[j] = tokensAndOperators[j+2];
                        }
                        tokensAndOperators = newArray;
                        i = -1;
                        break;

                    case "/":
                        temp = Convert.ToInt32(tokensAndOperators[i - 2]) / Convert.ToInt32(tokensAndOperators[i - 1]);
                        if (tokensAndOperators.Length > 2)
                        {
                            newArray = new string[tokensAndOperators.Length - 2];
                        }
                        else
                        {
                            return Convert.ToInt32(tokensAndOperators[0]);
                        }
                        for (int j = 0; j < i - 2; j++)
                        {
                            newArray[j] = tokensAndOperators[j];
                        }
                        newArray[i - 2] = temp.ToString();
                        for (int j = i - 1; j < newArray.Length; j++)
                        {
                            newArray[j] = tokensAndOperators[j + 2];
                        }
                        tokensAndOperators = newArray;
                        i = -1;
                        break;

                    case "*":
                        temp = Convert.ToInt32(tokensAndOperators[i - 2]) * Convert.ToInt32(tokensAndOperators[i - 1]);
                        if (tokensAndOperators.Length > 2)
                        {
                            newArray = new string[tokensAndOperators.Length - 2];
                        }
                        else
                        {
                            return Convert.ToInt32(tokensAndOperators[0]);
                        }
                        for (int j = 0; j < i - 2; j++)
                        {
                            newArray[j] = tokensAndOperators[j];
                        }
                        newArray[i - 2] = temp.ToString();
                        for (int j = i - 1; j < newArray.Length; j++)
                        {
                            newArray[j] = tokensAndOperators[j+2];
                        }
                        tokensAndOperators = newArray;
                        i = -1;
                        break;
                    case "V":
                        temp = Convert.ToInt32(Math.Sqrt(Convert.ToInt32(tokensAndOperators[i - 1])));
                        if (tokensAndOperators.Length > 1)
                        {
                            newArray = new string[tokensAndOperators.Length - 1];
                        }
                        else
                        {
                            return Convert.ToInt32(tokensAndOperators[0]);
                        }
                        for (int j = 0; j < i - 1; j++)
                        {
                            newArray[j] = tokensAndOperators[j];
                        }
                        newArray[i - 1] = temp.ToString();
                        for (int j = i; j < newArray.Length; j++)
                        {
                            newArray[j] = tokensAndOperators[j + 1];
                        }
                        tokensAndOperators = newArray;
                        i = -1;
                        break;

                }
            }
            return Convert.ToInt32(tokensAndOperators[0]);
        }
    }
}
