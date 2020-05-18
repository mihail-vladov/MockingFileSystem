using System;

namespace FileManager.App
{
    class Program
    {
        static void Main(string[] args)
        {
            FileManager manager = new FileManager(new DefaultFileSystem());

            manager.Rename("file.to.rename");
        }
    }
}
