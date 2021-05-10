using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_4
{
    class Solution
    {
        public static List<int> SumConsecutives(List<int> s)
        {
            Dictionary<int, int> itemCount = new Dictionary<int, int>();
            return s.Where((val, idx) =>
            {
                if (itemCount.ContainsKey(val))
                    itemCount[val]++;
                else
                    itemCount.Add(val, 1);
                bool result = false;

                if((idx+1<s.Count  && s[idx+1]!=val) || idx == s.Count - 1)
                {
                    result = true;
                }
                return result;
            }).Select((val,idx)=> {
                int result =  val * itemCount[val];
                itemCount[val] = 0;
                return result;
            }).ToList();
        }
    }
}
