using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_2_Sum_of_differences_between_products_and_LCMs
{
    class Solution
    {
        static int GCD(int num1, int num2)
        {
            if (num1 > num2)
            {
                num1 = num1 + num2;
                num2 = num1 - num2;
                num1 = num1 - num2;
            }
            int result = num2 % num1;

            if (result != 0)
                return GCD(result, num1);

            return num1;
        }

        public static int SumDifferencesBetweenProductsAndLCMs(int[][] pairs)
        {
            int lcmTotal = 0;
            int productTotal = 0;
            for (int i = 0; i < pairs.Length; i++)
            {
                int gcd = 1;

                if (pairs[i][0] != 0 && pairs[i][1] != 0)
                    gcd = GCD(pairs[i][0], pairs[i][1]);

                productTotal += (pairs[i][0] * pairs[i][1]);
                lcmTotal = lcmTotal + (pairs[i][0] * pairs[i][1]) / gcd;
            }
            return productTotal - lcmTotal;
        }
    }
}
