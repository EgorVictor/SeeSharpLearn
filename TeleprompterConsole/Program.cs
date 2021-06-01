using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace TeleprompterConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            RunTeleprompter().Wait();
        }


        private static async Task ShowTeleprompter(TeleprompterConfig config)
        {
            var words = ReadFrom("sampleQuotes.txt");
            foreach (var word in words)
            {
                Console.Write(word);
                if (!string.IsNullOrWhiteSpace(word)) await Task.Delay(config.DelayInMilliseconds);
            }
        }

        private static IEnumerable<string> ReadFrom(string file)
        {
            string line;
            using var reader = File.OpenText(file);
            while ((line = reader.ReadLine()) != null)
            {
                var lineLength = 0;
                var words = line.Split(' ');
                foreach (var word in words)
                {
                    yield return word + " ";
                    lineLength += word.Length + 1;
                    if (lineLength > 70)
                    {
                        yield return Environment.NewLine;
                        lineLength = 0;
                    }
                }

                yield return Environment.NewLine;
            }
        }


        private static async Task GetInput(TeleprompterConfig config)
        {
            void Work()
            {
                do
                {
                    var key = Console.ReadKey(true);
                    if (key.KeyChar == '>')
                        config.UpdateDelay(-10);
                    else if (key.KeyChar == '<')
                        config.UpdateDelay(10);
                    else if (key.Modifiers == ConsoleModifiers.Control && key.Key == ConsoleKey.X) config.SetDone();
                } while (!config.Done);
            }

            await Task.Run(Work);
        }

        private static async Task RunTeleprompter()
        {
            var config = new TeleprompterConfig();
            var displayTask = ShowTeleprompter(config);
            var speedTask = GetInput(config);
            await Task.WhenAny(displayTask, speedTask);
        }
    }
}