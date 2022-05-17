using DataFinder.DataFinder.DAL;
using System;

namespace DataFinder.DataFinder.BLL
{
    public class File
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Path { get; }

        public File(FileEntity fileEntity)
        {
            Id = fileEntity.Id;
            Name = fileEntity.Name;
            Path = fileEntity.Path;
        }
    }
}
