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
    private ArrayList[] scale(ArrayList[] arrIngredient)
    {
        Console.WriteLine("Select scale :\n1) 0.5\n2) 2\n3) 3");
        int option = Convert.ToInt32(Console.ReadLine());

        switch (option)
        {
            case 1: arrIngredient = scaleConversion(0.5, arrIngredient); break;
            case 2: arrIngredient = scaleConversion(2, arrIngredient); break;
            case 3: arrIngredient = scaleConversion(3, arrIngredient); break;
        }
        return arrIngredient;
    }
    private ArrayList[] scaleConversion(double scale, ArrayList[] arrIngredient)
    {
        for (int k = 0; k < arrIngredient.Count(); k++)
            arrIngredient[k][1] = (double)arrIngredient[k][1] * scale;
        return arrIngredient;
    }

    private ArrayList[] resetQuantity(ArrayList[] arrIngredient, double[] quantity)
    {
        for (int k = 0; k < quantity.Count(); k++)
            arrIngredient[k][1] = quantity[k];
        return arrIngredient;
    }
}