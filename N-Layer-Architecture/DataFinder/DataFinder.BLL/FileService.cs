using DataFinder.DataFinder.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataFinder.DataFinder.BLL
{
    public class FileService
    {
        public FileRepository FileRepository { get; }
        public FileService()
        {
            FileRepository = new FileRepository();
        }

        public IEnumerable<File> GetAllFiles()
        {
            return FileRepository.GetFilesByDirectory().ToList()
                .Select(fileEntity => new File(fileEntity));
        }

        public File GetFileByFileName(string fileName)
        {
            if (String.IsNullOrEmpty(fileName))
                throw new BusinessRuleException("Введите корректное значение!");

            var fileEntity = FileRepository.GetFileByFileName(fileName);
            if (fileEntity is null)
                throw new BusinessRuleException("Файл с указанным именем не обнаружен!");

            return new File(fileEntity);
        }
    }
}
