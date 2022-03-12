namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {        
            var dirInfo = new DirectoryInfo(@"D:\TestFolder");            
            try
            {
                long totalSizeBefore = 0;
                long filesCount = 0;
                if (dirInfo.Exists)
                {
                    Console.WriteLine("Before cleaning:");                    
                    totalSizeBefore = GetTotalSizeOfDirectory(dirInfo);
                    filesCount = dirInfo.GetFiles().Length + dirInfo.GetDirectories().Sum(dir => dir.GetFiles().Length);
                    Console.WriteLine($"Total size of {dirInfo.Name} is {totalSizeBefore}.");

                    CleanDirectory(dirInfo);
                }
                else
                {
                    Console.WriteLine("Directory does not exist.");
                    return;
                }

                var totalSizeAfter = GetTotalSizeOfDirectory(dirInfo);
                var freedSpace = totalSizeBefore - totalSizeAfter;
                Console.WriteLine();
                Console.WriteLine("After cleaning:");
                var filesToltal = dirInfo.GetFiles().Length + dirInfo.GetDirectories().Sum(dir => dir.GetFiles().Length);
                var filesDeleted = filesCount - filesToltal;
                Console.WriteLine($"{filesDeleted} files were deleted and {freedSpace} bytes of space were freed.");
                Console.WriteLine($"Total size of {dirInfo.Name} is {totalSizeAfter}.");

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine($"The process failed {e.Message}.");
            }

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

        static void CleanDirectory(DirectoryInfo dirInfo)
        {
            if (dirInfo == null)
            {
                throw new ArgumentException("Directory was not provided");
            }

            try
            {
                if (dirInfo.Exists)
                {
                    var directories = dirInfo.GetDirectories();
                    var files = dirInfo.GetFiles();                   

                    foreach (var file in files)
                    {
                        if (DateTime.Now.Subtract(file.LastAccessTime).TotalMinutes >= 5)
                        {
                            file.Delete();
                        }
                    }

                    foreach (var directory in directories)
                    {
                        CleanDirectory(directory);
                        if (directory.GetFiles().Length == 0 && directory.GetDirectories().Length == 0)
                        {
                            directory.Delete();                            
                        }
                    }   
                }                
            }
            catch (Exception e)
            {
                Console.WriteLine($"The process failed {e.Message}.");
            }
        }
    }
}
