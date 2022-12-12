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
            List<string> myOutcomes = new List<string>() { "X", "Y", "Z" };

            int oppIndex = oppMoves.FindIndex(x => x == split[0]);
            int myOutcomeIndex = myOutcomes.FindIndex(x => x == split[1]);

            //// Player Score -- Part 1
            //lineScore += myIndex + 1;            

            //// Outcome Score -- Part 1
            //if (myIndex == oppIndex)
            //{
            //    // Draw
            //    lineScore += 3;
            //}
            //else if (
            //    myIndex == 0 && oppIndex == 2 || // Rock beats Scissors
            //    myIndex == 1 && oppIndex == 0 || // Paper beats Rock
            //    myIndex == 2 && oppIndex == 1)   // Scissors beats Paper
            //{
            //    // Win
            //    lineScore += 6;
            //}
            //else
            //{
            //    // Loss, no score
            //}
            //

            // TODO: After finding the outcome, set my move.

            // Outcome Score -- Part 2
            switch (myOutcomeIndex)
            {
                case 0:
                    lineScore += 0;
                    break;
                case 1:
                    lineScore += 3;
                    break;
                case 2:
                    lineScore += 6;
                    break;
                default:
                    break;

            }

            // Player Score -- Part 2
            if (myOutcomeIndex == 1)
            {
                // Draw - Play what they played
                lineScore += oppIndex + 1;
            }
            else if (myOutcomeIndex == 0)
            {
                // Loss - Play what would lose to them


                // If Rock, roll back over to scissors
                if (oppIndex == 0)
                {
                    lineScore += 3;
                }
                else
                {
                    lineScore += oppIndex;
                }
            }
            else
            {
                // Win

                // If Scissors, roll back over to rock
                if (oppIndex == 2)
                {
                    lineScore += 1;
                }
                else
                {
                    // else play higher than them
                    lineScore += oppIndex + 2;
                }
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
