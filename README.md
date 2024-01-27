# FolderCleaner

**FolderCleaner** - это консольное приложение, написанное на C#, которое предоставляет удобный способ для обработки файлов в указанной директории в соответствии с заданными параметрами.

## Классы приложения

### 1. FileCompressor

#### Методы:

- **Compress(string[] path)**: Архивирует указанные файлы в формате ZIP.

    - **path**: Массив путей к файлам.

### 2. FileProcessor

#### Методы:

- **Process(string path, string mask, string command, bool recursive)**: Обрабатывает файлы в указанной директории в соответствии с заданными параметрами.

    - **path**: Путь к директории.
    - **mask**: Маска файлов (например, "*.txt").
    - **command**: Действие, которое необходимо выполнить ("Delete" - удаление, "Compress" - архивация).
    - **recursive**: Флаг, указывающий, следует ли выполнять операцию рекурсивно.

### 3. FileRemover

#### Методы:

- **Remove(string[] path)**: Удаляет указанные файлы.

    - **path**: Массив путей к файлам.

### 4. ParamValueExtractor

#### Метод:

- **GetParamValue(string[] args, string param)**: Извлекает значение параметра из массива аргументов командной строки.

    - **args**: Массив аргументов командной строки.
    - **param**: Имя параметра, значение которого необходимо извлечь.

## Пример использования

### Обновленный метод Main

```csharp
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

            Console.WriteLine("Операция выполнена успешно.");
            Console.ReadKey();
        }
    }
}
```

### Командная строка

```bash
dotnet FolderCleaner.dll -p "./Test" -c "delete" -m ".txt" -r "true"
```

## Важно

- Перед использованием приложения убедитесь, что у вас установлен .NET SDK.
- Параметры командной строки должны быть указаны с префиксом, например, `-p`, `-m`, `-c`.