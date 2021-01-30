using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePM_Dal.Utilities
{
  public static  class Calc
    {
        public static double getPercentage(double value, double maxValue)
        {
            double result = 0;
            double x = value;
            if (x > 0)
            {
                result = ((x / maxValue) * 100);
            }
            // return Math.Ceiling(result); // 1 ;
            if (result > 0)
            {
                result = Math.Round(result, 2);
            }
            return result; // 1 ;
        }
        public static double getPercentage(int value, int SecondValue)
        {
            double result = 0;
            double x = value;
            if (x > 0)
            {
                result = ((x / SecondValue) * 100);
            }
            if (result > 0)
            {
                result = Math.Round(result, 2);
            }
            return result; // 1 ;
        }
    }
}
