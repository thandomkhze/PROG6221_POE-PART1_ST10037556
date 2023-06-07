using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE
{
    abstract public class Checks
    {
        protected Boolean IsEmpty(String s)
        {

            if (s.Trim() == null || s.Trim() == "")
                return true;
            else
                return false;
        }

        protected Boolean CheckNum(String d, Boolean wholeNo)
        {
            var value = 0.0;

            try
            {
                if (wholeNo)
                    value = Convert.ToInt32(d);
                else
                    value = Convert.ToDouble(d);

                if (value > 0)
                    return true;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nThe value needs to ba a positive number\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
            catch (System.FormatException)
            {
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nInput needs to be a whole number\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (Exception e)
            {
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nInput needs to be a number\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            return false;
        }
    }
}