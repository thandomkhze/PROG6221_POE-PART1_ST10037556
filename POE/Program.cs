using POE;
using System.Collections;

public class Program
{
    private double prevMuliply = 1;
    public static void Main(String[] args)
    {
        new Program().runApp();
    }

    private void runApp()
    {
        Ingredients totalIngridients = new Ingredients();
        ArrayList[] original = totalIngridients.getIngredients();
        ArrayList[] ingridient = original;
        String[] totalStep = new Steps().getSteps();

        display(ingridient, totalStep);


        bool done = false;
        while (!done)
        {
            int choice = 0;

            Console.WriteLine("What do you wish to do?\n" +
                "1) Enter a new recipe.\n" +
                "2) Change the scale of the recipe.\n" +
                "3) Reset quantities to the original values.\n" +
                "4)Exit");

            choice = Convert.ToInt32(Console.ReadLine());
            // case statement which will choose a method that matches the selected option.
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    totalIngridients = new Ingredients();
                    ingridient = totalIngridients.getIngredients();
                    totalStep = new Steps().getSteps();
                    display(ingridient, totalStep);
                    break;

                case 2:
                    display(scale(ingridient), totalStep);
                    break;

                case 3:
                    ingridient = totalIngridients.getIngredients();
                    for (int k = 0; k < ingridient.Count(); k++)
                        ingridient[k][1] = (double)ingridient[k][1] / prevMuliply;
                    display(ingridient, totalStep);
                    prevMuliply = 1;
                    break;

                case 4:
                    done = true;
                    break;
            }
        }
    }

    private void display(ArrayList[] displayedIngredients, String[] Steps)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("=========================================================================================");
        Console.WriteLine("Ingredients:");
        for (int k = 0; k < displayedIngredients.Count(); k++)
        {
            Console.WriteLine("\t * {0} {1}/s of {2} ", displayedIngredients[k][1], displayedIngredients[k][2], displayedIngredients[k][0]);
        }
        Console.WriteLine("\nSteps:");
        for (int j = 0; j < Steps.Count(); j++)
        {
            Console.WriteLine("\tStep {0}:\n\t{1}\n", j + 1, Steps[j]);
        }
        Console.WriteLine("=========================================================================================\n");
        Console.ForegroundColor = ConsoleColor.White;
    }
    //method for scaling the quantities(with the aid of the scaleConversion method.)
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
            arrIngredient[k][1] = (double)arrIngredient[k][1] / prev;

        for (int k = 0; k < arrIngredient.Count(); k++)
            arrIngredient[k][1] = (double)arrIngredient[k][1] * scale;
        Console.WriteLine("Scaled by " + scale);

        return arrIngredient;
    }
}