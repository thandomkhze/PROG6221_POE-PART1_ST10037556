using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace POE
{
    class Ingredients
    {
        private List<ArrayList> totalIngredient = new List<ArrayList>();
        private ArrayList singleIngredient;
        
        public Ingredients()
        {
            Boolean ingredientNoEntered = false;
            while (!ingredientNoEntered)
            {
                Console.WriteLine("Enter the number of ingredients.");
                String placeHolder = Console.ReadLine();
                int numIngredients = 0;
                if (!isEmpty(placeHolder))
                    if(checkFloat(placeHolder,true))
                        numIngredients = Convert.ToInt32(placeHolder);

                setIngredients(numIngredients);
            }
            
        }
        public void setIngredients(int numIngredients)
        {
            for (int k = 0; k < numIngredients; k++)
            {
                String name = "", unitOfMeasurement = "",q = "";
                double quantity = 0.0;
                singleIngredient = new ArrayList();
                Console.WriteLine("Ingredient No." + (k+1));

                name = confermName(name);
                unitOfMeasurement = confermUnit(unitOfMeasurement);
                quantity = confermQuantity(q,unitOfMeasurement);

                singleIngredient.Add(name);
                singleIngredient.Add(unitOfMeasurement);
                singleIngredient.Add(quantity);
                totalIngredient.Add(singleIngredient);
            }

        }

        public List<ArrayList> getIngredients()
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

                if (isEmpty(name))
                {
                    conferm = false;
                    Console.WriteLine("The name has not been entered");
                }
                else
                    conferm = true;
            }
            return name;
        }

        private double confermQuantity(String quantity, String unit)
        {
            Boolean conferm = false;
            double q = 0.0;
            while (!conferm)
            {
                Console.Write("Amount of " + unit + " : ");
                quantity = Console.ReadLine();

                if (isEmpty(quantity))
                {
                    conferm = false;
                    Console.WriteLine("The quantity has not been entered");
                }
                else
                if (checkFloat(quantity,false))
                {
                    conferm= true;
                    q = Convert.ToDouble(quantity);
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

                if (isEmpty(unit))
                {
                    conferm = false;
                    Console.WriteLine("The unit of messurement has not been entered");
                }
                else
                    conferm = true;
            }
            return unit;
        }

        private Boolean isEmpty(String s)
        {
            
            if (s.Trim() == null || s.Trim() == "")
                return true;
            else
                return false;
        }

        private Boolean checkFloat(String d,Boolean wholeNo)
        {
            var value =0.0;
            
            try
            {
                if (wholeNo)
                    value = Convert.ToInt32(d);
                else
                    value = Convert.ToDouble(d);

                if (value > 0)
                    return true;
                else
                    Console.WriteLine("The value needs to ba a positive number");
            }catch(System.FormatException)
            {
                Console.WriteLine("Input needs to be a whole number");
            }
            catch(Exception e)
            { 
                Console.WriteLine("Input needs to be a number"); 
            }
            
            return false;
        }

    }
}