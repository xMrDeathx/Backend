using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labwork
{
    class Program
    {
        static void Main()
        {
            Calc calc = new Calc();
            while (true)
            {
                Console.Clear();
                calc.GetOperation();
                calc.GetValues();
                calc.PerformOperation();
                Console.WriteLine("Press anything to repeat");
                Console.ReadLine();
            }
        }
    }
}
