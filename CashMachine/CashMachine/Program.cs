using System;
using System.Collections.Generic;

namespace CashMachine
{
    class Program
    {
        public static int GetCombinations(int total, int index, int[] list, List<int> cur)
        {
            if (total == 0)
            {
                foreach (var item in cur)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
                return 1;
            }
            if (index == list.Length)
            {
                return 0;
            }
            int ret = 0;
            for (; total >= 0; total -= list[index])
            {
                ret += GetCombinations(total, index + 1, list, cur);
                cur.Add(list[index]);
            }
            for (int i = 0; i < cur.Count; i++)
            {
                while (cur.Count > i && cur[i] == list[index])
                {
                    cur.RemoveAt(i);
                }
            }
            return ret;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a banknote");
            var banknote = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter nominals to change the banknote");
            SortedSet<string> nominals = new SortedSet<string>();
            string input = "";

            while (input != "0")
            {
                input = Console.ReadLine();
                if (input != "0")
                {
                    nominals.Add(input);
                }
            }
      
            List<int> nominalsInt = new List<int>(); 
            foreach (var item in nominals)
            {
                try
                {
                    int value = Convert.ToInt32(item);
                    if (value < 0)
                    {
                        Console.WriteLine("Not valid argument");
                    }
                    else
                    {
                        nominalsInt.Add(value);
                    }
                }
                catch
                {    
                    Console.WriteLine("Not valid argument");             
                }
            }
            int[] nominalsValue = nominalsInt.ToArray();

            Console.WriteLine("Possible variants:");
            GetCombinations(banknote, 0, nominalsValue, new List<int>());

        }
    }
}
