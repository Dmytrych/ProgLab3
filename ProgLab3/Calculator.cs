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
