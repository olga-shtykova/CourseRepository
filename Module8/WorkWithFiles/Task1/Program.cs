namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var dirInfo = new DirectoryInfo(@"D:\TestFolder");

            try
            {
                if (dirInfo.Exists)
                {
                    Console.WriteLine("Before cleaning:");
                    Console.WriteLine($"{dirInfo.Name} contains {dirInfo.GetDirectories().Length} directories and {dirInfo.GetFiles().Length} files.");

                    CleanDirectory(dirInfo);
                }
                else
                {
                    Console.WriteLine("Directory does not exist.");
                    return;
                }

                Console.WriteLine("After cleaning:");
                if (!dirInfo.Exists)
                {
                    Console.WriteLine("Directory does not exist.");
                }
                else
                {
                    Console.WriteLine($"{dirInfo.Name} contains {dirInfo.GetDirectories().Length} directories and {dirInfo.GetFiles().Length} files.");
                }

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine($"The process failed {e.Message}.");
            }          
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
                        if (DateTime.Now.Subtract(file.LastAccessTime).TotalMinutes >= 30)
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
