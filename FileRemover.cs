using System;
using System.IO;
using System.IO.Abstractions;

namespace FolderCleaner
{
    public class FileRemover
    {
        public void Remove(string[] path)
        {
            var fileSystem = new FileSystem();

            foreach (var folder in path)
            {
                try
                {
                    fileSystem.File.Delete(folder);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("В пути указан неправильный символ или путь является пустой строкой.: " +
                                      ex.Message);
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Произошла ошибка при доступе к файлу: " + ex.Message);
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine("У вас нет разрешения на удаление файла: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Произошла ошибка: " + ex.Message);
                }
            }
        }
    }
}