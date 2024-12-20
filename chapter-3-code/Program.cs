﻿using GettingStarted.Classes;
using System.Diagnostics;

class Program
{
    

    static void Main()
    {
        int[] GetRandomArray(long length)
        {
            Random random = new();
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(-100000, 100000);
            }
            return array;
        }

        // Make sure your list initialization is correct
        List<AbstractSort> algorithms = new()
        {
            new SelectionSort(),
            new InsertionSort()
        };

        for (int n = 0; n <= 100000; n += 10000)
        {
            Console.WriteLine($"\nRunning tests for n = {n}:");
            List<(Type Type, long Ms)> milliseconds = [];
            for (int i = 0; i < 5; i++)
            {
                int[] array = GetRandomArray(n);
                int[] input = new int[n];
                foreach (AbstractSort algorithm in algorithms)
                {
                    array.CopyTo(input, 0);
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    algorithm.Sort(input);
                    stopwatch.Stop();
                    Type type = algorithm.GetType();
                    long ms = stopwatch.ElapsedMilliseconds;
                    milliseconds.Add((type, ms));
                }
            }
            List<(Type, double)> results = milliseconds
                .GroupBy(r => r.Type)
                .Select(r =>
                    (r.Key, r.Average(t => t.Ms))).ToList();
            foreach ((Type type, double avg) in results)
            {
                Console.WriteLine($"{type.Name}: {avg} ms");
            }
        }
    }
}