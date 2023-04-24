using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace POE
{
    class Ingredients
    {
        ArrayList[] totalIngredient;
        ArrayList singleIngredient;
        public Ingredients()
        {
            collectIngredients();
        }
        public void collectIngredients()
        {
            Console.WriteLine("Enter the number of ingredients.");
            int numIngredients = Convert.ToInt32(Console.ReadLine());
            totalIngredient = new ArrayList[numIngredients];
            String name = "", unitOfMeasurement = "";
            double quantity = 0;

            for (int k = 0; k < numIngredients; k++)
            {
                Boolean confermName = false, confermQuantity = false, confermUnit = false;

                singleIngredient = new ArrayList();
                Console.WriteLine("Ingredient No." + (k + 1));
                
                Console.Write("Ingredient name : ");
                name = Console.ReadLine();
               
                Console.Write("Unit of measurement : ");
                    unitOfMeasurement = Console.ReadLine();
                
                Console.Write("Amount of " + unitOfMeasurement + " : ");
                quantity = Convert.ToDouble(Console.ReadLine());
                
                singleIngredient.Add(name);
                singleIngredient.Add(unitOfMeasurement);
                singleIngredient.Add(quantity);
                totalIngredient[k] = singleIngredient;
            }
        }

    }
}
