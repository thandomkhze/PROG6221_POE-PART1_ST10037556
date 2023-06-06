using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace POE
{
    public class Ingredients : Checks
    {
        private ArrayList[] totalIngredient;
        private ArrayList singleIngredient;

        public Ingredients()
        {
            int numIngredients = 0;
            Boolean ingredientNoEntered = false;
            while (!ingredientNoEntered)
            {
                Console.WriteLine("Enter the number of ingredients.");
                String placeHolder = Console.ReadLine();

                if (!IsEmpty(placeHolder))
                    if (CheckNum(placeHolder, true))
                    {
                        numIngredients = Convert.ToInt32(placeHolder);
                        ingredientNoEntered = true;
                    }
            }
            totalIngredient = new ArrayList[numIngredients];
            setIngredients(numIngredients);
            Console.Write("\n");
        }
        public void setIngredients(int numIngredients)
        {
            for (int k = 0; k < numIngredients; k++)
            {
                String name = "", unitOfMeasurement = "", foodGroup = "";
                double quantity = 0.0, calories = 0.0;
                singleIngredient = new ArrayList();
                Console.WriteLine("Ingredient No." + (k + 1));

                name = confermName(name);
                unitOfMeasurement = confermUnit(unitOfMeasurement);
                quantity = confermQuantity(unitOfMeasurement);
                foodGroup = confermFoodGroup(foodGroup);
                calories = confermCalories();

                singleIngredient.Add(name);
                singleIngredient.Add(quantity);
                singleIngredient.Add(unitOfMeasurement);
                singleIngredient.Add(foodGroup);
                singleIngredient.Add(calories);

                totalIngredient[k] = singleIngredient;
            }

        }

        public ArrayList[] getIngredients()
        {
            return totalIngredient;
        }

        private String confermName(String name)
        {
            Boolean conferm = false;
            while (!conferm)
            {
                Console.Write("Ingredient name : ");
                name = Console.ReadLine();

                if (IsEmpty(name))
                {
                    conferm = false;
                    Console.WriteLine("The name has not been entered");
                }
                else
                    conferm = true;
            }

            String firstLetter = name.Substring(0, 1).ToUpper();
            name = firstLetter + name.Substring(1, name.Length - 1);
            return name;
        }

        private double confermQuantity(String unit)
        {
            Boolean conferm = false;
            double q = 0.0;
            String quantity;
            while (!conferm)
            {
                Console.Write("Number of " + unit + "s : ");
                quantity = Console.ReadLine();

                if (CheckNum(quantity, false))
                {
                    conferm = true;
                    q = Convert.ToDouble(quantity);
                }
                else
                    Console.WriteLine("Invalid input");

                if (IsEmpty(quantity))
                {
                    conferm = false;
                    Console.WriteLine("The quantity has not been entered");
                }
            }
            return q;
        }

        private String confermUnit(String unit)
        {
            Boolean conferm = false;
            while (!conferm)
            {
                Console.Write("Unit of measurement : ");
                unit = Console.ReadLine();

                if (IsEmpty(unit))
                {
                    conferm = false;
                    Console.WriteLine("The unit of messurement has not been entered");
                }
                else
                    conferm = true;
            }
            return unit;
        }

        private String confermFoodGroup(String group)
        {
            Boolean conferm = false;
            while (!conferm)
            {
                Console.WriteLine("Select the food group which matches the ingredient\n" +
                    "1) Starchy\n" +
                    "2) Fruit / Vegrtable\n" +
                    "3) Dry beans / Peas / Lentils / Soya" +
                    "4) Milk / Dairy product" +
                    "5) Fats / Oil" +
                    "6) Water");
                group = Console.ReadLine();

                if (IsEmpty(group))
                    Console.WriteLine("You have not selected an option.");
                else
                if (CheckNum(group, true))
                {
                    switch (Convert.ToInt32(group))
                    {
                        case 1:
                            group = "Starchy";
                            conferm = true;
                            break;
                        case 2:
                            group = "Fruit / Vegrtable";
                            conferm = true;
                            break;
                        case 3:
                            group = "Dry beans / Peas / Lentils / Soya";
                            conferm = true;
                            break;
                        case 4:
                            group = "Milk / Dairy product";
                            conferm = true;
                            break;
                        case 5:
                            group = "Fats / Oil";
                            conferm = true;
                            break;
                        case 6:
                            group = "Water";
                            conferm = true;
                            break;
                    }
                }
            }
            return group;
        }

        private double confermCalories()
        {
            Boolean conferm = false;
            double calories = 0;
            String cal;
            while (!conferm)
            {
                Console.Write("Calories per ingredient : ");
                cal = Console.ReadLine();

                if (CheckNum(cal, false))
                {
                    conferm = true;
                    calories = Convert.ToDouble(cal);
                }
                else
                    Console.WriteLine("Input needs to be a float value");
            }
            return calories;
        }
    }
}