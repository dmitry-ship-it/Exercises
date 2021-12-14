using System;
using System.IO;
using System.Text;

namespace SecureStream
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Using stream with password.");

            // if no args provided get file path from console
            Console.WriteLine("Enter file path:");
            var filePath = args is null || args.Length < 1 || args[0].Length < 1
                 ? Console.ReadLine()
                 : args[0];

            var path = Path.Combine(Directory.GetCurrentDirectory(), filePath);

            Console.WriteLine("Enter password:");
            var password = Console.ReadLine();

            try
            {
                PrintFileContent(path, password);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException)
            {
                Console.WriteLine("File not fount.");
            }
        }

        private static void PrintFileContent(string path, string password)
        {
            // open streams
            using var fileStream = File.OpenRead(path);
            using var secureStream = new SecureStream(fileStream, password);

            // read the whole file
            var buffer = new byte[secureStream.Length];
            secureStream.Read(buffer);

            // print file content
            Console.WriteLine();
            Console.WriteLine(Encoding.Default.GetString(buffer, 0, buffer.Length));
        }
    }
}
