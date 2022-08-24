using System;
using System.Collections;
using System.Collections.Generic;

namespace VacationProblem
{
    /// <summary>
    /// Problem : https://atcoder.jp/contests/dp/tasks/dp_c
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please No of Days");
            int days = Convert.ToInt32(Console.ReadLine());

            int[,] happinessGain = new int[days, 3];

            int[,] fessibleSolution = new int[days, 3];

            //{day,activityType}
            Dictionary<int, char> activity = new Dictionary<int, char>
            {
                {0,'A' },{1,'B'},{2,'C'}
            };

            for (int i = 0; i < days; i++)
            {
                Console.WriteLine($"Please enter Happiness Gain values for Day :{i + 1}");
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine($"Please Enter Happiness Gain Value for Activity {activity[j]}");
                    happinessGain[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            //Displaying Inputs so can easily verify
            Console.WriteLine($"No of Days : {days}");
            for (int i = 0; i < days; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{happinessGain[i,j]} ");
                }
            }


            Console.WriteLine();
            //Operations
            for (int i = 0; i < days; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == 0)
                    {
                        fessibleSolution[i, j] = happinessGain[i, j];
                    }
                    else
                    {
                        if (j == 0)
                            fessibleSolution[i, j] = happinessGain[i, j] + Math.Max(fessibleSolution[i - 1, 1], fessibleSolution[i - 1, 2]);
                        else if (j == 1)
                            fessibleSolution[i, j] = happinessGain[i, j] + Math.Max(fessibleSolution[i - 1, 0], fessibleSolution[i - 1, 2]);
                        else
                            fessibleSolution[i, j] = happinessGain[i, j] + Math.Max(fessibleSolution[i - 1, 0], fessibleSolution[i - 1, 1]);
                    }
                }
            }

            var maximumHappinessAttheEnd = Math.Max(fessibleSolution[days-1, 0], Math.Max(fessibleSolution[days-1, 1], fessibleSolution[days-1, 2]));
            Console.WriteLine($"Program Completed, Maximum Happiness he can gain is {maximumHappinessAttheEnd}");
        }
    }
}
