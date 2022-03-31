using BenchmarkDotNet.Running;

namespace Profiling
{
    static class Program
    {
        static void Main(string[] args)
        {
            // To start BenchmarkDotNet press Ctrl + F5.
            //BenchmarkRunner.Run<Testing>();

            Estimate(20);

            Console.ReadKey();
        }

		static void CreateMatrix(int n)
		{
			var matrix = new int[n][];

			for (int i = 0; i < n; i++)
			{
				matrix[i] = new int[n];
			}

			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					matrix[i][j] = i + j;
				}
			}
		}

		static void Estimate(int n)
		{
			for (int i = 0; i < n; i++)
			{
				CreateMatrix(10000);
			}
		}
	}
}
