using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FruitShopSystem.util
{
    public class Inputter
    {
        public static int GetAnInteger(string inpMsg, string errMsg)
        {
            Console.WriteLine(inpMsg);
            while (true)
            {
                try
                {
                    int number = int.Parse(Console.ReadLine());
                    return number;
                }
                catch (Exception e)
                {
                    Console.WriteLine(errMsg);
                }
            }
        }

        public static int GetAnInteger(string inpMsg, string errMsg, int lowerBound)
        {
            Console.WriteLine(inpMsg);
            while (true)
            {
                try
                {
                    int number = int.Parse(Console.ReadLine());
                    if (number < lowerBound)
                    {
                        throw new Exception();
                    }
                    return number;
                }
                catch (Exception e)
                {
                    Console.WriteLine(errMsg);
                }
            }
        }
        public static int GetAnInteger(string inpMsg, string errMsg, int lowerBound, int upperBound)
        {
            Console.WriteLine(inpMsg);
            while (true)
            {
                try
                {
                    int number = int.Parse(Console.ReadLine());
                    if (number < lowerBound || number > upperBound)
                    {
                        throw new Exception();
                    }
                    return number;
                }
                catch (Exception e)
                {
                    Console.WriteLine(errMsg);
                }
            }
        }

        public static double GetADouble(string inpMsg, string errMsg, int lowerBound)
        {
            Console.WriteLine(inpMsg);
            while (true)
            {
                try
                {
                    double number = double.Parse(Console.ReadLine());
                    if (number < lowerBound)
                    {
                        throw new Exception();
                    }
                    return number;
                }
                catch (Exception e)
                {
                    Console.WriteLine(errMsg);
                }
            }
        }

        public static string GetString(string inpMsg, string errMsg)
        {
            Console.WriteLine(inpMsg);
            while (true)
            {
                try
                {
                    string str = Console.ReadLine();
                    if (string.IsNullOrEmpty(str))
                    {
                        throw new Exception();
                    }
                    return str;
                }
                catch (Exception e)
                {
                    Console.WriteLine(errMsg);
                }
            }
        }

        public static string GetString(string inpMsg, string errMsg, string regex)
        {
            Console.WriteLine(inpMsg);
            while (true)
            {
                try
                {
                    string str = Console.ReadLine();
                    if (string.IsNullOrEmpty(str) || !Regex.IsMatch(str, regex, RegexOptions.IgnoreCase))
                    {
                        throw new Exception();
                    }
                    return str;
                }
                catch (Exception e)
                {
                    Console.WriteLine(errMsg);
                }
            }
        }

        public static bool GetBoolean(string inpMsg, string errMsg, string trueValue, string falseValue)
        {
            Console.WriteLine(inpMsg);
            string regex = @"^(" + Regex.Escape(trueValue) + "|" + Regex.Escape(falseValue) + ")$";
            while (true)
            {
                try
                {
                    string str = Console.ReadLine();
                    if (string.IsNullOrEmpty(str) || !Regex.IsMatch(str, regex, RegexOptions.IgnoreCase))
                    {
                        throw new Exception();
                    }
                    return str.Equals(trueValue, StringComparison.OrdinalIgnoreCase);
                }
                catch (Exception e)
                {
                    Console.WriteLine(errMsg);
                }
            }
        }
    }
}
