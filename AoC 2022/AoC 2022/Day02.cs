using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2022
{
    internal class Day02 : IRunnableDay
    {

        int ScoreLine(string line)
        {
            // Line splits with space, first column opponent, second column you.
            int lineScore = 0;
            var split = line.Split(' ');

            // "Rock", "Paper", "Scissors"
            List<string> oppMoves = new List<string>() { "A", "B", "C" };
            List<string> myMoves = new List<string>() { "X", "Y", "Z" };

            int oppIndex = oppMoves.FindIndex(x => x == split[0]);
            int myIndex = myMoves.FindIndex(x => x == split[1]);

            // Player Score -- 
            lineScore += myIndex + 1;

            // Outcome Score
            if (myIndex == oppIndex)
            {
                // Draw
                lineScore += 3;
            }
            else if (
                myIndex == 0 && oppIndex == 2 || // Rock beats Scissors
                myIndex == 1 && oppIndex == 0 || // Paper beats Rock
                myIndex == 2 && oppIndex == 1)   // Scissors beats Paper
            {
                // Win
                lineScore += 6;
            }
            else
            {
                // Loss, no score
            }

            Console.WriteLine($"{split[0]} {split[1]} scores as {lineScore}");
            return lineScore;
        }

        public void Run()
        {
            Console.WriteLine("Hi from Day 01");

            int score = 0;
            if (File.Exists(@"Inputs\day02input.txt"))
            {
                foreach (string line in System.IO.File.ReadLines(@"Inputs\day02input.txt"))
                {
                    score += ScoreLine(line);
                }
            }

            Console.WriteLine("Part One:");
            Console.WriteLine($"Total score is {score}");


        }

    }
}
