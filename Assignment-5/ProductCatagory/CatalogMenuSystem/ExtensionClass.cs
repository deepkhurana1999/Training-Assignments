using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogMenuSystem
{
    static class ExtensionClass
    {
        public static void IsMandatory(this string str, ref string value)
        {
            while (string.IsNullOrWhiteSpace(str))
            {
                Console.WriteLine("Field is mandatory, it cannot be empty or have only white-spaces. Please enter field again.");
                str = Console.ReadLine();
            }
            value = str;
        }
    }
}
