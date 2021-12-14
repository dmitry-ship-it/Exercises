using System;
using System.IO;
using System.Text;

namespace SignalStream
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Using stream with a signal every 10% of file read.");

            // if no args provided get file path from console
            Console.WriteLine("Enter file path:");
            var filePath = args is null || args.Length < 1 || args[0].Length < 1
                 ? Console.ReadLine()
                 : args[0];

            // combine with current directory if only part of the file path is provided
            var path = Path.Combine(Directory.GetCurrentDirectory(), filePath);

            // open streams
            using var fileStream = File.OpenRead(path);
            using var signalStream = new SignalStream(fileStream);

            // subscribe to notifications
            signalStream.TenthPartRead += (_, e) => Console.WriteLine($"{e.Percent}% of file read.");

            // read the whole file
            var buffer = new byte[signalStream.Length];
            signalStream.Read(buffer);

            // print file content if the user wants to make sure that the file was read correctly
            // (not recommended for large files)
            Console.WriteLine();
            Console.WriteLine($"Print file content? ({signalStream.Length} bytes) (y/n)");
            if (Console.ReadKey(intercept: true).Key == ConsoleKey.Y)
            {
                Console.WriteLine(Encoding.Default.GetString(buffer, 0, buffer.Length));
            }
        }
    }
}
