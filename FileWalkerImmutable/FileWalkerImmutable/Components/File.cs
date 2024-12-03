using System;

namespace FileWalkerImmutable.Components
{
    class File : IFile
    {
        public string Name { get; }
        public Guid ID { get; }
        public int Size { get; }
        public string Content { get; }
        public bool Active { get; }

        public File(string name, int size, string content, Guid? id = null)
        {
            Name = name;
            ID = id ?? Guid.NewGuid();
            Size = size;
            Content = content;
        }

        public IComponent Rename(string newName)
        {
            return new File(newName, Size, Content, ID);
        }
    }
}
