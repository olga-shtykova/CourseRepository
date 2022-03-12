using Module10.ExcersiseTasks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.ExcersiseTasks
{
    public class FileInformation : IFile, IBinaryFile
    {
        void IBinaryFile.OpenBinaryFile()
        {
            Console.WriteLine("Открываем бинарный файл...");
        }

        void IFile.ReadFile()
        {
            Console.WriteLine("Читаем текстовый файл...");
        }

        void IBinaryFile.ReadFile()
        {
            Console.WriteLine("Читаем бинарный файл...");
        }

        public void Search(string text)
        {
            Console.WriteLine("Начался поиск файла в тексте...");
        }
    }
}
