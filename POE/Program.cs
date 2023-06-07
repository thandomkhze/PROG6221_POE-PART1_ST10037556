using POE;
using System.Collections;

public class Program : Checks
{
    private List<String> recipeNames;
    private List<Recipe> allRecipes = new List<Recipe>();
    public static void Main(String[] args)
    {
        new Program().runApp();
    }

    private void runApp()
    {
        Recipe recipe;
        recipeNames = new List<String>();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Please select one of the following\n" +
                "1)Add a recipe\n" +
                "2)Display a list of all recipes\n" +
                "3)Display a full recipe\n" +
                "4)Exit");

            int choice = 0;
            String c = Console.ReadLine().Trim();
            if (c.Equals("1") || c.Equals("2") || c.Equals("3") || c.Equals("4"))
            {
                choice = Convert.ToInt32(c);
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Enter the recipe name");
                        String name = Console.ReadLine();

                        if (!IsEmpty(name))
                        {
                            recipe = new Recipe();
                            if (recipe.Save() == true)
                            {
                                String firstLetter = name.Substring(0, 1).ToUpper();
                                name = firstLetter + name.Substring(1, name.Length - 1);
                                recipeNames.Add(name);
                                allRecipes.Add(recipe);
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nYou have not entered a recipe name\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;

                    case 2:
                        if (recipeNames.Count > 0)
                        {
                            Console.Clear();
                            recipeNames.Sort();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("=========================================================================================");
                            Console.WriteLine("Recipe List:");
                            foreach (String k in recipeNames)
                                Console.WriteLine(" * " + k);
                            Console.WriteLine("=========================================================================================\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nNo recipes available\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;

                    case 3:
                        if (recipeNames.Count > 0)
                        {
                            Console.Clear();
                            String input = "";
                            Console.WriteLine("Select the recipe you wish to view");
                            for (int x = 0; x < recipeNames.Count; x++)
                                Console.WriteLine("{0} ) {1}", (x + 1), recipeNames[x]);
                            input = Console.ReadLine();

                            if (CheckNum(input, true))
                            {
                                int select = Convert.ToInt32(input);
                                if (select <= recipeNames.Count)
                                {
                                    Recipe rec = allRecipes[select - 1];
                                    display(rec.getIngredients(), rec.getSteps());
                                }
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nNo recipes available\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;

                    case 4: exit = true; break;
                }
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nInvalid input\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}