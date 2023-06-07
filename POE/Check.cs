using System;
using System.Collections;
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

        protected void display(ArrayList[] displayedIngredients, String[] Steps)
        {
            Console.Clear();
            double totalCalories = 0;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=========================================================================================");
            Console.WriteLine("Ingredients:");
            for (int k = 0; k < displayedIngredients.Count(); k++)
            {
                Console.WriteLine("\t * {0} {1}/s of {2}.\t\tCalories : {3}\t\tFood group : {4} ",
                    displayedIngredients[k][1], displayedIngredients[k][2], displayedIngredients[k][0],
                    displayedIngredients[k][4], displayedIngredients[k][3]);

                totalCalories += (double)displayedIngredients[k][4];
            }

            if (totalCalories > 300)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Calories have exceeded 300 :(  ({0})", totalCalories);
                Console.ForegroundColor = ConsoleColor.Green;
            }

            Console.WriteLine("\nSteps:");
            for (int j = 0; j < Steps.Count(); j++)
            {
                Console.WriteLine("\tStep {0}:\n\t{1}\n", j + 1, Steps[j]);
            }
            Console.WriteLine("=========================================================================================\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}