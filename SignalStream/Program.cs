using System;
using System.IO;
using System.Text;

namespace SignalStream
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var signalStream = new SignalStream(File.OpenRead("file.txt"));
            signalStream.TenthPartRead += (_, e) => Console.WriteLine($"{e.Percent}% read.");


            byte[] buffer = new byte[signalStream.Length];
            signalStream.Read(buffer, 0, (int)signalStream.Length);

            Console.WriteLine(Encoding.Default.GetString(buffer));
        }
    }
}
