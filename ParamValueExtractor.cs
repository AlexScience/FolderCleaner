using System;

namespace FolderCleaner
{
    public static class ParamValueExtractor
    {
        public static string GetParamValue(string[] args, string param)
        {
            int paramIndex = Array.IndexOf(args, param);
            if (paramIndex < 0)
            {
                throw new ArgumentException($"Параметр не найден {param}");
            }

            int valueIndex = paramIndex + 1;

            if (valueIndex > args.Length - 1)
            {
                throw new ArgumentException($"Не заданно значение параметра {param}");
            }

            string paramValue = args[valueIndex];

            return paramValue;
        }
    }
}