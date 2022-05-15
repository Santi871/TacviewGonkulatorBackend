using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using TacviewGonkulatorBackend.Classes;
using System.Diagnostics;
using System.IO;

namespace TacviewGonkulatorBackend.Consumer
{
    public class TacviewConsumer : IConsumer<TacviewProcessingMessage>
    {
        private record ProcessRunInfo
        {
            public string? Result { get; set; }
            public string? Stderr { get; set; }
            public int? ExitCode { get; set; }
        }
        
        private static ProcessRunInfo RunPythonScript(string cmd, string args)
        {
            ProcessStartInfo start = new()
            {
                FileName = "python",
                Arguments = $"\"{cmd}\" \"{args}\"",
                UseShellExecute = false, 
                CreateNoWindow = true, 
                RedirectStandardOutput = true,
                RedirectStandardError = true 
            };
            using var process = Process.Start(start);
            using var reader = process?.StandardOutput;
            var stderr = process?.StandardError.ReadToEnd();
            var result = reader?.ReadToEnd();
            
            return new ProcessRunInfo
            {
                ExitCode = process?.ExitCode,
                Result = result,
                Stderr = stderr
            };
        }
        
        public Task Consume(ConsumeContext<TacviewProcessingMessage> context)
        {
            Console.WriteLine($"Tacview ready for processing at {context.Message.TacviewUri}");

            var dir = Directory.GetCurrentDirectory() + "\\tacviews";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            var downloadFilePath = dir + $"\\tacviews\\{context.Message.TacviewGuid}.zip.acmi";

            Console.WriteLine("\nDownloading blob to\n\t{0}\n", downloadFilePath);
            
            const string? accountName = "tacviewstorage";
            const string? imageContainer = "tacviews";

            var blobUri = new Uri("https://" + accountName +
                ".blob.core.windows.net/" +
                imageContainer +
                "/" + $"{context.Message.TacviewGuid}.zip.acmi");

            var wc = new System.Net.WebClient();
            wc.DownloadFile(blobUri, downloadFilePath);
            Console.WriteLine("Downloaded");

            var result = RunPythonScript(
                "C:\\Users\\Marcelo\\PycharmProjects\\TacviewGonkulator\\main.py",
                downloadFilePath
                );
            
            Console.WriteLine(result);
            return Task.CompletedTask;
        }
    }
}