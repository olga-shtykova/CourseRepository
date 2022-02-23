namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var dirInfo = new DirectoryInfo(@"D:\TestFolder");

            var totalSize = GetTotalSizeOfDirectory(dirInfo);

            Console.WriteLine($"Total size of {dirInfo.Name} is {totalSize}.");

            Console.ReadLine();
        }

        public static long GetTotalSizeOfDirectory(DirectoryInfo dirInfo)
        {
            if (dirInfo == null)
            {
                throw new ArgumentException("Directory was not provided");
            }

            long totalSize = 0;

            try
            {               
                if (dirInfo.Exists)
                {
                    totalSize = dirInfo.GetFiles().Sum(file => file.Length) +
                        dirInfo.GetDirectories().Sum(dir => GetTotalSizeOfDirectory(dir));
                }                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return totalSize;
        }
    }
}