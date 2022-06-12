using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labwork
{
    class Calc
    {
        private double leftValue, rightValue;
        private int operation;

        public void GetOperation()
        {
            bool foundOperation = false;
            while (!foundOperation)
            {
                Console.WriteLine("Available operatons:\n" +
                    "0 for exit the programm\n" +
                    "1 for + (summation)\n" +
                    "2 for - (substriction)\n" +
                    "3 for * (multiplication)\n" +
                    "4 for / (division)\n");
                Console.Write("Enter operation: ");

                try
                {
                    operation = Convert.ToInt32(Console.ReadLine());
                    if (operation < 0 || operation > 4)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Incorrect number of operation!");
                        Console.ResetColor();
                    }
                    else
                    {
                        if (operation == 0)
                        {
                            Console.WriteLine("Exit the program.");
                            System.Environment.Exit(0);
                        }

                        foundOperation = true;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorect operation format");
                    Console.ResetColor();
                }
            }
        }

        public void GetValues()
        {
            bool foundValue = false;
            while (!foundValue)
            {
                Console.Write("Enter left value: ");

                try
                {
                    leftValue = Convert.ToDouble(Console.ReadLine());
                    foundValue = true;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorect value format");
                    Console.ResetColor();
                }
            }

            foundValue = false;
            while (!foundValue)
            {
                Console.Write("Enter right value: ");

                try
                {
                    rightValue = Convert.ToDouble(Console.ReadLine());
                    foundValue = true;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorect value format");
                    Console.ResetColor();
                }
            }
        }

        public void PerformOperation()
        {
            switch (operation)
            {
                case 1:
                    Console.WriteLine(leftValue + " + " + rightValue + " = " + (leftValue + rightValue));
                    break;
                case 2:
                    Console.WriteLine(leftValue + " - " + rightValue + " = " + (leftValue - rightValue));
                    break;
                case 3:
                    Console.WriteLine(leftValue + " * " + rightValue + " = " + (leftValue * rightValue));
                    break;
                case 4:
                    if (rightValue != 0)
                    {
                        Console.WriteLine(leftValue + " / " + rightValue + " = " + (leftValue / rightValue));
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You can't divide by zero");
                        Console.ResetColor();
                    }
                    break;
            }
        }
    }
}
