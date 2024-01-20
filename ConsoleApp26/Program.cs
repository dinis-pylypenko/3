using System;
using System.Linq;

namespace ProductivityCalculator
{
    abstract class ProductivityCalculator
    {
        static double ComputeEfficiency(string[] tasks)
        {
            int[] timeGaps = new int[tasks.Length - 1];
            int[] taskDurations = new int[tasks.Length];

            taskDurations[0] = Convert.ToInt32(tasks[0].Split('/')[0]) + Convert.ToInt32(tasks[0].Split('/')[1]);

            for (int i = 1; i < tasks.Length; i++)
            {
                string[] parts = tasks[i].Split('/');
                int currentTaskEnd = Convert.ToInt32(parts[0]) + Convert.ToInt32(parts[1]);

                taskDurations[i] = currentTaskEnd;
            }

            Array.Sort(taskDurations);

            for (int i = 0; i < taskDurations.Length - 1; i++)
            {
                timeGaps[i] = Math.Abs(taskDurations[i] - taskDurations[i + 1]);
            }

            double averageGap = timeGaps.Average();

            return 1 / averageGap;
        }

        static void Main()
        {
            string[] tasks = { "0/8", "2/9", "3/6", "5/4", "8/3", "10/5" };
            Console.WriteLine(ComputeEfficiency(tasks));
        }
    }
}
