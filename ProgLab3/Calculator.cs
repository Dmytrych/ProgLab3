using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLab3
{
    static class Calculator
    {
        public static double Calculate(string expression)
        {
            expression = expression.Replace(" ", "");
            Stack<char> expessionChars = new Stack<char>();
            foreach(char ch in expression)
            {
                if (ch == ')')
                {
                    string subexpression = "";
                    while (expessionChars.Peek() != '(')
                    {
                        subexpression += expessionChars.Pop();
                    }
                    if(subexpression[subexpression.Length - 1] == '-')
                    subexpression = new string(subexpression.Reverse().ToArray());
                    expression = expression.Replace("(" + subexpression + ")", Convert.ToString(StringCount(subexpression)));
                    double subValue = StringCount(subexpression);
                    expression = subValue > 0 ? expression.Replace("(" + subexpression + ")", Convert.ToString(subValue))
                        : expression.Replace(subexpression, Convert.ToString(subValue));
                    Console.WriteLine(expression);
                }
                else expessionChars.Push(ch);
            }
            return StringCount(expression);
        }
        private static double StringCount(string subexpression)
        {
            return 1;
        }
    }
}
