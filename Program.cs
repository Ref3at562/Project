using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] data = {115,182,191,31,196,1099,5,172,10,179,83,21,20,21,186,177,195,193,188,199,62,109,105,183,110};

        Array.Sort(data);
        int n = data.Length;

        double mean = data.Average();

        double median = data[n / 2];

        var mode = data.GroupBy(x => x)
                       .OrderByDescending(g => g.Count())
                       .First().Key;

        double variance = data.Select(x => Math.Pow(x - mean, 2)).Average();

        double stdDev = Math.Sqrt(variance);

        int range = data.Max() - data.Min();

        double q1 = data[n / 4];
        double q3 = data[(3 * n) / 4];

        double iqr = q3 - q1;

        double lower = q1 - 1.5 * iqr;
        double upper = q3 + 1.5 * iqr;

        Console.WriteLine("Mean: " + mean);
        Console.WriteLine("Median: " + median);
        Console.WriteLine("Mode: " + mode);
        Console.WriteLine("Variance: " + variance);
        Console.WriteLine("Standard Deviation: " + stdDev);
        Console.WriteLine("Range: " + range);
        Console.WriteLine("Q1: " + q1);
        Console.WriteLine("Q3: " + q3);
        Console.WriteLine("IQR: " + iqr);

        Console.WriteLine("\nOutliers:");
        foreach (var x in data)
        {
            if (x < lower || x > upper)
                Console.WriteLine(x);
        }
    }
}
