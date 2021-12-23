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
            int banknote = 0;
            while (true)
            {
                banknote = 0;
                try
                {
                    Console.WriteLine("Enter a banknote");
                    banknote = int.Parse(Console.ReadLine());
                    if (banknote <= 0)
                    {
                        throw new Exception("Input value is negative. Try again.");
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Incorrect format of data input.Try again.\n ");
                }
            }


            Console.WriteLine("Enter nominals to change the banknote");
            SortedSet<string> nominals = new SortedSet<string>();
            string input = "";
            
            while (input != "0")
            {
                try
                {
                    input = Console.ReadLine();
                    int inputInt = Convert.ToInt32(input);
                    if (inputInt < 0)
                    {
                        throw new Exception("Input value is negative. Try again.");
                    }
                    else if (input != "0")
                    {
                        nominals.Add(input);
                    }
                }
                catch
                {
                    Console.WriteLine("Incorrect format of data input.Try again.");
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
