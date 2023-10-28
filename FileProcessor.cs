using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;

namespace FolderCleaner
{
    public class FileProcessor
    {
        public void Process(string path, string mask, string command, bool recursive)
        {
            const string deleteCommand = "Delete";
            const string compressCommand = "Compress";

            var fileSystem = new FileSystem();
            IEnumerable<string> files;

            try
            {
                files = Enumerate(recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }

            switch (command)
            {
                case deleteCommand:
                    FileRemover fileRemover = new FileRemover();
                    fileRemover.Remove(files.ToArray());
                    break;
                case compressCommand:
                    FileCompressor fileCompressor = new FileCompressor();
                    fileCompressor.Compress(files.ToArray());
                    break;
                default:
                    throw new Exception("Действие не поддерживается.");
            }

            IEnumerable<string> Enumerate(SearchOption searchOption)
            {
                return fileSystem.Directory.EnumerateFiles(path, mask, searchOption);
            }
        }
    }
}