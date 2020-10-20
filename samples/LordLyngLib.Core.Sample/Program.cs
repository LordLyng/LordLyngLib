using System;
using System.Collections.Generic;
using LordLyngLib.Core.Extensions;

namespace LordLyngLib.Core.Sample
{
    class Program
    {
        static void Main (string[] args)
        {
            string str = null;

            str.IsNullOrEmpty(); //true
            str.NotNullOrEmpty(); //false
            str.IsNullOrWhiteSpace(); //true
            str.NotNullOrWhiteSpace(); //false
            str.IsValidGuid(); //false

            var list = new List<string>() { "one", "two", "three", "four"};
            foreach (var (index, item) in list.WithIndex())
            {
                Console.WriteLine($"found item '{item}' at index {index}");
            }
        }
    }
}
