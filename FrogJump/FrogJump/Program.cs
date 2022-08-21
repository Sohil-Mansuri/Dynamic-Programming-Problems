using System;

/// <summary>
/// Problem: https://atcoder.jp/contests/dp/tasks/dp_a
/// </summary>
namespace FrogJump
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please Enter No of Stones");
            int N = Convert.ToInt32(Console.ReadLine());
            int result = 0;
            if (N > 1)
            {
                int[] heights = new int[N];
                Console.WriteLine("Please Enter values of Height");

                for (int i = 0; i < N; i++)
                {
                    heights[i] = Convert.ToInt32(Console.ReadLine());
                }

                result = FindMinimumCost(N, heights);
            }
            else
            {
                Console.WriteLine("No of Stones Must be grether than 1");
            }

            Console.WriteLine($"Progrem complete Your Frog Minimum cost is {result}");
        }

        public static int FindMinimumCost(int N, int[] cost)
        {
            int[] minimumCost = new int[N];
            minimumCost[0] = 0;
            minimumCost[1] = Math.Abs(cost[1] - cost[0]);

            for (int i = 2; i < N; i++)
            {
                minimumCost[i] = Math.Min(Math.Abs(cost[i] - cost[i - 1]) + minimumCost[i - 1], Math.Abs(cost[i] - cost[i - 2]) + minimumCost[i - 2]);
            }
            return minimumCost[N - 1];
        }

    }
}
