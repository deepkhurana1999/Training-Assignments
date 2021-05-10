using System;

namespace Assignment_2_Sum_of_differences_between_products_and_LCMs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] arr = new int[][] { new int[] { 1, 1 }, new int[] { 0, 0 }, new int[] { 13, 91 } };
            Console.WriteLine(Solution.SumDifferencesBetweenProductsAndLCMs(arr));
        }
    }
}
