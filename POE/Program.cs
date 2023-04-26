using POE;
using System.Collections;

public class Program
{
    public static void Main(String[] args)
    {
        Ingredients ingredients = new Ingredients();
        ArrayList[] totalIngridients = ingredients.getIngredients();
        Steps steps = new Steps();
        String[] totalStep = steps.getSteps();
        display(totalIngridients, totalStep);
    }

    private static void display(ArrayList[] ingredients, String[] Steps)
    {
        Console.WriteLine("=========================================================================================");
        Console.WriteLine("Ingredients:");
        for (int k = 0; k < ingredients.Count(); k++)
        {
            Console.WriteLine("\t * {0} {1}/s of {2} ", ingredients[k][1], ingredients[k][2], ingredients[k][0]);
        }
        Console.WriteLine("\nSteps:");
        for (int j = 0; j < Steps.Count(); j++)
        {
            Console.WriteLine("\tStep {0}:\n\t{1}", j + 1, Steps[j]);
        }
        Console.WriteLine("=========================================================================================");
    }
}