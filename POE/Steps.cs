using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE
{
    public class Steps : Checks
    {
        public Steps()
        {
            Boolean stepNoEntered = false;
            while (!stepNoEntered)
            {
                Console.WriteLine("Enter the number of steps.");
                String placeHolder = Console.ReadLine();
                int numSteps = 0;
                if (!isEmpty(placeHolder))
                    if (checkFloat(placeHolder, true))
                        numSteps = Convert.ToInt32(placeHolder);
                setSteps(numSteps);
            }
        }

        private void setSteps(int numSteps)
        {

        }
        public String getSteps()
        {
            return "";
        }
    }
}
