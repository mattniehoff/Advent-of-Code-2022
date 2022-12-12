using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2022
{
    internal class Day01 : IRunnableDay
    {

        public void Run()
        {
            Console.WriteLine("Hi from Day 01");

            // Read each line, if not empty add to current elf
            List<int> calorieTotals = new List<int>();
            if (File.Exists(@"Inputs\day01input.txt"))
            {
                int currentCalories = 0;
                foreach (string line in System.IO.File.ReadLines(@"Inputs\day01input.txt"))
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        calorieTotals.Add(currentCalories);
                        currentCalories = 0;
                    }
                    else
                    {
                        int lineValue;
                        int.TryParse(line, out lineValue);
                        currentCalories += lineValue;
                    }
                }
            }

            Console.WriteLine($"Max calories is: {calorieTotals.Max()}");
        }

    }
}
