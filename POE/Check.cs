using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE
{
    abstract public class Checks
    {
        protected Boolean isEmpty(String s)
        {

            if (s.Trim() == null || s.Trim() == "")
                return true;
            else
                return false;
        }

        protected Boolean checkFloat(String d, Boolean wholeNo)
        {
            var value = 0.0;

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
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Input needs to be a whole number");
            }
            catch (Exception e)
            {
                Console.WriteLine("Input needs to be a number");
            }

            return false;
        }
    }
}