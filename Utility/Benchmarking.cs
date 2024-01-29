using System.Diagnostics;

namespace ZedUtils.Utility
{
    public static class Benchmarking
    {
        /// <summary>
        /// Run a simplistinc benchmark on an action
        /// </summary>
        /// <param name="action"></param>
        /// <param name="iterations"></param>
        /// <returns></returns>
        public static string Benchmark(Action action, int iterations)
        {
            TimeSpan total = new(), average = new(0), best = new(days: 1, 1, 1, 1), worst = new();
            for (int i = 0; i < iterations; i++)
            {
                TimeSpan current = Time(action);
                total += current;
                average += current;
                if(current < best) best = current;
                if(current > worst) worst = current;
            }
            average /= iterations;
            return $"{iterations} iterations in {total}\nAverage: {average}\nBest: {best}\nWorst: {worst}";
        }
        /// <summary>
        /// Time an action
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static TimeSpan Time(Action action)
        {
            var watch = new Stopwatch();
            watch.Start();
            action();
            watch.Stop();
            return watch.Elapsed;
        }
    }
}