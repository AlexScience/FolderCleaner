using System;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace FolderCleaner
{
    class FileCompressor
    {
        public void Compress(string[] path) // метод принимает на вход массив путей 
        {
            foreach (var folder in path)
            {
                string fileName = Path.GetFileNameWithoutExtension(folder); //получаем имя файла без расширения 
                string directoryName = Path.GetDirectoryName(folder); //получаем имя директории из пути 

                string filePath = Path.Combine(directoryName, $"{fileName}.zip"); //автоматически обрабатывает разделители не зависимо от ОС

                using (ZipOutputStream outputStream = new ZipOutputStream(File.Create(filePath)))
                {
                    outputStream.SetLevel(9);

                    byte[] buffer = new byte[4096];
                    ZipEntry entry = new ZipEntry(Path.GetFileName(folder));
                    entry.DateTime = DateTime.Now;
                    outputStream.PutNextEntry(entry);

                    using (FileStream text = File.OpenRead(folder))
                    {
                        int count;
                        do
                        {
                            count = text.Read(buffer, 0, buffer.Length);
                            outputStream.Write(buffer, 0, count);
                        } while (count > 0);
                    }

                    outputStream.Finish();
                    outputStream.Close();
                }

                Console.WriteLine("Архив создан.");
            }
        }
    }
}