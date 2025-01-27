using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ConsoleApp21
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите путь к файлу:");
            string filePath = Console.ReadLine()?.Trim('"');
            string searchWord = "bicycle";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }

            ProcessStartInfo notepadStartInfo = new ProcessStartInfo
            {
                FileName = @"C:\\Windows\\System32\\notepad.exe",
                Arguments = filePath,
                UseShellExecute = true
            };

            try
            {
                Process notepadProcess = Process.Start(notepadStartInfo);
                Console.WriteLine("Файл открыт.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Не удалось открыть: {ex.Message}");
                return;
            }

            try
            {
                string fileContent = File.ReadAllText(filePath);
                int wordCount = fileContent.Split(new[] { ' ',','}).Count(word => string.Equals(word, searchWord));

                Console.WriteLine($"Слово '{searchWord}' встречается {wordCount} раз(а).");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
} 