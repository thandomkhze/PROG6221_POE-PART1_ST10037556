using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace POE
{
    public class Recipe : Checks
    {
        private ArrayList arrFullRecipe;
        private double prevMuliply = 1;
        private bool save = false;
        public Recipe()
        {
            Ingredients totalIngredients = new Ingredients();
            ArrayList[] ingredient = totalIngredients.getIngredients();
            String[] totalStep = new Steps().getSteps();

            display(ingredient, totalStep);
            bool exit = false;

            while (!exit)
            {
                int choice = 0;
                Console.WriteLine("What do you wish to do?\n" +
                        "1) Change the scale of the recipe.\n" +
                        "2) Reset quantities to the original values.\n" +
                        "3) Save / Exit");

                choice = Convert.ToInt32(Console.ReadLine());
                // case statement which will choose a method that matches the selected option.
                switch (choice)
                {
                    case 1:
                        display(scale(ingredient), totalStep);
                        break;

                    case 2:
                        //ingredient = totalIngredients.getIngredients();
                        for (int k = 0; k < ingredient.Count(); k++)
                        {
                            ingredient[k][1] = (double)ingredient[k][1] / prevMuliply;
                            ingredient[k][4] = (double)ingredient[k][4] / prevMuliply;
                        }
                        display(ingredient, totalStep);
                        prevMuliply = 1;
                        break;

                    case 3:
                        String reply = "";

                        Console.WriteLine("Do you which to save the recipe? (y/n)");

                        reply = Console.ReadLine();
                        if (reply.Equals("y") || reply.Equals("Y"))
                        {
                            save = true;
                            arrFullRecipe.Add(ingredient);
                            arrFullRecipe.Add(totalStep);
                            exit = true;
                        }
                        else
                            if (reply.Equals("n") || reply.Equals("N"))
                        {
                            save = false;
                            exit = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("invalid input\n" +
                                "require input(y/n)");
                            Console.ForegroundColor = ConsoleColor.White;
                            exit = false;
                        }

                        break;
                }
            }
        }

        public void display(ArrayList[] displayedIngredients, String[] Steps)
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

        private ArrayList[] scale(ArrayList[] arrIngredient)
        {
            Console.WriteLine("Select scale :\n\t1) 0.5\n\t2) 2\n\t3) 3");
            int option = Convert.ToInt32(Console.ReadLine());
            double prev = prevMuliply;

            switch (option)
            {
                case 1:
                    arrIngredient = scaleConversion(prev, 0.5, arrIngredient);
                    prevMuliply = 0.5;
                    break;
                case 2:
                    arrIngredient = scaleConversion(prev, 2, arrIngredient);
                    prevMuliply = 2;
                    break;
                case 3:
                    arrIngredient = scaleConversion(prev, 3, arrIngredient);
                    prevMuliply = 3;
                    break;
            }
            return arrIngredient;
        }

        private static ArrayList[] scaleConversion(double prev, double scale, ArrayList[] arrIngredient)
        {
            for (int k = 0; k < arrIngredient.Count(); k++)
            {
                arrIngredient[k][1] = (double)arrIngredient[k][1] / prev;
                arrIngredient[k][4] = (double)arrIngredient[k][4] / prev;
            }

            for (int k = 0; k < arrIngredient.Count(); k++)
            {
                arrIngredient[k][1] = (double)arrIngredient[k][1] * scale;
                arrIngredient[k][4] = (double)arrIngredient[k][4] * scale;
            }

            Console.WriteLine("Scaled by " + scale);

            return arrIngredient;

        }

        public ArrayList getFullRecipe()
        {
            return arrFullRecipe;
        }

        public bool Save()
        {
            return save;
        }
    }
}