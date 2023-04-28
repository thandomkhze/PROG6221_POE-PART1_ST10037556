using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace POE
{
    public class Steps : Checks
    {
        private String[] totalSteps;
        public Steps()
        {
            int numSteps = 0;
            Boolean stepNoEntered = false;
            while (!stepNoEntered)
            {
                Console.WriteLine("Enter the number of steps.");
                String placeHolder = Console.ReadLine();

                if (!isEmpty(placeHolder))
                    if (checkFloat(placeHolder, true))
                    {
                        numSteps = Convert.ToInt32(placeHolder);
                        stepNoEntered = true;
                    }
            }
            totalSteps = new String[numSteps];
            setSteps(numSteps);
            Console.Write("\n");
        }

        private void setSteps(int numSteps)
        {
            for (int k = 0; k < numSteps; k++)
            {
                String description = "";
                Console.WriteLine("Step No." + (k + 1));

                Boolean conferm = false;
                while (!conferm)
                {
                    Console.WriteLine("Step no.{0} description :", k + 1);
                    description = Console.ReadLine();

                    if (isEmpty(description))
                    {
                        conferm = false;
                        Console.WriteLine("A description has not been entered");
                    }
                    else
                        conferm = true;
                }

                totalSteps[k] = (description);
            }
        }

        public String[] getSteps()
        {
            return totalSteps;
        }
    }
}
