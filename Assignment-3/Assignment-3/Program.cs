using System;

namespace Assignment_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Solution.DeleteNth(new int[] { 20, 37, 20, 21 }, 1);
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
