using POE;
using System.Collections;

public class Program
{
    private Ingredients ingredients;
    private Steps steps;

    private ArrayList[] totalIngridients;
    private ArrayList[] originalQuantity;

    private String[] totalStep;
    public static void Main(String[] args)
    {
        new Program().runApp();
    }

    private void runApp()
    {
        collectAndDisplay();
        Boolean done = false;
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
                    collectAndDisplay();
                    break;
                case 2:
                    totalIngridients = originalQuantity;
                    display(scale(totalIngridients), totalStep);
                    break;
                case 3:
                    display(originalQuantity, totalStep);
                    break;
                case 4:
                    done = true;
                    break;
            }
        }
    }
    //method for collecting and displaying the ingredients and steps with the aid of a method called display().
    private void collectAndDisplay()
    {
        Console.Clear();
        ingredients = new Ingredients();
        originalQuantity = ingredients.getIngredients();
        totalIpngridients = ingredients.getIngredients();
        

        steps = new Steps();
        totalStep = steps.getSteps();

        display(originalQuantity, totalStep);
    }

    private void display(ArrayList[] ingredients, String[] Steps)
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
            Console.WriteLine("\tStep {0}:\n\t{1}\n", j + 1, Steps[j]);
        }
        Console.WriteLine("=========================================================================================\n");

    }
    //method for scaling the quantities(with the aid of the scaleConversion method.)
    private ArrayList[] scale(ArrayList[] arrIngredient)
    {
        Console.WriteLine("Select scale :\n\t1) 0.5\n\t2) 2\n\t3) 3");
        int option = Convert.ToInt32(Console.ReadLine());

        switch (option)
        {
            case 1: arrIngredient = scaleConversion(0.5, arrIngredient); break;
            case 2: arrIngredient = scaleConversion(2, arrIngredient); break;
            case 3: arrIngredient = scaleConversion(3, arrIngredient); break;
        }
        return arrIngredient;
    }
    private static ArrayList[] scaleConversion(double scale, ArrayList[] arrIngredient)
    {
        ArrayList[] ChangedQuantity = new ArrayList[arrIngredient.Count()];

        ChangedQuantity = arrIngredient;

        for (int k = 0; k < ChangedQuantity.Count(); k++)
            ChangedQuantity[k][1] = (double)ChangedQuantity[k][1] * scale;
        Console.WriteLine("Scaled by " + scale);

        return ChangedQuantity;
    }
}