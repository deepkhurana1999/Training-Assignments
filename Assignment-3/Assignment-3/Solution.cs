using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_3
{
    class Solution
    {
        public static int[] DeleteNth(int[] arr, int x)
        {
            Dictionary<int, int> itemCount = new Dictionary<int, int>();
            return arr.Where((val, idx) => {
                if (itemCount.ContainsKey(val))
                {
                    itemCount[val]++;
                }
                else
                {
                    itemCount.Add(val, 1);
                }
                return itemCount[val] <= x;
            }).ToArray();
        }
    }
}
