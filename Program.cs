using System;

namespace FolderCleaner
{
    class Program
    {
        static void Main(string[] args)
        {
            //-p "./Test" -c "delete" -m ".txt" -r "true"
            const string pathParam = "-p";
            const string commandParam = "-c";
            const string maskParam = "-m";
            const string recursiveParam = "-r";

            var path = ParamValueExtractor.GetParamValue(args, pathParam);
            var command = ParamValueExtractor.GetParamValue(args, commandParam);
            var mask = ParamValueExtractor.GetParamValue(args, maskParam);
            var recursiveStringValue = ParamValueExtractor.GetParamValue(args, recursiveParam);

            if (!bool.TryParse(recursiveStringValue, out bool recursive))
            {
                recursive = false;
            }

            var fileProcessor = new FileProcessor();
            fileProcessor.Process(path, mask, command, recursive);

            Console.WriteLine("OK");
            Console.ReadKey();
        }
    }
}