using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLab3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "((1 + 22) + (1 + 12))";
            Calculator.Calculate(input);
            Console.ReadLine();
        }
    }
}
